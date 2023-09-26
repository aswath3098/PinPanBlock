using System;
using System.Security.Cryptography;
using System.Text;

namespace PinPanBlock
{
    class PinPanBlockCalculator
    {
        public static string CalculatePinPanBlock(string hexString1, string hexString2)
        {
            if (hexString1.Length != hexString2.Length)
                throw new ArgumentException("Input strings must have the same length.");

            char[] result = new char[hexString1.Length];
            for (int i = 0; i < hexString1.Length; i++)
            {
                int value1 = Convert.ToInt32(hexString1[i].ToString(), 16);
                int value2 = Convert.ToInt32(hexString2[i].ToString(), 16);
                int xorResult = value1 ^ value2;
                result[i] = Convert.ToChar(xorResult.ToString("X"));
            }
            return new string(result);
        }
    }
}
