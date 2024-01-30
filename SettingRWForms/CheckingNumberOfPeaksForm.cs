using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class CheckingNumberOfPeaksForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        public CheckingNumberOfPeaksForm()
        {
            InitializeComponent();

            _comboBoxOnOff.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            _onOff = _comboBoxOnOff.SelectedIndex == 0;

            base.OnClosing(e);
        }
    }
}
