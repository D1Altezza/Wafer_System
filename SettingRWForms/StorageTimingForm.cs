using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class StorageTimingForm : Form
    {
        private byte _storageTiming;

        public byte StorageTiming
        {
            get { return _storageTiming; }
        }

        private ushort _storageCycle;

        public ushort StorageCycle
        {
            get { return _storageCycle; }
        }

        private CL3IF_STORAGETIMING_PARAM_JUDGMENT _judgment;

        public CL3IF_STORAGETIMING_PARAM_JUDGMENT Judgment
        {
            get { return _judgment; }
        }

        public StorageTimingForm()
        {
            InitializeComponent();

            _comboBoxStorageTiming.SelectedIndex = 0;
            _comboBoxLogic.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxStorageTiming.SelectedIndex.ToString(), out _storageTiming))
            {
                MessageBox.Show(this, "storageTiming is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!ushort.TryParse(_textBoxStorageCycle.Text, out _storageCycle))
            {
                MessageBox.Show(this, "storageCycle is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgment.logic = (byte) _comboBoxLogic.SelectedIndex;

            _judgment.hi |= _checkboxHiOut1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgment.hi |= _checkboxHiOut8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgment.go |= _checkboxGoOut1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgment.go |= _checkboxGoOut2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgment.go |= _checkboxGoOut3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgment.go |= _checkboxGoOut4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgment.go |= _checkboxGoOut5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgment.go |= _checkboxGoOut6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgment.go |= _checkboxGoOut7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgment.go |= _checkboxGoOut8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgment.lo |= _checkboxLoOut1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgment.lo |= _checkboxLoOut8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            base.OnClosing(e);
        }
    }
}
