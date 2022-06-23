using System;

namespace GISBox.Forms
{
    public partial class AddNewField : System.Windows.Forms.Form
    {
        public AttributeTable Table { get; }

        public AddNewField(AttributeTable table)
        {
            InitializeComponent();
            Table = table;
        }


        //确认添加
        private void btnAddField_Click(object sender, EventArgs e)
        {
            string typeStr = comboBox.SelectedItem.ToString();
            switch (typeStr)
            {
                case "Int16":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dInt16;
                    break;
                case "Int32":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dInt32;
                    break;
                case "Int64":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dInt64;
                    break;
                case "Single":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dSingle;
                    break;
                case "Double":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dDouble;
                    break;
                case "Text":
                    Table.NewFieldType = MyMapObjects.moValueTypeConstant.dText;
                    break;
            }
            Table.NewFieldName = textBox.Text;
            Table.AddNewField();
            Close();
        }
    }
}
