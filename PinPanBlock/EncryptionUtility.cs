using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PinPanBlock
{
    class EncryptionUtility
    {
        public static byte[] Encrypt3DES(byte[] data, byte[] key)
        {
            using (TripleDESCryptoServiceProvider desProvider = new TripleDESCryptoServiceProvider())
            {
                // Set the encryption mode and padding
                desProvider.Mode = CipherMode.ECB;
                desProvider.Padding = PaddingMode.None;

                // Set the provided key
                desProvider.Key = key;

                // Create the encryptor
                ICryptoTransform encryptor = desProvider.CreateEncryptor();

                // Encrypt the data
                return encryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:X2}", b);
            }
            return hex.ToString();
        }
    }
}
