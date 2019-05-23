// <copyright file="Startup.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>

using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

namespace Jewelry.Web
{
    using System.Text;
    using Jewelry.Business.LoginService.Authentication;
    #region Usings
    using Jewelry.Dependencies;
    using Jewelry.Web.ErrorHandle;
    using Jewelry.Web.Middlewares;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    #endregion

    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        #region Private fields
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration configuration;
        #endregion

        #region Contructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }
        #endregion

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = this.configuration.GetConnectionString("DefaultConnection");
            services.AddJewelryBusinessRegistries();
            services.AddJewelryDatabaseRegistries();
            /*services.AddLocalization(options => options.ResourcesPath = "i18n");*/
            //services.AddSingleton<IMemoryCache>();
            services.AddMemoryCache();
            //services.AddMvc()
            //    .AddViewLocalization(
            //        Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.SubFolder,
            //        opts => { opts.ResourcesPath = "Resources"; }
            //    )
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "i18n"; })
                .AddDataAnnotationsLocalization();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/User/Login");
                });

            /*services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supportedCultures = new[]
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("ru-RU")
                    };

                    opts.DefaultRequestCulture = new RequestCulture(new CultureInfo(configuration.GetSection("Culture").Value.ToString()));
                    opts.SupportedCultures = supportedCultures;
                    opts.SupportedUICultures = supportedCultures;
                });*/
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var con = this.configuration.GetConnectionString("DefaultConnection");
            using (this.logger.BeginScope("Some really useful information"))
            {
                this.logger.LogWarning("Oh no.");
            }

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                //app.UseDeveloperExceptionPage();
                app.ConfigureExceptionHandler();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/StatusCode");
                app.UseMvcWithDefaultRoute();
            }
            app.UseMiddleware<ThemeMiddleware>();

            app.MapWhen(
                context => context.Request.Path.ToString().Contains("Report"),
                HandleId);
                
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMiddleware<LocalizationMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private static void HandleId(IApplicationBuilder app)
        {
            app.UseReportMiddleware();
        }
    }
}
