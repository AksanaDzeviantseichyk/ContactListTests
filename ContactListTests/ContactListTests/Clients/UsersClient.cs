using ContactList.Core.HTTP;
using ContactList.Core.HTTP.Base;
using ContactList.Core.Models;
using ContactList.Core.Models.Request;
using ContactList.Core.Models.Response;
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

        public async Task<CommonResponse<UserInfoResponse>> AddUser(AddUserRequest request)
        {
            var httpRequest = new RequestCustom<AddUserRequest>
            {
                Content = request,
                RequestUri = $"{_url}/users",
                Method = HttpMethod.Post
            };

            var response = await _client.SendAsync<AddUserRequest, UserInfoResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<UserModel>> GetUserProfile(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/users/me",
                Method = HttpMethod.Get,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, UserModel>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<UserModel>> UpdateUser(UpdateUserRequest request, string? token = null)
        {
            var httpRequest = new RequestCustom<UpdateUserRequest>
            {
                Content = request,
                RequestUri = $"{_url}/users/me",
                Method = HttpMethod.Patch,
                Token = token
            };

            var response = await _client.SendAsync<UpdateUserRequest, UserModel>(httpRequest);

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
