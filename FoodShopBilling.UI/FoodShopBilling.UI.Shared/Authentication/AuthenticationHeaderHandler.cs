
using FoodShopBilling.Shared.Constants.Storage;
using FoodShopBilling.UI.Shared.Storage;
using System.Net.Http.Headers;

namespace FoodShopBilling.UI.Shared.Authentication
{
    public class AuthenticationHeaderHandler : DelegatingHandler
    {
        private readonly IClientSessionSecureStorage localStorage;

        public AuthenticationHeaderHandler(IClientSessionSecureStorage localStorage)
            => this.localStorage = localStorage;

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization?.Scheme != "Bearer")
            {
                var savedToken = await this.localStorage.GetItemAsStringAsync(StorageConstants.Local.AuthToken);

                if (!string.IsNullOrWhiteSpace(savedToken))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}