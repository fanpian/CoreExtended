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
        /// 生成sha256加密字符串
        /// 没有"-"连接符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="isFile">是否是文件路径;true表示将获取文件SHA256</param>
        /// <returns></returns>
        public static string ToSha256String(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            return SHA256Helper.Generate(str, false);
        }

        /// <summary>
        /// 计算文件的SHA256值
        /// 没有"-"连接符
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isFile"></param>
        /// <returns></returns>
        private static string FileToSha256String(string filePath)
        {
            if (File.Exists(filePath))
            {
                return null;
            }
            return SHA256Helper.Generate(File.ReadAllBytes(filePath));
        }

        /// <summary>
        /// 替换"-"为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceHyphens(this string str)
        {
#if NET5_0_OR_GREATER
            return str?.Replace("-", "", StringComparison.Ordinal);
#else
            return str?.Replace("-", "");
#endif
        }

        /// <summary>
        /// RSA加密
        /// 密钥格式为xml格式
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="publicKey">xml格式公钥.如果公钥为空,则使用默认私钥加密</param>
        /// <returns></returns>
        public static string ToRSAEncryptForXml(this string str, string publicKey = "")
        {
            return RSAHelperForXml.Encrypt(str, publicKey);
        }

        /// <summary>
        /// RSA解密
        /// 密钥格式为xml格式
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="privateKey">xml格式私钥.如果私钥为空,则使用默认私钥加密</param>
        /// <returns></returns>
        public static string ToRSADecryptForXml(this string str, string privateKey = "")
        {
            return RSAHelperForXml.Decrypt(str, privateKey);
        }



        /// <summary>
        /// RSA加密
        /// 密钥格式为PEM格式
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="publicKey">xml格式公钥.如果公钥为空,则使用默认私钥加密</param>
        /// <returns></returns>
        public static string ToRSAEncryptForPEM(this string str, string publicKey = "")
        {
            return RSAHelperForPEM.Encrypt(str, publicKey);
        }

        /// <summary>
        /// RSA解密
        /// 密钥格式为PEM格式
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="privateKey">xml格式私钥.如果私钥为空,则使用默认私钥加密</param>
        /// <returns></returns>
        public static string ToRSADecryptForPEM(this string str, string privateKey = "")
        {
            return RSAHelperForPEM.Decrypt(str, privateKey);
        }
    }
}
