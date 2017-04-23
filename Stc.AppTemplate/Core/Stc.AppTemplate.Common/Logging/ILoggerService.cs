using System;

namespace Stc.AppTemplate.Common.Logging
{
    public interface ILoggerService
    {
        void Log(string message);
        void Log(string message, Exception exception);
    }
}