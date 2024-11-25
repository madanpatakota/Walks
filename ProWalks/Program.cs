using Microsoft.EntityFrameworkCore;
using ProWalks.Data;
using ProWalks.Repositories;

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
