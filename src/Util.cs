using System;
using System.IO;
using System.Text;

namespace GISBox
{
    /// <summary>
    /// Tool Class, contains static functions
    /// </summary>
    internal class Util
    {
        /// <summary>
        /// convert string to bytes array of specific length
        /// </summary>
        /// <param name="convertedStr">converted string</param>
        /// <param name="bytesLength">the length of bytes array</param>
        /// <returns></returns>
        public static byte[] ConvertStringToBytes(string convertedStr, int bytesLength)
        {
            byte[] resultBytes = new byte[bytesLength];
            byte[] tempBytes = Encoding.UTF8.GetBytes(convertedStr);
            if (tempBytes.Length == bytesLength)
            {
                resultBytes = tempBytes;
            }
            else if (tempBytes.Length > bytesLength)
            {
                Array.ConstrainedCopy(tempBytes, 0, resultBytes, 0, bytesLength);
            }
            else
            {
                Array.ConstrainedCopy(tempBytes, 0, resultBytes, 0, tempBytes.Length);
            }
            return resultBytes;
        }

        /// <summary>
        /// read an int number from binary reader in big endian, and return the number
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static int ReadInt32InBigEndian(BinaryReader br)
        {
            byte[] intBytes = new byte[4];
            for (int i = 3; i >= 0; --i)
            {
                int b = br.ReadByte();
                intBytes[i] = (byte)b;
            }
            return BitConverter.ToInt32(intBytes, 0);
        }

        /// <summary>
        /// write an int number to file in big endian
        /// </summary>
        /// <param name="integer">integer to write</param>
        /// <param name="bw"></param>
        public static void WriteInt32InBigEndian(int integer, BinaryWriter bw)
        {
            byte[] buffer = BitConverter.GetBytes(integer);
            for (int i = 3; i >= 0; --i)
            {
                bw.Write(buffer[i]);
            }
        }

        /// <summary>
        /// return current time in byte[3], formatted as YY-MM-DD
        /// </summary>
        /// <returns></returns>
        public static byte[] CurDateAsBytes()
        {
            byte[] curDate = new byte[3]; 
            curDate[0] = Convert.ToByte(DateTime.Now.Year - 1900);  // Start With 1900
            curDate[1] = Convert.ToByte(DateTime.Now.Month);
            curDate[2] = (byte)(DateTime.Now.Day);
            return curDate;
        }

        
    }
}
