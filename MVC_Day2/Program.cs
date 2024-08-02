using Microsoft.EntityFrameworkCore;
using MVC_Day2.Models;
using MVC_Day2.Models.Repository;

namespace MVC_Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();
            //Register IOC Container
            //1) Built in service already register (IConfiguration)
            //2) Built in Sevice need to register
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });//inject constructor ITIcontext

            //3) Custom service and need regitser <--
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();



            var app = builder.Build();
            #region Custom (inline) MiddleWare

            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("1) Middleware 1\n");
            //    await next.Invoke();
            //});
            //app.Use(async (HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("2) Middleware 2\n");
            //    await next.Invoke();
            //});

            ////terminate middleware
            //app.Run(async(HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync("3) Terminate \n");

            //});
            #endregion
            #region Build in Middleware
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            //overloading for run app
            app.Run();
        }
    }
}
