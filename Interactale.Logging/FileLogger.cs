using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;

namespace Interactale.Logging
{
    public class FileLogger : IFileLogger
    {
        public ILogger Logger { get; set; }

        public FileLogger(ILogger logger)
        {
            this.Logger = logger;
        }

        public void Warn(string message)
        {
            this.Logger.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            this.Logger.Warn(message, exception);
        }

        public void Info(string message)
        {
            this.Logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            this.Logger.Info(message, exception);
        }

        public void Fatal(string message)
        {
            this.Logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            this.Logger.Fatal(message, exception);
        }

        public void Error(string message)
        {
            this.Logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            this.Logger.Error(message, exception);
        }

        public void Debug(string message)
        {
            this.Logger.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            this.Logger.Debug(message, exception);
        }
    }
}
