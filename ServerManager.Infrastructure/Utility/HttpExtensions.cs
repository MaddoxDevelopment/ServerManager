using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ServerManager.Infastructure.Exceptions;

namespace ServerManager.Infastructure.Utility
{
    public static class HttpExtensions
    {
        public static async Task<T> SuccessOrThrow<T>(HttpResponseMessage message, Func<string, T> response = null)
        {
            try
            {
                var content = await message.Content.ReadAsStringAsync();

                if (message.StatusCode >= HttpStatusCode.BadRequest)
                {
                    throw new ProviderApiException(content);
                }

                return response != null ? response(content) : default(T);
            }
            catch (Exception e)
            {
                throw new ProviderApiException(e.Message);
            }
        }
    }
}