using ContactList.Core.HTTP;
using ContactList.Core.HTTP.Base;
using ContactList.Core.Models.Request.Users;
using ContactList.Core.Models.Response.Users;
using Microsoft.Extensions.Configuration;

namespace ContactList.Core.Clients
{
    public class UsersClient
    {
        private readonly string _url;

        private readonly HtpClientCustom _client;

        public UsersClient(IConfiguration configuration,
            HtpClientCustom client)
        {
            _url = configuration["Url:usersService"];
            _client = client;
        }

        public async Task<CommonResponse<UserInfoResponse>> AddUser(UserModelRequest request)
        {
            var httpRequest = new RequestCustom<UserModelRequest>
            {
                Content = request,
                RequestUri = $"{_url}/users",
                Method = HttpMethod.Post
            };

            var response = await _client.SendAsync<UserModelRequest, UserInfoResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<UserModelResponse>> GetUserProfile(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/users/me",
                Method = HttpMethod.Get,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, UserModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<UserModelResponse>> UpdateUser(UserModelRequest request, string? token = null)
        {
            var httpRequest = new RequestCustom<UserModelRequest>
            {
                Content = request,
                RequestUri = $"{_url}/users/me",
                Method = HttpMethod.Patch,
                Token = token
            };

            var response = await _client.SendAsync<UserModelRequest, UserModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<UserInfoResponse>> Login(LoginRequest request)
        {
            var httpRequest = new RequestCustom<LoginRequest>
            {
                Content = request,
                RequestUri = $"{_url}/users/login",
                Method = HttpMethod.Post
            };

            var response = await _client.SendAsync<LoginRequest, UserInfoResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<EmptyModel>> LogOut(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/users/logout",
                Method = HttpMethod.Post,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, EmptyModel>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<EmptyModel>> DeleteUser(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/users/me",
                Method = HttpMethod.Delete,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, EmptyModel>(httpRequest);

            return response;
        }
    }
}
