using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inClass1b.mvc.Models.Portifolio
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
                    : base(options) { }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InterviewRequest> InterviewRequests { get; set; }


        // override of parent DbContext's virtual method.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define bridge table's composite primary key.
            modelBuilder.Entity<ProjectTechnology>()
                .HasKey(tp => new { tp.TechnologyName, tp.ProjectId });

            // Define bridge table's foreign keys.
            modelBuilder.Entity<ProjectTechnology>()
              .HasOne(tp => tp.Technology)//主表名
              .WithMany(tp => tp.ProjectTechnologies)//桥表名
              .HasForeignKey(fk => new { fk.TechnologyName })//桥表外键名
              .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ProjectTechnology>()
              .HasOne(tp => tp.Project)//主表名
              .WithMany(tp => tp.ProjectTechnologies)//桥表名
              .HasForeignKey(fk => new { fk.ProjectId })//桥表外键名
              .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

    }
}
