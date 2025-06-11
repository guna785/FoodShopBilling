namespace FoodShopBilling.UI.Shared.Extensions
{
    public static class StringExtentions
    {
        public static string ToUpperSafe(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            else
            {
                return value.ToUpper();
            }
        }
        public static T ToObjectUpper<T>(this T obj) where T : class
        {
            if (obj != null)
            {
                var prop = obj.GetType().GetProperties().Where(x => x.PropertyType == typeof(string));
                foreach (var property in prop)
                {
                    if (property.Name != "ProfilePicture" && property.Name != "VisitorImage")
                    {
                        var data = property.GetValue(obj, null);
                        if (data != null)
                        {
                            string d = data.ToString().ToUpperInvariant();
                            property.SetValue(obj, d, null);
                        }
                    }

                }
            }
            return obj;
        }

    }
}
