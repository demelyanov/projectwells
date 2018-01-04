using Microsoft.EntityFrameworkCore;
using status.domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace status.dataaccess
{
    public class StatusDbContext : DbContext
    {
        public StatusDbContext(DbContextOptions<StatusDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<PickingPerson> PickingPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Project)
                .WithOne(b => b.User)
                .HasForeignKey<Project>(b => b.UserId);

        }
    }
}
