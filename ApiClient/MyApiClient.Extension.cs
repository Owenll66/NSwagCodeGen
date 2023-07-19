using Microsoft.AspNetCore.Http;

namespace ApiClient
{
    public partial class MyApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyApiClient(string baseUrl, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            BaseUrl = baseUrl;
            _httpClient = httpClient;
            _settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
            _httpContextAccessor = httpContextAccessor;
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            AddToken(request);
        }

        private void AddToken(HttpRequestMessage request)
        {
            var bearerToken = _httpContextAccessor.HttpContext?.Request?.Headers["Authorization"].ToString();

            if (bearerToken != null)
                request.Headers.Add("Authorization", bearerToken);
        }
    }
}
