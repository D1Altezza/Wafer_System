using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class OffsetForm : Form
    {
        private int _offset;

        public int Offset
        {
            get { return _offset; }
        }

        public OffsetForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!int.TryParse(_textBoxOffset.Text, out _offset))
            {
                MessageBox.Show(this, "offset is Invalid Value");
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
    }
}
