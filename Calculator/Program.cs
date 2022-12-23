using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculatorWorker worker = new CalculatorWorker();
            Calculator calc = new Calculator(worker);
            int result = calc.Subtract(20, 10);
            Console.WriteLine(result);
            // var services = ConfigureServices();

            //  var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            // serviceProvider.GetService<App>().Run();
        }
        /*
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            //var config = LoadConfiguration();
            //services.AddSingleton(config);

            services.AddTransient(typeof(ICalculatorWorker), typeof(LoggingCalculatorWorker));

            // required to run the application
            services.AddTransient<App>();

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }*/
    }
}
