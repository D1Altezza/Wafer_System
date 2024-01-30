using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class AmbientLightFilterForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        public AmbientLightFilterForm()
        {
            InitializeComponent();

            _comboBoxOnOff.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _onOff = _comboBoxOnOff.SelectedIndex == 0;
            }

            base.OnClosing(e);
        }

    }
}
