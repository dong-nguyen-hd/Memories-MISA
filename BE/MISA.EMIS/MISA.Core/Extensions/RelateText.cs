using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace MISA.Core.Extensions
{
    public static class RelateText
    {
        public static string RemoveSpaceCharacter(this string source)
            => (source is null) ? string.Empty : Regex.Replace(source.Trim(), @"\s{2,}", " ");

        public static string ConcatenateListString(this List<string> source)
        {
            StringBuilder tempText = new StringBuilder();

            foreach (var item in source)
            {
                tempText.AppendLine(item);
            }

            return tempText.ToString();
        }

    }
}
