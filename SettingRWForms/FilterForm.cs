using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class FilterForm : Form
    {
        private byte _filterMode;

        public byte FilterMode
        {
            get { return _filterMode; }
        }

        private ushort _filterParam;

        public ushort FilterParam
        {
            get { return _filterParam; }
        }
        public FilterForm()
        {
            InitializeComponent();

            _comboBoxFilterMode.SelectedIndex = 0;
            _comboBoxFilterParam.SelectedIndex = 6;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxFilterMode.SelectedIndex.ToString(), out _filterMode))
            {
                MessageBox.Show(this, "filterMode is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!ushort.TryParse(_comboBoxFilterParam.SelectedIndex.ToString(), out _filterParam))
            {
                MessageBox.Show(this, "filterParam is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        private void _comboBoxMode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _comboBoxFilterParam.Items.Clear();
            if (_comboBoxFilterMode.SelectedIndex == 0)
            {
                _comboBoxFilterParam.Items.Add("1 times");
                _comboBoxFilterParam.Items.Add("2 times");
                _comboBoxFilterParam.Items.Add("4 times");
                _comboBoxFilterParam.Items.Add("8 times");
                _comboBoxFilterParam.Items.Add("16 times");
                _comboBoxFilterParam.Items.Add("32 times");
                _comboBoxFilterParam.Items.Add("64 times");
                _comboBoxFilterParam.Items.Add("256 times");
                _comboBoxFilterParam.Items.Add("1024 times");
                _comboBoxFilterParam.Items.Add("4096 times");
                _comboBoxFilterParam.Items.Add("16384 times");
                _comboBoxFilterParam.Items.Add("65536 times");
                _comboBoxFilterParam.Items.Add("262144 times");
            }
            else if (_comboBoxFilterMode.SelectedIndex == 1 || _comboBoxFilterMode.SelectedIndex == 2)
            {
                _comboBoxFilterParam.Items.Add("1000 Hz");
                _comboBoxFilterParam.Items.Add("300 Hz");
                _comboBoxFilterParam.Items.Add("100 Hz");
                _comboBoxFilterParam.Items.Add("30 Hz");
                _comboBoxFilterParam.Items.Add("10 Hz");
                _comboBoxFilterParam.Items.Add("3 Hz");
                _comboBoxFilterParam.Items.Add("1 Hz");
                _comboBoxFilterParam.Items.Add("0.3 Hz");
                _comboBoxFilterParam.Items.Add("0.1 Hz");
            }
            _comboBoxFilterParam.SelectedIndex = 0;
        }
    }
}
