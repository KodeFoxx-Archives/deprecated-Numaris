using System;
using System.Linq;
using System.Text;

namespace Kf.Numaris.Api.Common
{
    public sealed class UnsupportedInterfaceException : Exception
    {
        public UnsupportedInterfaceException(
            string message = null,
            params Type[] supportedInterfaces
        ) : base(FormatExceptionMessage(message, supportedInterfaces)) { }

        private static string FormatExceptionMessage(
            string message = null,
            params Type[] supportedInterfaces)
        {
            var exceptionMessage = new StringBuilder();

            if (message != null)
                exceptionMessage.Append("The interface used in the calling member is not supported.");
            else
                exceptionMessage.Append(message);

            if (supportedInterfaces != null && supportedInterfaces.Length > 0)
                exceptionMessage.Append(
                    $"The interfaces supported are {String.Join(", ", supportedInterfaces.Select(t => t.Name))}."
                );

            return exceptionMessage.ToString();
        }
    }
}
