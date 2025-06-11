using Microsoft.FluentUI.AspNetCore.Components;
using FoodShopBilling.Shared.Managers;

namespace FoodShopBilling.UI.Shared.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<DesignThemeModes> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}