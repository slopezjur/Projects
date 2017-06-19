using HelloHacksREST.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HelloHacksREST.Repositories
{
    public class HackDBContext : DbContext
    {
        public HackDBContext()
        {
            
        }

        public HackDBContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }

        public DbSet<Hack> Hacks { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}