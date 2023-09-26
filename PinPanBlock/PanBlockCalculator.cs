using System;
using System.Security.Cryptography;
using System.Text;

namespace PinPanBlock
{
    class PanBlockCalculator
    {
        public static string CalculatePanBlock(string track2Data)
        {
            string panblock = track2Data.Substring(4, 12);
            panblock = panblock.PadLeft(16, '0');
            return panblock;
        }
    }
}