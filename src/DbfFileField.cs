using System.IO;
using System.Text;

namespace GISBox
{
    
    public class DbfFileField
    {
        #region 字段

        private string _fieldName;  //字节0-10：字段名称
        /// <summary>
        ///字节11：字段类型
        ///I: Integer
        ///F: Float
        ///B: Double
        ///N: Numeric
        ///C: Character
        ///D: Date
        ///L: Logical
        /// </summary>
        private byte _fieldType;   
        private byte[] _reserved1;      //字节12-15：4个保留字节
        private byte _fieldLength;      //字节16：字段长度
        private byte[] _reserved2;      //字节17-31: 15个保留字节
        #endregion

        #region 构造函数
        /// <summary>
        /// 从文件流中读取字段说明
        /// </summary>
        /// <param name="br"></param>
        public DbfFileField(BinaryReader br)
        {
            _fieldName = Encoding.UTF8.GetString(br.ReadBytes(11), 0, 11).Replace("\0", "").ToLower();
            _fieldType = br.ReadByte();
            _reserved1 = br.ReadBytes(4);
            _fieldLength = br.ReadByte();
            _reserved2 = br.ReadBytes(15);
        }

        /// <summary>
        /// 将 moField 格式的字段说明转换为 dbfField
        /// </summary>
        /// <param name="mapField"></param>
        public DbfFileField(MyMapObjects.moField mapField)
        {
            _fieldName = mapField.Name;
            switch (mapField.ValueType)
            {
                case MyMapObjects.moValueTypeConstant.dInt32:
                    _fieldType = (byte)'I';
                    _fieldLength = 8;
                    break;
                case MyMapObjects.moValueTypeConstant.dSingle:
                    _fieldType = (byte)'F';
                    _fieldLength = 8;
                    break;
                case MyMapObjects.moValueTypeConstant.dDouble:
                    _fieldType = (byte)'B';
                    _fieldLength = 16;
                    break;
                case MyMapObjects.moValueTypeConstant.dText:
                    _fieldType = (byte)'C';
                    _fieldLength = 100;
                    break;
                default:
                    _fieldType = (byte)'C';
                    _fieldLength = 100;
                    break;
            }
            //其余字节默认为0
            _reserved1 = new byte[4];
            _reserved2 = new byte[15];
        }
        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置字段名称
        /// </summary>
        public string FieldName
        {
            set => _fieldName = value;
            get => _fieldName;
        }

        /// <summary>
        /// 获取或设置dbf约定的字段类型
        /// </summary>
        public byte FieldType
        {
            set => _fieldType = value;
            get => _fieldType;
        }

        /// <summary>
        /// 获取或设置字段长度
        /// </summary>
        public byte FieldLength
        {
            set => _fieldLength = value;
            get => _fieldLength;
        }
        #endregion

        #region
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="bw"></param>
        public void WriteToFile(BinaryWriter bw)
        {
            bw.Write(Util.ConvertStringToBytes(_fieldName, 11));
            bw.Write(_fieldType);
            bw.Write(_reserved1);
            bw.Write(_fieldLength);
            bw.Write(_reserved2);
        }
        #endregion
    }
}
