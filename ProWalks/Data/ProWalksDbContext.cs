using Microsoft.EntityFrameworkCore;
using ProWalks.DomainModels;


namespace ProWalks.Data
{

    //We are preparing the DBContext


    //DBContext 

    //DBSets it will gives the information about the Table
    public class ProWalksDbContext : DbContext
    {

        public ProWalksDbContext(DbContextOptions options) : base(options){ 
        
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficultys { get; set; }


    }
}
