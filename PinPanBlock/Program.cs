using System;
using System.Security.Cryptography;
using System.Text;
namespace PinPanBlock
{
    class Program
    {
        static void Main()
        {
            // Data
            string track2Data = ";5351290102107506=21112011557206710000?";
            string pin = "1234";
            string key = "ED2307743BAFC53FA0315C89116BCABF";
            string pinblock = PinBlockCalculator.CalculatePinBlock(track2Data, pin);
            string panblock = PanBlockCalculator.CalculatePanBlock(track2Data);
            string pinpanblock = PinPanBlockCalculator.CalculatePinPanBlock(pinblock, panblock);
            byte[] dataBytes = HexStringToByteArray(pinpanblock);
            byte[] keyBytes = HexStringToByteArray(key);

            // Performing 3DES encryption
            byte[] encryptedData = EncryptionUtility.Encrypt3DES(dataBytes, keyBytes);

            // Convert the encrypted byte array to a hexadecimal string
            string encryptedHex = EncryptionUtility.ByteArrayToHexString(encryptedData);

            // Print the encrypted result
            Console.WriteLine("The Pinblock is:" + pinblock);
            Console.WriteLine("The Panblock is:" + panblock);
            Console.WriteLine("The Non-Encrypted PinPan Block is:" + pinpanblock);
            Console.WriteLine("Encrypted Data: " + encryptedHex);
            Console.ReadKey();
        }

        static byte[] HexStringToByteArray(string hex)
        {
            int byteCount = hex.Length / 2;
            byte[] bytes = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
    }
}