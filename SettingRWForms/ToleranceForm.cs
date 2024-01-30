using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class ToleranceForm : Form
    {
        private int _upperLimit;

        public int UpperLimit
        {
            get { return _upperLimit; }
        }

        private int _lowerLimit;

        public int LowerLimit
        {
            get { return _lowerLimit; }
        }

        private int _hysteresis;

        public int Hysteresis
        {
            get { return _hysteresis; }
        }

        public ToleranceForm()
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

            if (!int.TryParse(_textBoxUpperLimit.Text, out _upperLimit))
            {
                MessageBox.Show(this, "upperLimit is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxLowerLimit.Text, out _lowerLimit))
            {
                MessageBox.Show(this, "lowerLimit is Invalid Value");
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
