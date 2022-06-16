using System;
using System.IO;
using System.Text;

namespace GISBox
{
    /// <summary>
    /// 工具类 自定义静态函数
    /// </summary>
    internal class Util
    {
        /// <summary>
        /// 将字符串转换为指定大小的字节数组
        /// </summary>
        /// <param name="convertedStr">待转换的字符串</param>
        /// <param name="bytesLength">字节数组的长度</param>
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
        /// 以大端序读取 uint 整数
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static uint ReadBigEndianUInt32(BinaryReader br)
        {
            byte[] intBytes = new byte[4];
            for (int i = 3; i >= 0; --i)
            {
                int b = br.ReadByte();
                intBytes[i] = (byte)b;
            }
            return BitConverter.ToUInt32(intBytes, 0);
        }

        /// <summary>
        /// 返回当前时间，用三个字节表示
        /// </summary>
        /// <returns></returns>
        public static byte[] CurDateAsBytes()
        {
            byte[] curDate = new byte[3];   //接下来3个字节写入修改时的年月日
            curDate[0] = Convert.ToByte(DateTime.Now.Year - 1900);  //年要减去1900
            curDate[1] = Convert.ToByte(DateTime.Now.Month);
            curDate[2] = (byte)(DateTime.Now.Day);
            return curDate;
        }
    }
}
