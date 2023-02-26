using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace Money_Finder
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
            //services.Configure<IISOptions>(options =>
            //{
            //    options.ForwardClientCertificate = false;
            //});
            services.AddControllersWithViews();
            services.AddSession();
            services.AddMvcCore();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();

            app.Map("/ping/db", builder =>
            {
                builder.Run(async context =>
                {
                    using (var connection = new SqlConnection("Data Source=SQL5061.site4now.net;Initial Catalog=db_a786af_sternsites;User Id=db_a786af_sternsites_admin;Password=lalamunir@20; Min Pool Size=10; Max Pool Size=100"))
                    {
                        try
                        {
                            await connection.OpenAsync();
                            using (var command = new SqlCommand("SELECT 1", connection))
                            {
                                command.CommandType = CommandType.Text;
                                await command.ExecuteScalarAsync();
                            }
                            context.Response.ContentType = "text/html";
                            context.Response.StatusCode = 200;
                            await context.Response.WriteAsync("ok");
                        }
                        catch (SqlException)
                        {
                            context.Response.StatusCode = 500;
                            await context.Response.WriteAsync("error");
                        }
                    }
                });
            });

            app.Map("/ping", builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.ContentType = "text/html";
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("ok");
                });
            });


            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Money}/{action=short_form}/{id?}");
   
            endpoints.MapControllerRoute(
                    name: "short-form",
                    pattern: "short-form",
                   defaults: new { Controller = "Money", action = "short_form" });

                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "admin",
                  defaults: new { Controller = "admin", action = "login" });

            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
     ForwardedHeaders.XForwardedProto
            });



        }
    }
}
