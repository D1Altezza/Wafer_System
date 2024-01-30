using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class RefractiveIndexCorrectionForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        private byte _layer1;

        public byte Layer1
        {
            get { return _layer1; }
        }

        private byte _layer2;

        public byte Layer2
        {
            get { return _layer2; }
        }

        private byte _layer3;

        public byte Layer3
        {
            get { return _layer3; }
        }

        public RefractiveIndexCorrectionForm()
        {
            InitializeComponent();

            _comboBoxOnOff.SelectedIndex = 1;
            _comboBoxLayer1.SelectedIndex = 0;
            _comboBoxLayer2.SelectedIndex = 0;
            _comboBoxLayer3.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            _onOff = _comboBoxOnOff.SelectedIndex == 0;
            if (!byte.TryParse(_comboBoxLayer1.SelectedIndex.ToString(), out _layer1))
            {
                MessageBox.Show(this, "layer1 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxLayer2.SelectedIndex.ToString(), out _layer2))
            {
                MessageBox.Show(this, "layer2 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxLayer3.SelectedIndex.ToString(), out _layer3))
            {
                MessageBox.Show(this, "layer3 is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
