using Redstone.Core.Logging;

namespace Redstone.Core
{
    /// <summary>
    /// Enables for easy error detection to determine which errors come from redstone and out.
    /// Also allows for immediate logging.
    /// </summary>
    public class RedstoneException : Exception
    {
        public static void Throw(Severity severity = Severity.Warning)
        {
            throw new RedstoneException(severity);
        }

        public RedstoneException(Severity severity = Severity.Warning) : base()
        {
            Handle(severity);
        }

        public static void Throw(string message, Severity severity = Severity.Warning)
        {
            throw new RedstoneException(message, severity);
        }

        public RedstoneException(string message, Severity severity = Severity.Warning) : base(message)
        {
            Handle(severity);
        }

        public static void Throw(string message, Exception inner, Severity severity = Severity.Warning)
        {
            throw new RedstoneException(message, inner, severity);
        }

        public RedstoneException(string message, Exception inner, Severity severity = Severity.Warning) : base(message, inner)
        {
            Handle(severity);
        }

        public static void Throw(Exception inner, Severity severity = Severity.Warning)
        {
            throw new RedstoneException(inner, severity);
        }

        public RedstoneException(Exception inner, Severity severity = Severity.Warning) : base("", inner)
        {
            Handle(severity);
        }

        private void Handle(Severity severity)
        {
            LogType type = severity switch
            {
                Severity.Warning => LogType.Warning,
                Severity.Error => LogType.Error,
                Severity.Fatal => LogType.Fatal,
                _ => LogType.Warning
            };

            Logger.Log("Exception Thrown: " + Message, type);
            Logger.Log(ToString(), type);

            if (type == LogType.Fatal)
            {
                // Todo - handle immediate shutdown.
            }
        }

        /// <summary>
        /// Throws an inner Argument Null Exception if value is null.
        /// </summary>
        /// <param name="value">The value being checked for null</param>
        /// <param name="severity">The severity of the error in question.</param>
        /// <exception cref="RedstoneException">Will throw a RedstoneException/ArgumentNullException</exception>
        public static void ThrowIfNull(object value, Severity severity = Severity.Warning)
        {
            if (value == null) throw new RedstoneException(new ArgumentNullException(nameof(value)), severity);
            return;
        }
    }

    public enum Severity
    {
        Warning,
        Error,
        Fatal
    }
}
