using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CoreExtended.Encrypt.RSAEncrypt
{
    public static class RSAExtend
    {
        private static RSA _rsa;
        private static string _privateKey;
        // 2048位加密
        private const string _defaultPrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIIEpAIBAAKCAQEAtzhSIa4Hx2ueThIyesyrXZhgOeB1Pq5OopiKcDWIfRdQtGaA
9JEq102ojgx32S4tb0qR110YjCOjmSEhpZy+17nzqcg5PwxNboVjTRgxrfqKWfAe
Ny8bWNeC3pK35ZDYiibg77i+aM0mpSXlHnpAm68NFpqolpYvRO/v7zC44lxD39RU
Wn9lUWssiC3L6I8K63Gm7T/EwUXdIIbK2gpvjZYXtw5hz1uszfr0Oooc5hI33Zr9
elfp2D029uCmmILKJyNqCRiiw3RNYquN2G8+MqSUBOwhRF4awYcSb4NRnEksMWPS
PFMmjT2mWZMnZa4QAU/532oVIAzDrrBXbTaSewIDAQABAoIBABffS7w9q5/NItwz
PMaJQk64mtkPqNcY6QAAdhE2uGjsD8Thki3LeFSDNtIDR95RSPQ2OBhidd9UiW1b
RsIIUUlUXi4h+2t+k9wxnwWdgGOVwE8FnTo9dge2VMPhQ/qyS7R8alRxssV+7WkZ
Legxr5dZUJBAaHTuboxB4vY8V+qOOGqOc80GaKXw8V8N1JYw1bEY3f7ZlSXtWTCH
8Fci2apo9mL8xOe8NUetiXrYpDyYD+0MtWLHHb5PFFt+6l/Q4GbYdfIgVe3BxdCt
mlb4BtPaKYARXCmRBFyhqe3cCoT5F37E6m1dYRkKWsbrMq1NG8ccyTbjLrNvi5Ek
xHzyDXkCgYEA6EMeElV2Uo2X0geZ0QGulhBVcjKySbaWXldB4M5jj567rvU1wbec
CFvfDD3XR/wsMgVqyteGY9Ms1BpghEOuLZeh7yM1XeszZ4wU5rF/1qefIAgB3Wbk
Igtcvepioo0GHrJGJWnhWLWp7LKW8MJ+CdEjkqanWrXLJAOwpvjm6J0CgYEAyfIR
t2hLEbwxZEae1/lzqYhwNRjSnWI2ZvSlg5JBulSG3FyooWWS0llC0M0OenToQXi2
b4LQjGw7FnwbOZqd3IQ1GNhywIKE9yc470RdWPnyrMsXpeb5ifnFCmTABEM6pO4e
sELn2g+3WNaf07As52RaFUQUy8j0wTHt3Larv/cCgYB2aWF3b2K3i8CPL5jX2ces
cf9eDUKgGhpnVo0bk51mp0KAXDtf28AM8umwUAbliEbv6ZscduzpD8yXBiuWwvqV
++xvAsA+dZ7rd5tgUbYfNa4Goo5w1fgQ80IBAPHwdX1dQP5KLMTaeSN8rUAO1tlz
H9DG/3fq4ywB3G+/cL4ocQKBgQCi/ZSdAjksrEb1FyaXTEe0+mEOCeXbjuw3tpds
FPylxhk+/C5CbbfNvKt32TkpTvgx95rPb7agz631HN/gY1GsLKyqS/B6Ph3RWT/T
pcrtyHa8TgLdLQoU+Zm2JNDx380SVvo/6xA0aODje/5tndDwRYeLiHJ8c8pPr9u6
e1ktywKBgQCxDg04T1GtXEkqbpJ+1ugSzWsQ8k1vJVC4CNGSsZvnp0ta4j65PLjb
QcpoyDuYIXLRSP7nTxIdIL+Q1IXlcYjKSCz7Z9RonP2KNgIyhrF9XNf29IDCrCB4
KgUH2KIsDWjT+iZLBqJSpVF9KA+MSJfBmrTMiZ5EHEAoR7mohktmTA==
-----END RSA PRIVATE KEY-----
";
        /// <summary>
        /// 默认为2048位加密
        /// </summary>
        static RSAExtend()
        {
            Init(_defaultPrivateKey);
        }

        /// <summary>
        /// 初始化
        /// 只有需要更改密钥时才需要在程序执行后执行初始化
        /// </summary>
        /// <param name="privateKey"></param>
        public static void Init(string privateKey)
        {
            _privateKey = privateKey;
            _rsa = new RSA(privateKey, true);
        }

        /// <summary>
        /// 导出XML格式密钥对
        /// 如果convertToPublic含私钥的RSA将只返回公钥
        /// 仅含公钥的RSA不受影响
        /// </summary>
        public static string ToXML(bool convertToPublic = false)
        {
            return _rsa.ToXML(convertToPublic);
        }
        /// <summary>
        /// 导出PEM PKCS#1格式密钥对
        /// 如果convertToPublic含私钥的RSA将只返回公钥
        /// 仅含公钥的RSA不受影响
        /// </summary>
        public static string ToPEM_PKCS1(bool convertToPublic = false)
        {
            return _rsa.ToPEM_PKCS1(convertToPublic);
        }
        /// <summary>
        /// 导出PEM PKCS#8格式密钥对
        /// 如果convertToPublic含私钥的RSA将只返回公钥
        /// 仅含公钥的RSA不受影响
        /// </summary>
        /// <param name="convertToPublic">true->只导出公钥;false->只导出私钥</param>
        public static string ToPEM_PKCS8(bool convertToPublic = false)
        {
            return _rsa.ToPEM_PKCS8(convertToPublic);
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encode(string str)
        {
            return _rsa.Encode(str);
        }

        /// <summary>
        /// 加密字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Encode(byte[] data) 
        {
            return _rsa.Encode(data);
        }

        /// <summary>
        /// 用公钥对字符串进行加密
        /// </summary>
        /// <param name="publicKey">公钥</param>
        /// <param name="encodeStr">需要加密的字符串</param>
        /// <returns></returns>
        public static string Encode(string publicKey, string encodeStr)
        {
            return new RSA(publicKey, false).Encode(encodeStr);
        }

        /// <summary>
        /// 用特定公钥对字符串进行加密
        /// </summary>
        /// <param name="publikKey">公钥</param>
        /// <param name="encodeBytes">需要加密的字节数组</param>
        /// <returns></returns>
        public static byte[] Encode(string publikKey, byte[] encodeBytes)
        {
            return new RSA(publikKey, false).Encode(encodeBytes);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decode(string str)
        {
            return _rsa.DecodeOrNull(str);
        }

        /// <summary>
        /// 解密字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decode(byte[] data)
        {
            return _rsa.DecodeOrNull(data);
        }

        /// <summary>
        /// 获取原始的
        /// </summary>
        /// <returns></returns>
        public static RSACryptoServiceProvider GetRSA()
        {
            return _rsa.GetRSA();
        }
    }
}
