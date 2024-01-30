using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class MeasurementPeaksForm : Form
    {
        private byte _peaks;

        public byte Peaks
        {
            get { return _peaks; }
        }

        public MeasurementPeaksForm()
        {
            InitializeComponent();

            _comboBoxPeaks.SelectedIndex = 3;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!byte.TryParse(_comboBoxPeaks.Text, out _peaks))
                {
                    MessageBox.Show(this, "peaks is Invalid Value");
                    e.Cancel = true;
                }
            }
            base.OnClosing(e);
        }
    }
}
