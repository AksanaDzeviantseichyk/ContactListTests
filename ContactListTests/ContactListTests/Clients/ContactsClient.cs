using ContactList.Core.HTTP;
using ContactList.Core.HTTP.Base;
using ContactList.Core.Models.Request.Contacts;
using ContactList.Core.Models.Response.Contacts;
using Microsoft.Extensions.Configuration;

namespace ContactList.Core.Clients
{
    public class ContactsClient
    {
        private readonly string _url;
        private readonly HtpClientCustom _client;

        public ContactsClient(IConfiguration configuration, HtpClientCustom client)
        {
            _url = configuration["Url:contactsService"];
            _client = client;
        }

        public async Task<CommonResponse<ContactModelResponse>> AddContact(ContactModelRequest request, string? token = null)
        {
            var httpRequest = new RequestCustom<ContactModelRequest>
            {
                Content = request,
                RequestUri = $"{_url}/contacts",
                Method = HttpMethod.Post,
                Token = token
            };

            var response = await _client.SendAsync<ContactModelRequest, ContactModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<List<ContactModelResponse>>> GetContactList(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/contacts",
                Method = HttpMethod.Get,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, List<ContactModelResponse>>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<ContactModelResponse>> GetContact(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/contacts/",
                Method = HttpMethod.Get,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, ContactModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<ContactModelResponse>> UpdateContact(ContactModelRequest request, string? token = null)
        {
            var httpRequest = new RequestCustom<ContactModelRequest>
            {
                Content = request,
                RequestUri = $"{_url}/contacts/",
                Method = HttpMethod.Put,
                Token = token
            };

            var response = await _client.SendAsync<ContactModelRequest, ContactModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<ContactModelResponse>> UpdateContact(UpdateContactFirstNameRequest request, string? token = null)
        {
            var httpRequest = new RequestCustom<UpdateContactFirstNameRequest>
            {
                Content = request,
                RequestUri = $"{_url}/contacts/",
                Method = HttpMethod.Patch,
                Token = token
            };

            var response = await _client.SendAsync<UpdateContactFirstNameRequest, ContactModelResponse>(httpRequest);

            return response;
        }

        public async Task<CommonResponse<string>> DeleteContact(string? token = null)
        {
            var httpRequest = new RequestCustom<EmptyModel>
            {
                RequestUri = $"{_url}/contacts/",
                Method = HttpMethod.Delete,
                Token = token
            };

            var response = await _client.SendAsync<EmptyModel, string>(httpRequest);

            return response;
        }
    }
}
