using System;
using System.IO;
using CoreExtended.Encrypt.RSAEncrypt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreExtended.Extend;
using System.Security.Cryptography;
using CoreExtended.Encrypt;

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
            CoreExtended.Encrypt.RSAEncrypt.RSA rsa = new CoreExtended.Encrypt.RSAEncrypt.RSA(publickey, true);
            string str = rsa.Encode("乐凯医疗科技有限公司-云影像平台");

            string decodeStr = RSAExtend.Decode(str);
        }

        [TestMethod]
        public void CreatePrivateKey()
        {
            string privateFile = Path.Combine(@"C:\Users\fp532\Desktop", "privateKey.xml");
            string publicFile = Path.Combine(@"C:\Users\fp532\Desktop", "publicKey.xml");
            RSACryptoServiceProvider ras = new RSACryptoServiceProvider();
            string privateKey = ras.ToXmlString(true);
            File.WriteAllText(privateFile, privateKey);
            string publicKey = ras.ToXmlString(false);
            File.WriteAllText(publicFile, publicKey);
        }

        [TestMethod]
        public void Decrypt()
        {
            string encryptStr = RSAXmlOption.Encrypt("乐凯医疗科技有限公司 - 云影像平台");

            string str = RSAXmlOption.Decrypt(encryptStr);
        }
    }
}
