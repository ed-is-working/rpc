using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace rpc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        // This is the table that will be created in the database
        // public DbSet<Character> Characters { get; set; } - or -
        public DbSet<Character> Characters => Set<Character>(); // This is the same as above
        public DbSet<User> Users => Set<User>();
        
        
    }
}