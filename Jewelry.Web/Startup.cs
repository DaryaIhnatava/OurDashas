// <copyright file="Startup.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web
{
    #region Usings
    using System.IO;
    using Jewelry.Dependencies;
    using Jewelry.Web.Logger;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
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
            services.AddMvc();
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var con = this.configuration.GetConnectionString("DefaultConnection");
            //loggerFactory.AddConsole(includeScopes: true);
            // loggerFactory.AddConsole((category, loglevel) => (category=="System" && loglevel >= LogLevel.Error));
            //loggerFactory.AddDebug(LogLevel.Warning);
            using (logger.BeginScope("Some really useful information"))
            {
                // something something

                logger.LogWarning("Oh no.");
            }
            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //var Llogger = loggerFactory.CreateLogger("FileLogger");
            //Llogger.LogWarning("FileWarning!");
            //logger.LogWarning("DEBUG WAAAAARNING!!!!!!!!!!!!!!!!!");
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
