using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class LocalizableEntity
    {
        public string EntityAr { get; set; }
        public string EntityEn { get; set; }
        public string GetLocalizedName()
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
