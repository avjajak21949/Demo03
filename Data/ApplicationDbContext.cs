﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Demo03.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Demo03.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
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

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.ClassID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.UploadedBy)
                .WithMany()
                .HasForeignKey(d => d.UploadedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Class)
                .WithMany()
                .HasForeignKey(d => d.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting configurations
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Host)
                .WithMany()
                .HasForeignKey(m => m.HostUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Class)
                .WithMany(c => c.Meetings)
                .HasForeignKey(m => m.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Attendance relationships
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Class)
                .WithMany()
                .HasForeignKey(a => a.ClassID)
                .OnDelete(DeleteBehavior.Restrict);
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
            var teacherAccount = new IdentityUser
            {
                Id = "user3",
                UserName = "teacher@gmail.com",
                Email = "teacher@gmail.com",
                NormalizedUserName = "TEACHER@GMAIL.COM",
                NormalizedEmail = "TEACHER@GMAIL.COM",
                EmailConfirmed = true
            };

            var hasher = new PasswordHasher<IdentityUser>();
            adminAccount.PasswordHash = hasher.HashPassword(adminAccount, "123456");
            studentAccount.PasswordHash = hasher.HashPassword(studentAccount, "123456");
            employerAccount.PasswordHash = hasher.HashPassword(employerAccount, "123456");
            teacherAccount.PasswordHash = hasher.HashPassword(teacherAccount, "123456");

            builder.Entity<IdentityUser>().HasData(adminAccount, studentAccount, employerAccount, teacherAccount);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "role0",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
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
                },
                new IdentityRole
                {
                    Id = "role3",
                    Name = "Teacher",
                    NormalizedName = "TEACHER"
                }
            );

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
                },
                new IdentityUserRole<string>
                {
                    UserId = "user3",
                    RoleId = "role3"
                }
            );
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollment { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
