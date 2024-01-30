using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class SamplingCycleForm : Form
    {
        private int _selectSamplingCycle;

        public int SelectSamplingCycle
        {
            get { return _selectSamplingCycle; }
        }

        public SamplingCycleForm()
        {
            InitializeComponent();

            _comboBoxSamplingCycle.SelectedIndex = 3;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _selectSamplingCycle = _comboBoxSamplingCycle.SelectedIndex;
            }
            base.OnClosing(e);
        }
    }
}
