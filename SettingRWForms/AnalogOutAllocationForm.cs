using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class AnalogOutAllocationForm : Form
    {
        private byte _ch1Out;

        public byte Ch1Out
        {
            get { return _ch1Out; }
        }

        private byte _ch2Out;

        public byte Ch2Out
        {
            get { return _ch2Out; }
        }

        private byte _ch3Out;

        public byte Ch3Out
        {
            get { return _ch3Out; }
        }

        private byte _ch4Out;

        public byte Ch4Out
        {
            get { return _ch4Out; }
        }

        public AnalogOutAllocationForm()
        {
            InitializeComponent();

            _comboBoxCh1Out.SelectedIndex = 0;
            _comboBoxCh2Out.SelectedIndex = 0;
            _comboBoxCh3Out.SelectedIndex = 0;
            _comboBoxCh4Out.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxCh1Out.SelectedIndex.ToString(), out _ch1Out))
            {
                MessageBox.Show(this, "ch1Out is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxCh2Out.SelectedIndex.ToString(), out _ch2Out))
            {
                MessageBox.Show(this, "ch2Out is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxCh3Out.SelectedIndex.ToString(), out _ch3Out))
            {
                MessageBox.Show(this, "ch3Out is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxCh4Out.SelectedIndex.ToString(), out _ch4Out))
            {
                MessageBox.Show(this, "ch4Out is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

    }
}
