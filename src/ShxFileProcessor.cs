using System.Collections.Generic;
using System.IO;

namespace GISBox
{
    /// <summary>
    /// 从 shx 文件读取数据并对数据进行管理
    /// shx 文件中以 16-bit 为单位
    /// 此类中以 byte=8-bit 为单位
    /// </summary>
    public class ShxFileProcessor
    {
        #region 字段

        private long _recordCount;
        private List<uint> _recordOffsets = new List<uint>();
        private List<uint> _recordLengths = new List<uint>();

        #endregion

        #region 构造函数

        public ShxFileProcessor(BinaryReader br)
        {
            br.BaseStream.Seek(100, SeekOrigin.Begin);  //跳过文件头
            _recordCount = (br.BaseStream.Length - 100) / 8;
            while (true)
            {
                try
                {
                    _recordOffsets.Add(Util.ReadBigEndianUInt32(br) * 2);  //以 byte 为单位，故需×2
                    _recordLengths.Add(Util.ReadBigEndianUInt32(br) * 2);
                }
                catch (IOException)
                {
                    break;  //读到文件尾
                }
            }
        }

        #endregion

        #region 属性
        /// <summary>
        /// 获取记录数
        /// </summary>
        public long RecordCount => _recordCount;

        public List<uint> RecordOffsets { get => _recordOffsets; set => _recordOffsets = value; }
        public List<uint> RecordLengths { get => _recordLengths; set => _recordLengths = value; }

        #endregion

        #region 私有函数



        #endregion
    }
}
