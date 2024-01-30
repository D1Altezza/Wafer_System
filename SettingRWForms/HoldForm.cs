using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class HoldForm : Form
    {
        private byte _holdMode;

        public byte HoldMode
        {
            get { return _holdMode; }
        }

        private byte _updateCondition;

        public byte UpdateCondition
        {
            get { return _updateCondition; }
        }

        private ushort _numberOfSamplings;

        public ushort NumberOfSamplings
        {
            get { return _numberOfSamplings; }
        }

        private int _level;

        public int Level
        {
            get { return _level; }
        }

        private int _hysteresis;

        public int Hysteresis
        {
            get { return _hysteresis; }
        }

        public HoldForm()
        {
            InitializeComponent();

            _comboBoxHoldMode.SelectedIndex = 0;
            _comboBoxUpdateCondition.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxHoldMode.SelectedIndex.ToString(), out _holdMode))
            {
                MessageBox.Show(this, "holdMode is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxUpdateCondition.SelectedIndex.ToString(), out _updateCondition))
            {
                MessageBox.Show(this, "updateCondition is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!ushort.TryParse(_textBoxNumberOfSamplings.Text, out _numberOfSamplings))
            {
                MessageBox.Show(this, "numberOfSamplings is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxLevel.Text, out _level))
            {
                MessageBox.Show(this, "level is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxHysteresis.Text, out _hysteresis))
            {
                MessageBox.Show(this, "hysteresis is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

    }
}
