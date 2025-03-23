using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Domain.Regex;

namespace Clean.DDD.Architecture.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class StringExtension
    {
        public static bool IsNumeric(this string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return false;
            }

            bool isNumeric = false;

            if (int.TryParse(txt, out _))
            {
                isNumeric = true;
            }
            else if (long.TryParse(txt, out _))
            {
                isNumeric = true;
            }
            else if (double.TryParse(txt, out _))
            {
                isNumeric = true;
            }
            else if (decimal.TryParse(txt, out _))
            {
                isNumeric = true;
            }

            return isNumeric;
        }

        public static string ReplaceSpecialCharacters(this string fullName)
        {
            var returnString = string.Empty;

            if (!string.IsNullOrEmpty(fullName))
            {
                fullName = fullName.Replace('Á', 'A');
                fullName = fullName.Replace('É', 'E');
                fullName = fullName.Replace('Í', 'I');
                fullName = fullName.Replace('Ó', 'O');
                fullName = fullName.Replace('Ú', 'U');
                fullName = fullName.Replace('á', 'A');
                fullName = fullName.Replace('é', 'E');
                fullName = fullName.Replace('í', 'I');
                fullName = fullName.Replace('ó', 'O');
                fullName = fullName.Replace('ú', 'U');

                fullName = fullName.Replace('Ä', 'A');
                fullName = fullName.Replace('Ë', 'E');
                fullName = fullName.Replace('Ï', 'I');
                fullName = fullName.Replace('Ö', 'O');
                fullName = fullName.Replace('Ü', 'U');
                fullName = fullName.Replace('ä', 'A');
                fullName = fullName.Replace('ë', 'E');
                fullName = fullName.Replace('ï', 'I');
                fullName = fullName.Replace('ö', 'O');
                fullName = fullName.Replace('ü', 'U');

                fullName = fullName.Replace('À', 'A');
                fullName = fullName.Replace('È', 'E');
                fullName = fullName.Replace('Ì', 'I');
                fullName = fullName.Replace('Ò', 'O');
                fullName = fullName.Replace('Ù', 'U');
                fullName = fullName.Replace('à', 'A');
                fullName = fullName.Replace('è', 'E');
                fullName = fullName.Replace('ì', 'I');
                fullName = fullName.Replace('ò', 'O');
                fullName = fullName.Replace('ù', 'U');

                fullName = fullName.Replace('Â', 'A');
                fullName = fullName.Replace('Ê', 'E');
                fullName = fullName.Replace('Î', 'I');
                fullName = fullName.Replace('Ô', 'O');
                fullName = fullName.Replace('Û', 'U');
                fullName = fullName.Replace('â', 'A');
                fullName = fullName.Replace('ê', 'E');
                fullName = fullName.Replace('î', 'I');
                fullName = fullName.Replace('ô', 'O');
                fullName = fullName.Replace('û', 'U');

                var replaceRegex = RegexPatterns.ReplaceStringRegex();
                fullName = replaceRegex.Replace(fullName, " ");

                returnString = fullName.ToLower();
            }

            return returnString;
        }

        public static string GetReplaceSpecialCharacters(this string fullName)
        {
            return $"{fullName} COLLATE SQL_Latin1_General_CP1_CI_AI";
        }
    }
}
