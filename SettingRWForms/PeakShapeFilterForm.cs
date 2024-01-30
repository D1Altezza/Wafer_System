using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class PeakShapeFilterForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        private int _intensity;

        public int Intensity
        {
            get { return _intensity; }
        }

        public PeakShapeFilterForm()
        {
            InitializeComponent();

            _comboBoxOnOff.SelectedIndex = 0;
            _comboBoxIntensity.SelectedIndex = 2;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _onOff = _comboBoxOnOff.SelectedIndex == 0;
                _intensity = _comboBoxIntensity.SelectedIndex;
            }
            base.OnClosing(e);
        }

    }
}
