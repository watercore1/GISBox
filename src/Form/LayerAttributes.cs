using System.Windows.Forms;

namespace GISBox
{
    public partial class LayerAttributes : Form
    {
        public LayerAttributes()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            AttibutesText.Text = text;
        }
    }
}
