

using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.UI.Shared.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        //Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}