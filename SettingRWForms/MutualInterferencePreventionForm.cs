using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class MutualInterferencePreventionForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        private ushort _group;
        public ushort Group
        {
            get { return _group; }
        }

        public MutualInterferencePreventionForm()
        {
            InitializeComponent();

            _comboBoxOnOff.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _onOff = _comboBoxOnOff.SelectedIndex == 0;
                _group |= _radioButtonHead1B.Checked ? (ushort)1 : (ushort)0;
                _group |= _radioButtonHead2B.Checked ? (ushort)(1 << 1) : (ushort)0;
                _group |= _radioButtonHead3B.Checked ? (ushort)(1 << 2) : (ushort)0;
                _group |= _radioButtonHead4B.Checked ? (ushort)(1 << 3) : (ushort)0;
                _group |= _radioButtonHead5B.Checked ? (ushort)(1 << 4) : (ushort)0;
                _group |= _radioButtonHead6B.Checked ? (ushort)(1 << 5) : (ushort)0;
            }
            base.OnClosing(e);
        }
    }
}
