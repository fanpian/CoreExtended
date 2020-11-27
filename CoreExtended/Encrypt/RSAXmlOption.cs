using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoreExtended.Encrypt
{
    /// <summary>
    /// RSA的xml方式加解密
    /// </summary>
    public static class RSAXmlOption
    {
        /// <summary>
        /// 默认的私钥常量
        /// </summary>
        private const string defaultPrivateKey = @"<RSAKeyValue><Modulus>+mi7prHIFKduUubCoIMdB/k/LAPw9VY3nuQhxHvEtz7dAhAXVnZmYs2KC69eCWkG10vjhOp4OF3tXYtHElCHYqPVpcZ+gKRWOMdOkGyKUqousgUwyvU8zspL1d+j8vNioiAmYe2VBIFihJcLxdF1J71jNUI16G1kfd5HyPCPw6E=</Modulus><Exponent>AQAB</Exponent><P>+wQoe2UVhnpXWJqRceAJmJgWZ1V+nzkWYLlJ+HQs/UiEfbjBpm/NB/biSxlYL8KyOhxR6Sp07wsv5ke9wxMRTw==</P><Q>/2F9MFqNy32euMT0W2RYz1xWOH576QacHQ/mWYvyeCcigyivGN5tFzFKQqboePD2GKZB83Bt50zGDjTUzIJADw==</Q><DP>eYrA40bFznCsnH1zUXVOkDGMH4rZHdWxjTIKrB/srNORO6LbOXDHEUUsu3pRJgca72JJEyJ4rkp3bgRs0OkJpw==</DP><DQ>lDhr5WWZSJLHTWwaevS5ythHvpBCsJPCheeVhUGBYBUupbs2LRPjcwOLmzWuVYtc+h98xaLqVsWradFl9LBgJw==</DQ><InverseQ>4MJcGjJ9NdzDGjbZNXlikPU9CzDf9MwgIlzg+xBPPMGtRA/BM+0Bun1dbMIfkKbxij+dOnfypxgPABxeFNwDvg==</InverseQ><D>e5YfLylFH3R3DbFYU1ICjQHlvLqBPQR9VQ0w4UFYmDwNZcw9SG4NICxjOlsl5S0RtEZ/FwWFqgQpd2abAB4AgqN9ZH/OvXq+jNwwCyUKpoZ5LfDV+wQfc80LGdwrA+GAf5IyO3pkc9RBCVwlCqZPwawFdUKpXPvsslOf+MmqMaU=</D></RSAKeyValue>";


        /// <summary>
        /// 创建RSA
        /// </summary>
        /// <param name="xml">私钥或者公钥</param>
        /// <returns></returns>
        public static RSACryptoServiceProvider Create(string xml)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xml);
            return rsa;
        }

        /// <summary>
        /// 分段加密不限长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="publicXml"></param>
        /// <returns></returns>
        public static string Encrypt(string str, string publicXml = "")
        {
            string key = publicXml;
            if (string.IsNullOrWhiteSpace(key))
            {
                using (RSACryptoServiceProvider rsa = Create(defaultPrivateKey)) 
                {
                    key = rsa.ToXmlString(false);
                }
            }
            using (RSACryptoServiceProvider encryptRSA = Create(key))
            {
                int max = (encryptRSA.KeySize / 8) - 11;
                byte[] strBytes = Encoding.UTF8.GetBytes(str);
                byte[] buffer = new byte[max];
                using (MemoryStream memory = new MemoryStream(strBytes),
                   output = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = memory.Read(buffer, 0, max);
                        if (readSize <= 0) {
                            break;
                        }
                        byte[] temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        byte[] encryptBytes = encryptRSA.Encrypt(temp, false);
                        output.Write(encryptBytes, 0, encryptBytes.Length);
                    }
                    return Convert.ToBase64String(output.ToArray());
                }
            }
        }

        /// <summary>
        /// 分段解密不限长度
        /// </summary>
        /// <param name="encryptStr">加密字符串</param>
        /// <param name="privateXml">私钥;如果为空则使用默认值</param>
        /// <returns></returns>
        public static string Decrypt(string encryptStr, string privateXml = "") 
        {
            using (RSACryptoServiceProvider rsa = Create(string.IsNullOrWhiteSpace(privateXml) ? defaultPrivateKey : privateXml))
            {
                byte[] encryptBytes = Convert.FromBase64String(encryptStr);
                int max = rsa.KeySize / 8;
                byte[] buffer = new byte[max];
                using (MemoryStream memory = new MemoryStream(encryptBytes),
                   output = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = memory.Read(buffer, 0, max);
                        if (readSize <= 0) 
                        {
                            break;
                        }
                        byte[] temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        byte[] decrypts = rsa.Decrypt(temp, false);
                        output.Write(decrypts, 0, decrypts.Length);
                    }
                    return Encoding.UTF8.GetString(output.ToArray());
                }
            }
        }
    }
}
