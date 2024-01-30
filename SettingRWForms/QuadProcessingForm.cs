using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class QuadProcessingForm : Form
    {
        private byte _processing;

        public byte Processing
        {
            get { return _processing; }
        }

        private byte _validPoints;

        public byte ValidPoints
        {
            get { return _validPoints; }
        }
        public QuadProcessingForm()
        {
            InitializeComponent();

            _comboBoxProcessing.SelectedIndex = 0;
            _comboBoxValidPoints.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxProcessing.SelectedIndex.ToString(), out _processing))
            {
                MessageBox.Show(this, "processing is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxValidPoints.Text, out _validPoints))
            {
                MessageBox.Show(this, "validPoints is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
