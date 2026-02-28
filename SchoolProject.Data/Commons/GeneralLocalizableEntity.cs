using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public static class GeneralLocalizableEntity
    {
        public static string GetLocalizedName(string EntityAr, string EntityEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            string cultureName = culture.TwoLetterISOLanguageName.ToLower();

            return cultureName switch
            {
                "ar" => EntityAr,
                "en" => EntityEn,
                _ => EntityEn, // Default to English if culture is not recognized
            };
        }
    }
}
