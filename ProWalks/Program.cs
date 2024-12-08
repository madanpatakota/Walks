using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProWalks.Data;
using ProWalks.Repositories;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ProWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProWalks"),
        sqlOptions => sqlOptions.CommandTimeout(180));
});


//1 st point class instances we can handle over here.

// IBook _book = new Book();

//2. Matter is that weahter we have to use singleton , scoped , transient while you are register the class(create the instance)

builder.Services.AddScoped<IRegionRepository,RegionRepository>();  // instance of the Regionreposioty




//check the user tokens
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    //   https://login.microsoftonline.com/90a1fa4c-d3db-44fd-8357-510b8888bf8d/oauth2/authorize?
    //    client_id = 54baa4e8 - a518 - 4940 - 948f - 439035b638ed & response_type = token
    //    & redirect_uri = http % 3A % 2F % 2Flocalhost % 3A5000 % 2F &
    //    resource = 54baa4e8 - a518 - 4940 - 948f - 439035b638ed & response_mode = fragment & state = 12345
    //    & nonce = 678910

        options.Authority = $"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "54baa4e8-a518-4940-948f-439035b638ed",
            ValidateLifetime = true,
            ValidIssuers = new[]
            {
                $"https://sts.windows.net/{builder.Configuration["AzureAd:TenantId"]}/"
            }
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token is valid");
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                context.Response.StatusCode = 400;
                return Task.CompletedTask;
            },
            // Triggered when a challenge occurs (e.g., invalid or missing token)
            OnChallenge = context =>
            {
                var result = new
                {
                    message = "Access denied. You are not authorized to access this resource."
                };
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddCors(options =>
{
    //AllowAllOrigins
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});



//to create the instance of the class challenge the task.
//

// Library
// 




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
