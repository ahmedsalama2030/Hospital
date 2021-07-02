using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Areas.Admin.helper;
using Web.Areas.Admin.Hubs;
using Web.Resources;

namespace Web
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
            #region context services
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddInfrastructure(options =>
            {
                options.UseSqlServer(connection);
              });
            #endregion

            services.AddRazorPages();

            #region localization    
 
            services.AddLocalization();
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.EnableEndpointRouting = false;

            }).AddDataAnnotationsLocalization(options => {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(Resource));
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
             AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Home/Index", "/");
                 
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "en", "ar-Eg"  };
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });

            #endregion
            #region message return
            services.AddScoped<MessageResult>();
            #endregion
            #region Hubs
            services.AddSignalR();
            #endregion

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
             }
            else
            {
                  app.UseStatusCodePages(  async context =>
                {
                    var request = context.HttpContext.Request;
                    var response =  context.HttpContext.Response;
                    var path = request.Path.Value ?? "";
                        response.Redirect("/Site-Error");

                 });
                app.UseHsts();
            }
            app.UseRouting();
            
            var cultures = new List<CultureInfo> {
                            new CultureInfo("ar"),
                             new CultureInfo("en")};

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
            app.UseHttpsRedirection();

            app.UseStaticFiles();

             
            app.UseAuthentication();
            app.UseAuthorization();
             app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapRazorPages();
                endpoints.MapHub<AppointmentHub>("/appointmentHub");
            });
        }
    }
}
