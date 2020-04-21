using System;
using CoreExtended.Encrypt.RSAEncrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreExtended.Test
{
    [TestClass]
    public class RSATest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "这是一个测试字符串!";
            string encode = RSAExtend.Encode(str);
            string dencode = RSAExtend.Decode(encode);
        }

        /// <summary>
        /// 公钥加密，私钥解密
        /// </summary>
        [TestMethod]
        public void publicKey()
        {
            string publickey = RSAExtend.ToPEM_PKCS8();
            RSA rsa = new RSA(publickey, true);
            string str = rsa.Encode("这是一个测试字符串!");

            string decodeStr = RSAExtend.Decode(str);
        }
    }
}
