using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GISBox
{
    /// <summary>
    /// 从 dbf 文件读取数据并对数据进行管理
    /// </summary>
    public class DbfFileProcessor
    {
        #region 字段

        // (1) 头文件数据
        private string _filePath;   //文件路径，用于在修改属性后保存文件
        private DbfFileHeader _dbfFileHeader;


        // (2) MyMapObjects 格式的字段说明和属性表
        private MyMapObjects.moFields _mapMapFields;
        private List<MyMapObjects.moAttributes> _mapAttributesList;
        #endregion

        #region 构造函数

        /// <summary>
        /// 从 dbf 文件读取数据
        /// 分为两种情况：从现有文件读取和新建文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isFileExist">是否读取已存在的文件</param>
        public DbfFileProcessor(string filePath,bool isFileExist)
        {
            _filePath = filePath;
            if (isFileExist)
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                //读取文件头
                _dbfFileHeader = new DbfFileHeader(br);
                //转换为 MyMapObjects 格式
                _mapMapFields = _dbfFileHeader.GetMoFields();
                _mapAttributesList = GetMoAttributes(br);

                br.Dispose();
                fs.Dispose();
            }
            else
            {
                _dbfFileHeader = new DbfFileHeader();
                _mapMapFields = new MyMapObjects.moFields();
                _mapAttributesList = new List<MyMapObjects.moAttributes>();
            }
            
        }


        #endregion

        #region 属性

        /// <summary>
        /// 获取字段集合
        /// </summary>
        public MyMapObjects.moFields MapFields
        {
            get => _mapMapFields;
            set => _mapMapFields = value;
        }

        /// <summary>
        /// 获取属性列表
        /// </summary>
        public List<MyMapObjects.moAttributes> MapAttributesList => _mapAttributesList;

        /// <summary>
        /// 默认路径
        /// </summary>
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }

        #endregion

        #region 方法
        /// <summary>
        /// 在属性表的末尾添加一个字段，并更新属性值
        /// </summary>
        /// <param name="newField">新字段</param>
        /// <param name="newAttributes">新字段的属性值</param>
        public void AddField(MyMapObjects.moField newField, MyMapObjects.moAttributes newAttributes)
        {
            DbfFileField addedDbfField = new DbfFileField(newField);

            //(1) 修改 dbf 文件头
            _dbfFileHeader.HeaderLength += 32;
            _dbfFileHeader.RecordLength += addedDbfField.FieldLength;
            _dbfFileHeader.DbfFields.Add(addedDbfField);
            //(2) 修改 map 字段集合
            _mapMapFields.Append(newField);
            //(3) 修改记录的属性值
            object[] curAttributesArray = newAttributes.ToArray();
            for (int i = 0; i < curAttributesArray.Length; ++i)
            {
                _mapAttributesList[i].Append(curAttributesArray[i]);
            }
        }

        /// <summary>
        /// 根据索引号删除字段
        /// </summary>
        /// <param name="index">要删除的字段索引</param>
        public void DeleteField(int index)
        {
            if (index < 0 || index >= _mapMapFields.Count)
            {
                string error = "要删除的字段索引超出范围";
                throw new Exception(error);
            }
            //(1) 修改文件头
            DbfFileField deletedDbfField = _dbfFileHeader.DbfFields[index];
            _dbfFileHeader.HeaderLength -= 32;
            _dbfFileHeader.RecordLength -= deletedDbfField.FieldLength;
            _dbfFileHeader.DbfFields.RemoveAt(index);
            //(2) 修改字段集合
            _mapMapFields.RemoveAt(index);
            //(3) 修改记录的属性值
            for (int i = 0; i < _mapAttributesList.Count; ++i)
            {
                _mapAttributesList[i].RemoveAt(index);
            }
        }

        /// <summary>
        /// 有待改进，因为增加修改要素，和编辑字段都没有同步更新
        /// 所以在保存的时候，直接把图层维护的属性表赋值过来，并更新字段数量
        /// 更新记录
        /// </summary>
        /// <param name="newAttributesList"></param>
        public void UpdateAttributesList(List<MyMapObjects.moAttributes> newAttributesList)
        {
            if (newAttributesList.Count != 0)
            {
                object[] curDbfAttributeArray = newAttributesList[0].ToArray();
                if (curDbfAttributeArray.Length != _mapMapFields.Count)
                {
                    string error = "记录的属性值数与字段数不相等!";
                    throw new Exception(error);
                }
            }
            //(1) 修改文件头
            _dbfFileHeader.RecordCount = (uint)newAttributesList.Count;
            //(2) 修改记录的属性值
            _mapAttributesList = newAttributesList;
        }

        /// <summary>
        /// 保存到文件中，文件路径为读入时的路径
        /// </summary>
        public void SaveToFile()
        {
            FileStream fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            _dbfFileHeader.WriteToFile(bw);
            WriteAttributesToFile(bw);
            bw.Dispose();
            fs.Dispose();
        }

        #endregion

        #region 私有函数
        /// <summary>
        /// 从文件读取属性表
        /// 并以 List moAttributes  的格式返回
        /// </summary>
        /// <param name="br"></param>
        public List<MyMapObjects.moAttributes> GetMoAttributes(BinaryReader br)
        {
            List<MyMapObjects.moAttributes> mapAttributesList = new List<MyMapObjects.moAttributes>();
            //定位到文件头结束处
            br.BaseStream.Seek(_dbfFileHeader.HeaderLength, SeekOrigin.Begin);
            //遍历每一条记录
            for (int i = 0; i < _dbfFileHeader.RecordCount; ++i)
            {
                //当前记录
                byte[] curRecordContent = br.ReadBytes(_dbfFileHeader.RecordLength);
                MyMapObjects.moAttributes curAttributes = new MyMapObjects.moAttributes();
                //一条记录包含多个字段，使用 curIndex 逐个读取
                int sCurIndex = 1;
                //对于每一条记录，遍历每个字段
                for (int j = 0; j < _dbfFileHeader.DbfFields.Count; ++j)
                {
                    DbfFileField deletedDbfField = _dbfFileHeader.DbfFields[j];
                    MyMapObjects.moValueTypeConstant curValueType = _mapMapFields.GetItem(j).ValueType;
                    // dbf 文件对于所有属性都是以文本的格式存储，而不是二进制格式
                    //所以直接读取字符串，再进行格式转换即可
                    string curDbfAttribute = Encoding.UTF8.GetString(curRecordContent, sCurIndex, deletedDbfField.FieldLength).Trim((char)0x20).Replace("\0", "");
                    sCurIndex += deletedDbfField.FieldLength;

                    //dbf文件中不存在 16 位整数和 64 位整数类型
                    //由于 _mapField 是从 dbf 文件读入的
                    //所以 ValueType 不会等于 dInt16 和 dInt32
                    switch (curValueType)
                    {
                        case MyMapObjects.moValueTypeConstant.dInt32:
                            {
                                int curMoAttribute = Convert.ToInt32(curDbfAttribute);
                                curAttributes.Append(curMoAttribute);
                                break;
                            }
                            
                        case MyMapObjects.moValueTypeConstant.dSingle:
                            {
                                float curMoAttribute = Convert.ToSingle(curDbfAttribute);
                                curAttributes.Append(curMoAttribute);
                                break;
                            }
                        case MyMapObjects.moValueTypeConstant.dDouble:
                            {
                                  double  curMoAttribute = Convert.ToDouble(curDbfAttribute);

                                curAttributes.Append(curMoAttribute);
                                break;
                            }
                        default:
                            curAttributes.Append(curDbfAttribute);
                            break;

                    }
                }
                mapAttributesList.Add(curAttributes);
            }
            return mapAttributesList;
        }




        /// <summary>
        /// 将属性表写入文件中
        /// </summary>
        /// <param name="bw"></param>
        private void WriteAttributesToFile(BinaryWriter bw)
        {
            //(1) 获取每一个字段的长度
            int[] fieldLengths = new int[_dbfFileHeader.DbfFields.Count];
            for (int i = 0; i < _dbfFileHeader.DbfFields.Count; ++i)
            {
                fieldLengths[i] = _dbfFileHeader.DbfFields[i].FieldLength;
            }
            //(2) 将记录逐行写入内存
            foreach (var t in _mapAttributesList)
            {
                //每条记录的第一个字节是 "deletion" flag
                //默认为 0x20
                bw.Write((byte)0x20);   
                object[] curAttributes = t.ToArray();
                for (int j = 0; j < curAttributes.Length; ++j)
                {
                    //对于所有格式的属性
                    //都可以转换为字符串再写入
                    string curMoAttribute = curAttributes[j].ToString();
                    bw.Write(Util.ConvertStringToBytes(curMoAttribute, fieldLengths[j]));
                }
            }
        }

        #endregion
    }
}