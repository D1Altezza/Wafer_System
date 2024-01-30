using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class HighSensitivityForm : Form
    {
        private bool _highSensitivityOnOff;

        public bool HighSensitivityOnOff
        {
            get { return _highSensitivityOnOff; }
        }

        private byte _highSensitivityStrength;

        public byte HighSensitivityStrength
        {
            get { return _highSensitivityStrength; }
        }

        private byte _thresholdValueFractionalPoint;

        public byte ThresholdValueFractionalPoint
        {
            get { return _thresholdValueFractionalPoint; }
        }

        public HighSensitivityForm()
        {
            InitializeComponent();

            _comboBoxHighSensitivityOnOff.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_textBoxHighSensitivityStrength.Text, out _highSensitivityStrength))
            {
                MessageBox.Show(this, "highSensitivityStrength is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_textBoxThresholdValueFractionalPoint.Text, out _thresholdValueFractionalPoint))
            {
                MessageBox.Show(this, "thresholdValueFractionalPoint is Invalid Value");
                e.Cancel = true;
                return;
            }

            _highSensitivityOnOff = _comboBoxHighSensitivityOnOff.SelectedIndex == 0;

            base.OnClosing(e);
        }
    }
}
