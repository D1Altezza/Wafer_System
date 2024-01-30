using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class LightIntensityControlForm : Form
    {
        private byte _mode;

        public byte Mode
        {
            get { return _mode; }
        }

        private byte _upperLimit;

        public byte UpperLimit
        {
            get { return _upperLimit; }
        }

        private byte _lowerLimit;

        public byte LowerLimit
        {
            get { return _lowerLimit; }
        }

        public LightIntensityControlForm()
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

            if (!byte.TryParse(_textBoxUpperLimit.Text, out _upperLimit))
            {
                MessageBox.Show(this, "upperLimit is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_textBoxLowerLimit.Text, out _lowerLimit))
            {
                MessageBox.Show(this, "lowerLimit is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
