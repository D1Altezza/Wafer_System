using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class ThresholdForm : Form
    {
        private byte _mode;

        public byte Mode
        {
            get { return _mode; }
        }

        private byte _value;

        public byte Value
        {
            get { return _value; }
        }

        public ThresholdForm()
        {
            InitializeComponent();

            _comboBoxMode.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxMode.SelectedIndex.ToString(), out _mode))
            {
                MessageBox.Show(this, "mode is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_textBoxValue.Text, out _value))
            {
                MessageBox.Show(this, "value is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
