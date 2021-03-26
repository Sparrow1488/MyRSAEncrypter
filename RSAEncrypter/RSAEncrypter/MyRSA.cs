using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace RSAEncrypter
{
    public static class MyRSA
    {
        public static byte[] EncryptData(byte[] data, RSAParameters publicKey)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(publicKey);
            var _encryptData = csp.Encrypt(data, false);
            return _encryptData;
        }
        public static byte[] DecryptData(byte[] data, RSAParameters privateKey)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(privateKey);
            var _decryptData = csp.Decrypt(data, false);
            return _decryptData;
        }
        public static string RsaToString(RSAParameters key)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, key);
            string stringKey = sw.ToString();
            return stringKey;
        }
        public static RSAParameters StringToRsa(string key)
        {
            var sr = new StringReader(key);
            var xmlDeserializer = new XmlSerializer(typeof(RSAParameters));
            var rsaKey = (RSAParameters)xmlDeserializer.Deserialize(sr);
            return rsaKey;
        }
    }
}
