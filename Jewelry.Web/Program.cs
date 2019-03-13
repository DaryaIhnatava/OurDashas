// <copyright file="Program.cs" company="no">
// No copies
// </copyright>
namespace Jewelry.Web
{
    #region Usings
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Microsoft.Extensions.Logging.Debug;
    using Microsoft.Extensions.Logging.EventLog;
    #endregion

    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
    {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Build app</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Error))
            //.ConfigureLogging((hostingContext, logging) =>
            //{
               // logging.AddFilter("System", LogLevel.Trace)
               //.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace)
               //.AddFilter<ConsoleLoggerProvider>("System",LogLevel.Trace);
                //logging.ClearProviders();
               // logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //logging.AddDebug(LogLevel.Warning);
                //logging.AddFilter("System", LogLevel.Error);
                //logging.AddConsole(options => options.IncludeScopes = true);
                //logging.AddEventLog();
            //})
            .Build();
    }
}
