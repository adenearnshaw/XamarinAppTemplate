using System;

namespace $safeprojectname$.Logging
{
    public interface ILoggerService
    {
        void Log(string message);
        void Log(string message, Exception exception);
    }
}