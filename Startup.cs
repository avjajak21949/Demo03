﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Demo03.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo03
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Add this line to include roles
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        private async Task SeedAdminUser(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Thông tin tài khoản admin cần thêm
                var adminEmail = "admin@gmail.com";
                var adminPassword = "Anderson210402@";

                // Kiểm tra xem tài khoản admin đã tồn tại chưa
                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    // Tạo tài khoản admin
                    var newAdmin = new IdentityUser
                    {
                        Id = "+a6s2da+s62da+s62da+s62da+s6d2as+6d2s+3fdg2+",
                        UserName = adminEmail,
                        Email = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true // Nếu bạn muốn xác nhận email
                    };

                    // Thay đổi password nếu cần
                    var createAdminResult = await userManager.CreateAsync(newAdmin, adminPassword);

                    if (createAdminResult.Succeeded)
                    {
                        // Gán vai trò admin cho tài khoản
                        await userManager.AddToRoleAsync(newAdmin, "Adminstator");
                    }
                    else
                    {
                        // Xử lý lỗi nếu có
                        var errors = string.Join(", ", createAdminResult.Errors.Select(e => e.Description));
                        throw new Exception($"Failed to create admin user: {errors}");
                    }
                }
            }

        }
    }
}