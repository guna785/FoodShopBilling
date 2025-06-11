
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.UI.Shared.Endpoints;
using FoodShopBilling.UI.Shared.Extensions;
using FoodShopBilling.Utilities.Responses.Identity;
using System.Net.Http.Json;

namespace FoodShopBilling.UI.Shared.Managers.Communication
{
    public class ChatManager : IChatManager
    {
        private readonly HttpClient _httpClient;

        public ChatManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId)
        {
            var response = await _httpClient.GetAsync(ChatEndpoint.GetChatHistory(cId));
            var data = await response.ToResult<IEnumerable<ChatHistoryResponse>>();
            return data;
        }

        public async Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync()
        {
            var response = await _httpClient.GetAsync(ChatEndpoint.GetAvailableUsers);
            var data = await response.ToResult<IEnumerable<ChatUserResponse>>();
            return data;
        }

        //public async Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory)
        //{
        //    var response = await _httpClient.PostAsJsonAsync(ChatEndpoint.SaveMessage, chatHistory);
        //    var data = await response.ToResult();
        //    return data;
        //}
    }
}