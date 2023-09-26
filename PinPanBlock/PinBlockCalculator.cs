using System;
using System.Security.Cryptography;
using System.Text;

namespace PinPanBlock
{
    class PinBlockCalculator
    {
        public static string CalculatePinBlock(string track2Data, string pin)
        {
            string pinblock = "";
            int len = pin.Length;
            if (len == 4)
            {
                pinblock = "04" + pin;
                pinblock = pinblock.PadRight(16, 'F');
                return pinblock;
            }
            else if (len == 12)
            {
                pinblock = "0C" + pin;
                pinblock = pinblock.PadRight(16, 'F');
                return pinblock;
            }
            return pinblock;
        }
    }
}