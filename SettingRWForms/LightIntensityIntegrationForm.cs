using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class LightIntensityIntegrationForm : Form
    {
        private byte _integrationNumber;

        public byte IntegrationNumber
        {
            get { return _integrationNumber; }
        }
        public LightIntensityIntegrationForm()
        {
            InitializeComponent();

            _comboBoxIntegrationNumber.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!byte.TryParse(_comboBoxIntegrationNumber.SelectedIndex.ToString(), out _integrationNumber))
                {
                    MessageBox.Show(this, "integrationNumber is Invalid Value");
                    e.Cancel = true;
                }
            }
            base.OnClosing(e);
        }
    }
}
