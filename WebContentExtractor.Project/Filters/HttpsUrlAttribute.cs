using System;
using System.ComponentModel.DataAnnotations;

namespace WebContentExtractor.Project.Filters
{
    public class HttpsUrlAttribute : ValidationAttribute
    {
        public override bool IsValid(object url)
        {
            bool isValidUrl = Uri.TryCreate(Convert.ToString(url), UriKind.Absolute, out Uri result) &&
                  (result.Scheme == Uri.UriSchemeHttps);

            if (isValidUrl)
                    return true;
                else
                    return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"The URL should be HTTPS.";
        }
    }
}
