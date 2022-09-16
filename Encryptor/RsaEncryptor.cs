using System.Security.Cryptography;
using System.Text;

namespace Encryptor
{
    public class RsaEncryptor
    {
        private RSAParameters publicRsaKey, privateRsaKey;
        private int keyLenght;

        /// <summary>
        /// Creates instance of RsaEncryptor
        /// </summary>
        /// <param name="_keyLenght">
        /// Key lenght in bits
        /// </param>
        public RsaEncryptor(int _keyLenght)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(_keyLenght);
            publicRsaKey = rsa.ExportParameters(false);
            privateRsaKey = rsa.ExportParameters(true);

            keyLenght = _keyLenght;
        }

        /// <summary>
        /// Encrypts byte array with public key
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_publicKey"></param>
        /// <returns>encrypted data in byte array</returns>
        public byte[] encrypt(byte[] _data, RSAParameters _publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keyLenght))
            {
                rsa.ImportParameters(_publicKey);
                return rsa.Encrypt(_data, false);
            }
        }

        /// <summary>
        /// Encrypts string with public key
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_publicKey"></param>
        /// <returns>encrypted data in byte array</returns>
        public byte[] encrypt(string _data, RSAParameters _publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keyLenght))
            {
                rsa.ImportParameters(_publicKey);
                return rsa.Encrypt(Encoding.ASCII.GetBytes(_data), false);
            }
        }

        /// <summary>
        /// Decrypts byte array with private key
        /// </summary>
        /// <param name="_encryptedMessage"></param>
        /// <param name="_privateKey"></param>
        /// <returns>decrypted data in byte array</returns>
        public byte[] decrypt(byte[] _encryptedMessage, RSAParameters _privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keyLenght))
            {
                rsa.ImportParameters(_privateKey);
                return rsa.Decrypt(_encryptedMessage, false);
            }
        }

        /// <summary>
        /// Decrypts byte array with saved private key
        /// </summary>
        /// <param name="_encryptedMessage"></param>
        /// <returns>decrypted data in byte array</returns>
        public byte[] decrypt(byte[] _encryptedMessage)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keyLenght))
            {
                rsa.ImportParameters(privateRsaKey);
                return rsa.Decrypt(_encryptedMessage, false);
            }
        }

        /// <summary>
        /// Decrypts byte array with saved private key and automatically converts it into string
        /// </summary>
        /// <param name="_encryptedMessage"></param>
        /// <returns>decrypted string</returns>
        public string decryptString(byte[] _encryptedMessage) => Encoding.ASCII.GetString(decrypt(_encryptedMessage));

        /// <summary>
        /// Decrypts byte array with private key and automatically converts it into string
        /// </summary>
        /// <param name="_encryptedMessage"></param>
        /// <param name="_privateKey"></param>
        /// <returns>decrypted string</returns>
        public string decryptString(byte[] _encryptedMessage, RSAParameters _privateKey) => Encoding.ASCII.GetString(decrypt(_encryptedMessage, _privateKey));

        /// <returns>public key</returns>
        public RSAParameters GetPublicKey() => publicRsaKey;

        /// <returns>private key</returns>
        public RSAParameters GetPrivateKey() => privateRsaKey;
    }
}
