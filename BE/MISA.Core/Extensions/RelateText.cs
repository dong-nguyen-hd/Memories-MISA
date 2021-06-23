using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace MISA.Core.Extensions
{
    /// <summary>
    /// Lớp tĩnh: liên quan tới xử lí string
    /// </summary>
    /// CreatedBy: NDDONG (15/06/2021)
    public static class RelateText
    {
        /// <summary>
        /// Extension method: loại bỏ tất cả khoảng trắng dư thừa
        /// </summary>
        /// <param name="source">String cần loại bỏ khoảng trắng</param>
        /// <returns>String sau khi được loại bỏ khoảng trắng</returns>
        /// CreatedBy: NDDONG (15/06/2021)
        public static string RemoveSpaceCharacter(this string source)
            => (source is null) ? string.Empty : Regex.Replace(source.Trim(), @"\s{2,}", " ");

        /// <summary>
        /// Extension method: nối một List<string> thành string
        /// </summary>
        /// <param name="source">List<string> đầu vào</param>
        /// <returns>String trả về</returns>
        /// CreatedBy: NDDONG (15/06/2021)
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
