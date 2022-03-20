using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSKH_SSP.Helpers;
using CSKH_SSP.Services;
using CSKH_SSP.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using CSKH_SSP.Services.Request.RequestContent;
using CSKH_SSP.Interfaces.ICheckPermission;
using CSKH_SSP.Services.CheckPermission;
using CSKH_SSP.Interfaces.ICountRequest;
using CSKH_SSP.Services.CountRequest;
using CSKH_SSP.Services.HelpersServices;
using CSKH_SSP.Interfaces.IHelpersServices;
using CSKH_SSP.Interfaces.IModalsServices;
using CSKH_SSP.Services.ModalsServices;
using CSKH_SSP.Interfaces.IAddNewRequestServices;
using CSKH_SSP.Services.AddNewRequestServices;
using CSKH_SSP.Interfaces.IRequestActionServices;
using CSKH_SSP.Services.RequestActionServices;
using CSKH_SSP.Interfaces.INotificationsServices;
using CSKH_SSP.Services.NotificationsServices;
using CSKH_SSP.Interfaces.ISendEmailServices;
using CSKH_SSP.Services.SendEmailServices;
using CSKH_SSP.Interfaces.ITicketServices;
using CSKH_SSP.Services.TicketServices;
using CSKH_SSP.Interfaces.INotificationRealtimeService;
using CSKH_SSP.Services.RealtimeServices;
using CSKH_SSP.Interfaces.IAdminServices;
using CSKH_SSP.Services.AdminServices;
using CSKH_SSP.Services.CountUserOnline;
using CSKH_SSP.Interfaces.ICountUserOnlineService;
using CSKH_SSP.Interfaces.IAdminActionServices;
using CSKH_SSP.Interfaces.IStatisticalServices;
using CSKH_SSP.Services.StatisticalServices;
using CSKH_SSP.Interfaces.IIncidentRequestServices;
using CSKH_SSP.Services.IncidentRequestServices;
using CSKH_SSP.Services.CategoryServices;
using CSKH_SSP.Interfaces.ICategoryServices;
using CSKH_SSP.Interfaces.IQuestionsService;
using CSKH_SSP.Services.QuestionServices;

namespace CSKH_SSP
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
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Login/Login";
        opt.Cookie.Name = "DangNhap";
        opt.ExpireTimeSpan = TimeSpan.FromMinutes(1440);
    });
            services.AddDbContext<MemberContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("MemberConnection")));

            services.AddDbContext<DataContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ILoginServices, LoginServices>();
            services.AddTransient<IRequestListServices, RequestListServices>();
            services.AddTransient<ICheckGroupUserPermissionServices, CheckGroupUserPermissionServices>();
            services.AddTransient<IHelpersServices, HelpersServices>();
            services.AddTransient<IRequestContentHeaderServices, RequestContentHeaderServices>();
            services.AddTransient<IModalsServices, ModalsServices>();
            services.AddTransient<IRequestContentBodyServices, RequestContentBodyServices>();
            services.AddTransient<ICountRequestServices, CountRequestServices>();
            services.AddTransient<IAddNewRequestServices, AddNewRequestServices>();
            services.AddTransient<ICheckRequestPermissionServices, CheckRequestPermissionServices>();
            services.AddTransient<IRequestActionServices, RequestActionServices>();
            services.AddTransient<INotificationServices, NotificationServices>();
            services.AddTransient<ISendEmailServices, SendEmailServices>();
            services.AddTransient<ITicketServices, TicketServices>();
            services.AddTransient<INotificationRealtime, NotificationRealtime>();
            services.AddTransient<IUserManagementServices, UserManagementServices>();
            services.AddTransient<IStatisticServices, StatisticServices>();
            services.AddTransient<ICountUserOnlineService, CountUserOnlineService>();
            services.AddTransient<IAdminActionServices, AdminActionServices>();
            services.AddTransient<IStatisticalServices, StatisticalServices>();
            services.AddTransient<IIncidentRequestServices, IncidentRequestServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<ICommonQuestionService,QuestionService >();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(1440);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithOrigins("https://ticket.vntt.com.vn")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseDeveloperExceptionPage();
            //app.UseSignalR(config => {
            //    config.MapHub<SignalServer>("/RealtimeNotification");
            //    config.MapHub<CountUserOnline>("/WhoOnline");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<SignalServer>("/RealtimeNotification");
                endpoints.MapHub<CountUserOnline>("/UpdateWhoIsOnline");
                
            });
        }
    }
}
