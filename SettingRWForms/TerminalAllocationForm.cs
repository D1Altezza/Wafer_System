using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class TerminalAllocationForm : Form
    {
        private byte _timingReset;

        public byte TimingReset
        {
            get { return _timingReset; }
        }

        private byte _zero;

        public byte Zero
        {
            get { return _zero; }
        }

        public TerminalAllocationForm()
        {
            InitializeComponent();

            _comboBoxTimingReset.SelectedIndex = 1;
            _comboBoxZero.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxTimingReset.SelectedIndex.ToString(), out _timingReset))
            {
                MessageBox.Show(this, "timingReset is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxZero.SelectedIndex.ToString(), out _zero))
            {
                MessageBox.Show(this, "zero is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
