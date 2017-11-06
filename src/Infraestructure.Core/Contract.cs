using System;

namespace Infraestructure.Core
{
    public static class Contract
    {
        public static void Requires<TException>(bool condition, string message) where TException : Exception
        {
            if (condition)
            {
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                throw Activator.CreateInstance<TException>();
            }

            if (Activator.CreateInstance(typeof(TException), message) is TException exception)
            {
                throw exception;
            }

            throw new InvalidOperationException(string.Format("Método Contract.Requires não conseguir instanciar a excessão do tipo {0}.",
                typeof(TException).Name));
        }

        public static void Requires<TException>(bool condition) where TException : Exception
        {
            Requires<TException>(condition, null);
        }

        public static void ArgumentNullValidation(object @object, string argumentName)
        {
            if (ReferenceEquals(@object, null))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}