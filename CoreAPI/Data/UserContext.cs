using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Data
{
    public class UserContext:DbContext
    {
        private readonly IConfiguration _config;
        public UserContext(DbContextOptions<UserContext> dbContextOptions,IConfiguration Config)
            : base(dbContextOptions)
        {
            _config = Config;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=.;Database=UserDB;Integrated Security=True");
            optionsBuilder.UseSqlServer(_config.GetConnectionString("UserDB"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
