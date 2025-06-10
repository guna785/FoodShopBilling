using FoodShopBilling.Shared.Constants.Localization;
using FoodShopBilling.Shared.Settings;

namespace FoodShopBilling.UI.Web.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}
