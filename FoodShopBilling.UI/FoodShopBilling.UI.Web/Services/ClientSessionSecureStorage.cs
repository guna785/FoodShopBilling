using Blazored.SessionStorage;
using FoodShopBilling.UI.Shared.Storage;
using System.Security.Claims;

namespace FoodShopBilling.UI.Web.Services
{
    public class ClientSessionSecureStorage : IClientSessionSecureStorage
    {
        private readonly ISessionStorageService _sessionStorageService;
        public ClientSessionSecureStorage(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public async ValueTask ClearAsync(CancellationToken cancellationToken = default) => await _sessionStorageService!.ClearAsync();

        public async ValueTask<bool> ContainKeyAsync(string key, CancellationToken cancellationToken = default) =>await _sessionStorageService.ContainKeyAsync(key, cancellationToken);


        public async ValueTask<string> GetItemAsStringAsync(string key, CancellationToken cancellationToken = default) =>await _sessionStorageService.GetItemAsStringAsync(key, cancellationToken);

        public async ValueTask<T> GetItemAsync<T>(string key, CancellationToken cancellationToken = default) => await _sessionStorageService.GetItemAsync<T>(key, cancellationToken);

        public async ValueTask<string> KeyAsync(int index, CancellationToken cancellationToken = default)=>await _sessionStorageService.KeyAsync(index, cancellationToken);
        public async ValueTask<IEnumerable<string>> KeysAsync(CancellationToken cancellationToken = default) => await _sessionStorageService.KeysAsync(cancellationToken);

        public async ValueTask<int> LengthAsync(CancellationToken cancellationToken = default) => await _sessionStorageService.LengthAsync(cancellationToken);

        public async ValueTask RemoveItemAsync(string key, CancellationToken cancellationToken = default) => await _sessionStorageService.RemoveItemAsync(key, cancellationToken);

        public async ValueTask RemoveItemsAsync(IEnumerable<string> keys, CancellationToken cancellationToken = default)=> await _sessionStorageService.RemoveItemsAsync(keys, cancellationToken);

        public async ValueTask SetItemAsStringAsync(string key, string data, CancellationToken cancellationToken = default) => await _sessionStorageService.SetItemAsStringAsync(key, data, cancellationToken);

        public async ValueTask SetItemAsync<T>(string key, T data, CancellationToken cancellationToken = default) =>await _sessionStorageService.SetItemAsync(key, data, cancellationToken);
    }
}
