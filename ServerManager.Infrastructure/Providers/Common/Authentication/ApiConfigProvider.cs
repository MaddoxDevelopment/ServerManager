namespace ServerManager.Infastructure.Providers.Common.Authentication
{
    public class ApiConfigProvider
    {
        public string Token { get; }
        public string BaseUrl { get; set; }

        public ApiConfigProvider(string token, string baseUrl)
        {
            Token = token;
            BaseUrl = baseUrl;
        }
    }
}