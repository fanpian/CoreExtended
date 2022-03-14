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
        /// 公钥加密，私钥解密
        /// </summary>
        [TestMethod]
        public void publicKey()
        {
            string publickey = RSAHelperForPEM.GeneratePublicPEM(true, _defaultPrivateKey);
            CoreExtended.Encrypt.RSAEncrypt.RSA rsa = new CoreExtended.Encrypt.RSAEncrypt.RSA(_defaultPrivateKey, true);
            string str = rsa.Encode("乐凯医疗科技有限公司-云影像平台");
            
            string decodeStr = rsa.DecodeOrNull(str);

            string en = RSAHelperForPEM.Encrypt("乐凯医疗科技有限公司-云影像平台", publickey);

            string de = RSAHelperForPEM.Decrypt(en, _defaultPrivateKey);
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
            string encryptStr = RSAHelperForXml.Encrypt("乐凯医疗科技有限公司 - 云影像平台");

            string str = RSAHelperForXml.Decrypt(encryptStr);
        }

        [TestMethod]
        public void Sha()
        {
            string temp = SHA256Helper.Generate("123465");
        }
    }
}
