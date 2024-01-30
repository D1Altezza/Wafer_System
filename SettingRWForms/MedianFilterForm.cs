using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class MedianFilterForm : Form
    {
        private int _medianFilter;

        public int MedianFilter
        {
            get { return _medianFilter; }
        }

        public MedianFilterForm()
        {
            InitializeComponent();

            _comboBoxMedianFilter.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _medianFilter = _comboBoxMedianFilter.SelectedIndex;
            }
            base.OnClosing(e);
        }
    }
}
