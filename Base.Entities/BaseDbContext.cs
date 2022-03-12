using Base.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Base.Entities
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options) { }

        #region DbSet
        public DbSet<UserModel> User { get; set; }
        public DbSet<ComplaintsModel> Complaints { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                FirstName = "Role",
                LastName = "Admin",
                IsActive = true,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });
        }
    }
}
