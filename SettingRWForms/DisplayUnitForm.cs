using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class DisplayUnitForm : Form
    {
        private byte _displayUnit;

        public byte DisplayUnit
        {
            get { return _displayUnit; }
        }

        public DisplayUnitForm()
        {
            InitializeComponent();

            _comboBoxDisplayUnit.SelectedIndex = 2;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!byte.TryParse(_comboBoxDisplayUnit.SelectedIndex.ToString(), out _displayUnit))
                {
                    MessageBox.Show(this, "displayUnit is Invalid Value");
                    e.Cancel = true;
                }
            }
            base.OnClosing(e);
        }

    }
}
