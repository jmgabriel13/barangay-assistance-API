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
        public DbSet<RoleModel> Role { get; set; }
        public DbSet<MaritalStatusModel> MaritalStatus { get; set; }
        public DbSet<GenderModel> Gender { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 1,
                PhotoPath = "",
                Username = "admin",
                Password = "admin",
                FirstName = "Role",
                LastName = "Admin",
                Age = 20,
                Gender = 1,
                MaritalStatus = 1,
                BirthDate = DateTime.Now,
                BirthPlace = "Tabi tabi",
                PhoneNumber = "09123456789",
                Email = "admin@mail.com",
                Position = 1,
                Purok = "Purok 1",
                TermFrom = DateTime.Now,
                TermTo = DateTime.Now.AddYears(1),
                IsActive = true,
                IsDeleted = false,
                CreatedBy = 0,
                DateCreated = DateTime.Now
            });
        }
    }
}
