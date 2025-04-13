using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraries.Models;

namespace SharedLibraries.Data
{
    public class IdscWebsiteDbContext : DbContext
    {
        public IdscWebsiteDbContext(DbContextOptions<IdscWebsiteDbContext> options)
        : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
        public DbSet<Payment> payment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            

            modelbuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.Student);

        }
    }
}
