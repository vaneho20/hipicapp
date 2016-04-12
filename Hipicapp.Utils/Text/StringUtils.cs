using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Hipicapp.Utils.Text
{
    public class StringUtils
    {
        private StringUtils()
        {
            // non instanceable
        }

        public static string NormalizeString(string str)
        {
            string nfdNormalizedString = str.Normalize(NormalizationForm.FormD);
            return new string(nfdNormalizedString.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

        public static string ConcatByHyphen(int length, string str1, string str2, string str3, string str4)
        {
            return String.Concat(String.IsNullOrWhiteSpace(str1) ? string.Empty : (str1.Length < length ? str1 : str1.Substring(0, length)), String.IsNullOrWhiteSpace(str2) ? string.Empty : String.Concat("-", (str2.Length < length ? str2 : str2.Substring(0, length))), String.IsNullOrWhiteSpace(str3) ? string.Empty : String.Concat("-", (str3.Length < length ? str3 : str3.Substring(0, length))), String.IsNullOrWhiteSpace(str4) ? string.Empty : String.Concat("-", (str4.Length < length ? str4 : str4.Substring(0, length))));
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string Capitalize(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
    }
}