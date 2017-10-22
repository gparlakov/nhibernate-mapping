using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LoggerFactory : NHibernate.ILoggerFactory
    {
        public IInternalLogger LoggerFor(Type type)
        {
            return new Logger();
        }

        public IInternalLogger LoggerFor(string keyName)
        {
            return new Logger();
        }
    }

    public class Logger : IInternalLogger
    {
        public bool IsDebugEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return false;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return true;
            }
        }

        public void Debug(object message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Debug(object message, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("{0}\n{1}", message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format, args);
        }

        public void Error(object message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Error(object message, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("{0}\n{1}", message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format, args);
        }

        public void Fatal(object message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Fatal(object message, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("{0}\n{1}", message, exception);
        }

        public void Info(object message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Info(object message, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("{0}\n{1}", message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format, args);
        }

        public void Warn(object message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Warn(object message, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("{0}\n{1}", message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine(format, args);
        }
    }
}
