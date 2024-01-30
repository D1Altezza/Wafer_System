using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class StorageTargetForm : Form
    {
        private CL3IF_OUTNO _outNo;

        public CL3IF_OUTNO OutNo
        {
            get { return _outNo; }
        }

        public StorageTargetForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                _outNo |= _checkboxBit1.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_01 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit2.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_02 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit3.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_03 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit4.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_04 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit5.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_05 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit6.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_06 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit7.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_07 : (CL3IF_OUTNO)0;
                _outNo |= _checkboxBit8.Checked ? CL3IF_OUTNO.CL3IF_OUTNO_08 : (CL3IF_OUTNO)0;
            }
            base.OnClosing(e);
        }
    }
}
