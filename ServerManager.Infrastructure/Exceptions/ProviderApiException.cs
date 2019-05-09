using System;

namespace ServerManager.Infastructure.Exceptions
{
    public class ProviderApiException : Exception
    {
        public ProviderApiException(string message) : base(message)
        {
        }
    }
}