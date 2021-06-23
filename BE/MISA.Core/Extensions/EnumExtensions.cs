using System.ComponentModel;
using System.Reflection;

namespace MISA.Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Sử dụng reflection lấy Description của enum
        /// </summary>
        /// <typeparam name="TEnum">Kiểu enum</typeparam>
        /// <param name="enum">Đối tượng enum</param>
        /// <returns>Giá trị string của description enum</returns>
        /// CreatedBy: NDDONG (15/06/2021)
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes?[0].Description ?? @enum.ToString().ToLower();
        }
    }
}
