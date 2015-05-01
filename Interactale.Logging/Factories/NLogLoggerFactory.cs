using System;
using System.Configuration;
using Castle.Core.Logging;
using Castle.Services.Logging.NLogIntegration;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Interactale.Logging.Factories
{
    public class NLogLoggerFactory : NLogFactory
    {
        public NLogLoggerFactory() : base(true)
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget
            {
                FileName = "${basedir}/Logs/" 
                            + ConfigurationManager.AppSettings["LoggerFolderName"] 
                            + "/" + ConfigurationManager.AppSettings["LoggerFileName"] 
                            + "-${date:format=yyyyMMddHH}.log",
                ArchiveEvery = FileArchivePeriod.Day,
                Name = "file",
                Layout = "LOG | ${date:format=yyyyMMddHHmmss} | Thread: ${threadid} | Level: ${level}"
                         + "${newline}-----------------------------${newline}"
                         + "${message}${onexception:inner=${newline}${exception:format=tostring}}"
                         + "${newline}-----------------------------${newline}"
            };
            config.AddTarget("file", fileTarget);
            var rule1 = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule1);
            LogManager.Configuration = config;
        }

        public override ILogger Create(Type type)
        {
            var logger = LogManager.GetLogger("NLogLogger");
            return new NLogLogger(logger, this);
        }

        public override ILogger Create(string name)
        {
            var logger = LogManager.GetLogger("NLogLogger");
            return new NLogLogger(logger, this);
        }


    }
}
