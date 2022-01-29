using CarAPI.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAPI.API.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public class CarContext : DbContext
    {
        public DbSet<CarEntity> Cars { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarEntity>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}
