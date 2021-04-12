using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoreExtended.Encrypt
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public static class SHA256Encrypt
    {
        /// <summary>
        /// 生成sha256
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Generate(string str)
        {
            return Generate(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>
        /// 生成sha256
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string Generate(byte[] bytes)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] buffer = sha256.ComputeHash(bytes);
#if NET5_0_OR_GREATER
                return BitConverter.ToString(buffer).Replace("-", "", StringComparison.Ordinal);//将字节数组转成16进制字符串
#else
                return BitConverter.ToString(buffer);
#endif
            }
        }
    }
}
