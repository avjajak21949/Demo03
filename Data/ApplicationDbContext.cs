using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Demo03.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo03.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedUserRole(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.StudentEnrollment)
                .WithMany(se => se.StudentClasses)
                .HasForeignKey(sc => sc.SEID);

            modelBuilder.Entity<StudentClass>()
                .HasOne(sc => sc.Class)
                .WithMany(c => c.StudentClasses)
                .HasForeignKey(sc => sc.ClassID);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany(co => co.Classes)
                .HasForeignKey(c => c.CourseID);

            modelBuilder.Entity<Course>()
                .HasOne(co => co.Category)
                .WithMany(cat => cat.Course)
                .HasForeignKey(co => co.CategoryID);
        }

        private void SeedUserRole(ModelBuilder builder)
        {
            var adminAccount = new IdentityUser
            {
                Id = "user0",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true
            };
            var studentAccount = new IdentityUser
            {
                Id = "user1",
                UserName = "student@gmail.com",
                Email = "student@gmail.com",
                NormalizedUserName = "STUDENT@GMAIL.COM",
                NormalizedEmail = "STUDENT@GMAIL.COM",
                EmailConfirmed = true
            };
            var employerAccount = new IdentityUser
            {
                Id = "user2",
                UserName = "employer@gmail.com",
                Email = "employer@gmail.com",
                NormalizedUserName = "EMPLOYER@GMAIL.COM",
                NormalizedEmail = "EMPLOYER@GMAIL.COM",
                EmailConfirmed = true
            };
            var hasher = new PasswordHasher<IdentityUser>();
            adminAccount.PasswordHash = hasher.HashPassword(adminAccount, "123456");
            studentAccount.PasswordHash = hasher.HashPassword(studentAccount, "123456");
            employerAccount.PasswordHash = hasher.HashPassword(employerAccount, "123456");
            builder.Entity<IdentityUser>().HasData(adminAccount, studentAccount, employerAccount);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "role0",
                    Name = "Adminstator",
                    NormalizedName = "ADMINSTRATOR"
                },
                new IdentityRole
                {
                    Id = "role1",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new IdentityRole
                {
                    Id = "role2",
                    Name = "Employer",
                    NormalizedName = "EMPLOYER"
                });
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "user0",
                    RoleId = "role0"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user1",
                    RoleId = "role1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user2",
                    RoleId = "role2"
                }
            );
        }

        public DbSet<Demo03.Models.Category> Category { get; set; }
        public DbSet<Demo03.Models.Class> Class { get; set; }
        public DbSet<Demo03.Models.Course> Course { get; set; }
        public DbSet<Demo03.Models.StudentClass> StudentClass { get; set; }
        public DbSet<Demo03.Models.StudentEnrollment> StudentEnrollment { get; set; }
    }
}
