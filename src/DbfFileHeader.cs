using System.Collections.Generic;
using System.IO;

namespace GISBox
{
    /// <summary>
    /// dbf 文件头
    /// </summary>
    public class DbfFileHeader
    {
        #region 字段
        //(1) 数据库参数区
        private byte _dBaseInfo;            //字节0：数据库说明
        private byte[] _lastModifyDate;     //字节1-3：最后修改日期
        private uint _recordCount;          //字节4-7：记录数
        private ushort _headerLength;       //字节8-9：文件头大小，文件头后面为数据库
        private ushort _recordLength;       //字节10-11：一条记录中的字节长度
        private byte[] _reservedField;      //字节12-31：将不需要的字节也视为保留字节
        //(2) 字段说明区
        private List<DbfFileField> _dbfFields;   //dbf字段列表

        #endregion

        #region 构造函数

        /// <summary>
        /// 从文件流中读取头文件
        /// </summary>
        /// <param name="br"></param>
        public DbfFileHeader(BinaryReader br)
        {
            _dBaseInfo = br.ReadByte();
            _lastModifyDate = br.ReadBytes(3);
            _recordCount = br.ReadUInt32();
            _headerLength = br.ReadUInt16();
            _recordLength = br.ReadUInt16();
            _reservedField = br.ReadBytes(20);
            _dbfFields = new List<DbfFileField>();
            //字段说明区后的停止字节为 0x0D
            while (br.PeekChar() != 0x0D)
            {
                DbfFileField curDbfField = new DbfFileField(br);
                _dbfFields.Add(curDbfField);
            }
        }

        public DbfFileHeader()
        {
            _dBaseInfo = 0x02;
            _lastModifyDate = Util.CurDateAsBytes();
            _recordCount = 0;
            _headerLength = 33;
            _recordLength = 1;
            _reservedField = new byte[20];
            _dbfFields = new List<DbfFileField>();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置记录数
        /// </summary>
        public uint RecordCount
        {
            set => _recordCount = value;
            get => _recordCount;
        }

        /// <summary>
        /// 获取或设置文件头的字节长度
        /// </summary>
        public ushort HeaderLength
        {
            set => _headerLength = value;
            get => _headerLength;
        }

        /// <summary>
        /// 获取或设置一条记录中的字节长度
        /// </summary>
        public ushort RecordLength
        {
            set => _recordLength = value;
            get => _recordLength;
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        public List<DbfFileField> DbfFields => _dbfFields;

        #endregion

        #region 方法
        /// <summary>
        /// 将 dbfFields 转换为 moFields 并返回
        /// </summary>
        /// <returns></returns>
        public MyMapObjects.moFields GetMoFields()
        {
            MyMapObjects.moFields mapFields = new MyMapObjects.moFields();
            //遍历所有字段
            foreach (var t in _dbfFields)
            {
                string curFieldName = t.FieldName;
                char cueDbfFieldType = (char)t.FieldType;
                MyMapObjects.moValueTypeConstant curValueType;
                switch (cueDbfFieldType)
                {
                    case 'I':
                        curValueType = MyMapObjects.moValueTypeConstant.dInt32;
                        break;
                    case 'F':
                        curValueType = MyMapObjects.moValueTypeConstant.dSingle;
                        break;
                    case 'B':
                        curValueType = MyMapObjects.moValueTypeConstant.dDouble;
                        break;
                    case 'N':
                        curValueType = MyMapObjects.moValueTypeConstant.dDouble;
                        break;
                    default:
                        //其余类型的字段都使用文本存储
                        curValueType = MyMapObjects.moValueTypeConstant.dText;
                        break;
                }
                MyMapObjects.moField curMapField = new MyMapObjects.moField(curFieldName, curValueType);
                mapFields.Append(curMapField);
            }
            return mapFields;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="bw"></param>
        public void WriteToFile(BinaryWriter bw)
        {
            //(1) 写入数据库参数区
            bw.Write(_dBaseInfo);  //写入数据库说明
            byte[] curDate = Util.CurDateAsBytes();
            bw.Write(curDate);
            bw.Write(_recordCount);
            bw.Write(_headerLength);
            bw.Write(_recordLength);
            bw.Write(_reservedField);

            //(2) 写入字段说明区
            foreach (var curField in _dbfFields)
            {
                curField.WriteToFile(bw);
            }
            //最后以 0D 结尾
            bw.Write((byte)0x0D);
        }
        #endregion
    }
}
