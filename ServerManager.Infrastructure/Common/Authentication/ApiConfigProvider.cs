namespace ServerManager.Infastructure.Providers.Common.Authentication
{
    public class ApiConfigProvider
    {
        public string Token { get; }
        public string BaseUrl { get; set; }
        public string ProjectId { get; set; }

        public ApiConfigProvider(string token, string baseUrl, string projectId)
        {
            Token = token;
            BaseUrl = baseUrl;
            ProjectId = projectId;
        }
    }
}