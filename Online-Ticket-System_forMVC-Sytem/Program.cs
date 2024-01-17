using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_Ticket_System_forMVC_Sytem.DataAcces;
using Online_Ticket_System_forMVC_Sytem.ForHostingService;
using Online_Ticket_System_forMVC_Sytem.Models;
using Online_Ticket_System_forMVC_Sytem.Services;

namespace Online_Ticket_System_forMVC_Sytem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // builder.Services.AddInfrastructure(builder.Configuration);

            // Disabele Endpoint Routing when using UseMvc
            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnect"))); ;


            // Bu yaxshi ishlab turibdi
            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    var myApplication = new Jujuk(options.Environment);
            //    myApplication.ConfigureServices(builder.Services);
            //    myApplication.Configure(app);
            //    // With this line
            //    options.ExpireTimeSpan = TimeSpan.FromSeconds(5);
            //});




            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                //Userning emaili unique bo'lish kerak
                options.User.RequireUniqueEmail = true;

                // email confirmation require
                options.SignIn.RequireConfirmedEmail = true;
            })
                              .AddEntityFrameworkStores<ApplicationDbContext>()
                              .AddDefaultTokenProviders();

            //// cookie settings
            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });

            // Add application services.
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            // Add DI for Dotnetdesk
            builder.Services.AddTransient<IDotnetdesk, Dotnetdesk>();

            // Get SendGrid configuration options
            builder.Services.Configure<SendGridOptions>(builder.Configuration.GetSection("SendGridOptions"));

            // Get SMTP configuration options
            builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("SmtpOptions"));

            builder.Services.AddMvc();

            var app = builder.Build();  

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();

            }
            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/error/404";
                    await next();
                }
            });

            //app.UseDatabaseErrorPage();
            //app.UseBrowserLink();

            app.UseExceptionHandler(MVC.Errors.Error500.FullUrl);

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=" + MVC.Pages.ConfigIndex.Controller + "}/{action=" + MVC.Pages.ConfigIndex.Action + "}/{id?}");
            });

            app.Run();
        }
    }
}



