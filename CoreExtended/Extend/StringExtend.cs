using CoreExtended.Encrypt;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string IfNullOrWhiteSpace(this string str, string defaultVal)
        {
            return string.IsNullOrWhiteSpace(str) ? defaultVal : str;
        }

        /// <summary>
        /// 字符串如果为NULL
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal">默认字符串</param>
        /// <returns></returns>
        public static string IfNull(this string str, string defaultVal)
        {
            return str == null ? defaultVal : str;
        }

        /// <summary>
        /// String转成Int类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal">默认值</param>
        /// <returns>失败返回-1</returns>
        public static int ToInt32(this string str, int defaultVal)
        {
            if (!int.TryParse(str, out int result))
            {
                result = defaultVal;
            }
            return result;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] ReadFile(this string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return null;
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);
                return buffur;
            }
        }

        /// <summary>
        /// 生成sha256加密字符串
        /// </summary>
        /// <param name="stc"></param>
        /// <returns></returns>
        public static string ToSha256String(this string str)
        {
            return SHA256Encrypt.Generate(str);
        }
    }
}
