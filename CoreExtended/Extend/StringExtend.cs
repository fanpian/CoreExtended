using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreExtended.Extend
{
    public static class StringExtend
    {
        /// <summary>
        /// 字符串如果为NULL、空、空白字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defalut">默认字符串</param>
        /// <returns></returns>
        public static string IfNullOrWhiteSpace(this string str, string defalut)
        {
            return string.IsNullOrWhiteSpace(str) ? defalut : str;
        }

        /// <summary>
        /// 字符串如果为NULL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defalut">默认字符串</param>
        /// <returns></returns>
        public static string IfNull(this string str, string defalut)
        {
            return str == null ? defalut : str;
        }

        /// <summary>
        /// String转成Int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns>失败返回-1</returns>
        public static int ToInt32(this string str)
        {
            int val = 0;
            try
            {
                val = Convert.ToInt32(str);
            }
            catch (Exception e)
            {
                val = -1;
            }
            return val;
        }
    }
}
