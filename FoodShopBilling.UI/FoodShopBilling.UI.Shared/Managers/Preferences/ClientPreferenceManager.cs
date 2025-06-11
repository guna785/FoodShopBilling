
using Microsoft.Extensions.Localization;
using Microsoft.FluentUI.AspNetCore.Components;
using FoodShopBilling.Shared.Constants.Storage;
using FoodShopBilling.Shared.Settings;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.UI.Shared.Settings;
using FoodShopBilling.UI.Shared.Storage;

namespace FoodShopBilling.UI.Shared.Managers.Preferences
{
    public class ClientPreferenceManager : IClientPreferenceManager
    {
        private readonly IClientSessionSecureStorage _localStorageService;
        private readonly IStringLocalizer<ClientPreferenceManager> _localizer;

        public ClientPreferenceManager(
            IClientSessionSecureStorage localStorageService,
            IStringLocalizer<ClientPreferenceManager> localizer)
        {
            _localStorageService = localStorageService;
            _localizer = localizer;
        }

        public async Task<bool> ToggleDarkModeAsync()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsDarkMode = !preference.IsDarkMode;
                await SetPreference(preference);
                return !preference.IsDarkMode;
            }

            return false;
        }
        public async Task<bool> ToggleLayoutDirection()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.IsRTL = !preference.IsRTL;
                await SetPreference(preference);
                return preference.IsRTL;
            }
            return false;
        }

        public async Task<IResult> ChangeLanguageAsync(string languageCode)
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                preference.LanguageCode = languageCode;
                await SetPreference(preference);
                return new Result
                {
                    Succeeded = true,
                    Messages = new List<string> { _localizer["Client Language has been changed"] }
                };
            }

            return new Result
            {
                Succeeded = false,
                Messages = new List<string> { _localizer["Failed to get client preferences"] }
            };
        }

        public async Task<DesignThemeModes> GetCurrentThemeAsync()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                if (preference.IsDarkMode == true) return DesignThemeModes.Dark;
            }
            return DesignThemeModes.Light;
        }
        public async Task<bool> IsRTL()
        {
            var preference = await GetPreference() as ClientPreference;
            if (preference != null)
            {
                if (preference.IsDarkMode == true) return false;
            }
            return preference.IsRTL;
        }

        public async Task<IPreference> GetPreference()
        {
            var data = await _localStorageService.GetItemAsStringAsync(StorageConstants.Local.Preference);
            return string.IsNullOrWhiteSpace(data) ? new ClientPreference() : Newtonsoft.Json.JsonConvert.DeserializeObject<ClientPreference>(data);
        }

        public async Task SetPreference(IPreference preference)
        {
            await _localStorageService.SetItemAsStringAsync(StorageConstants.Local.Preference, Newtonsoft.Json.JsonConvert.SerializeObject(preference as ClientPreference));
        }
    }
}