using ContactList.Core.Extensions;
using ContactList.Core.HTTP.Base;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ContactList.Core.HTTP
{
    public class HtpClientCustom
    {
        private readonly HttpClient _client;

        public HtpClientCustom(HttpClient client)
        {
            _client = client;
        }

        public async Task<CommonResponse<TResponse>> SendAsync<TRequest, TResponse>(RequestCustom<TRequest> request)
        {
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri(request.RequestUri),
                Method = request.Method
            };

            if (!string.IsNullOrEmpty(request.Token))
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);
            }

            if (request.Content != null)
            {
                if (request.Content is MultipartFormDataContent formDataContent)
                {
                    httpRequest.Content = formDataContent;
                }
                else
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request.Content), Encoding.UTF8, "application/json");
                }
            }

            var response = await _client.SendAsync(httpRequest);

            var result = await response.ToCommonResponse<TResponse>();

            return result;
        }
    }
}
