
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PizzaOrder.Logger
{
    public static class Logger
    {

        private static ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
        }
    }
}
