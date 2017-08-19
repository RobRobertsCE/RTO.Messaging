using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTO.Messaging;

namespace RTO.Messaging.TestApp
{
    static class Program
    {
        public static ServiceHandler Services { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServiceContainer();
            Application.Run(new Form1());
        }

        static void ConfigureServiceContainer()
        {
            var serviceProvider = new ServiceCollection()
                .AddRTOMessaging()
                .BuildServiceProvider();

            Services = new ServiceHandler(serviceProvider);
        }

        public class ServiceHandler
        {
            public IServiceProvider ServiceProvider { get; private set; }

            public ServiceHandler(IServiceProvider serviceProvider)
            {
                this.ServiceProvider = serviceProvider;
            }
        }
    }
}