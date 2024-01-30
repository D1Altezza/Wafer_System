using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class MeasurementMethodForm : Form
    {
        private byte _method;

        public byte Method
        {
            get { return _method; }
        }

        private int _targetHead1;

        public int TargetHead1
        {
            get { return _targetHead1; }
        }

        private int _targetHead2;

        public int TargetHead2
        {
            get { return _targetHead2; }
        }

        private int _peak1;

        public int Peak1
        {
            get { return _peak1; }
        }

        private int _peak2;

        public int Peak2
        {
            get { return _peak2; }
        }

        private int _factorA;

        public int FactorA
        {
            get { return _factorA; }
        }

        private int _factorB;

        public int FactorB
        {
            get { return _factorB; }
        }

        private int _factorC;

        public int FactorC
        {
            get { return _factorC; }
        }

        private byte _targetOutX;
        public byte TargetOutX
        {
            get { return _targetOutX; }
        }

        private byte _targetOutY;
        public byte TargetOutY
        {
            get { return _targetOutY; }
        }

        private ushort _targetOutNo;

        public ushort TargetOutNo
        {
            get { return _targetOutNo; }
        }

        public MeasurementMethodForm()
        {
            InitializeComponent();

            _comboBoxMethod.SelectedIndex = 0;
            _comboBoxTargetHead1.SelectedIndex = 0;
            _comboBoxTargetHead2.SelectedIndex = 1;
            _comboBoxPeak1.SelectedIndex = 0;
            _comboBoxPeak2.SelectedIndex = 1;
            _comboBoxTargetOutX.SelectedIndex = 0;
            _comboBoxTargetOutY.SelectedIndex = 1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxMethod.SelectedIndex.ToString(), out _method))
            {
                MessageBox.Show(this, "method is Invalid Value");
                e.Cancel = true;
                return;
            }

            _targetHead1 = _comboBoxTargetHead1.SelectedIndex;
            _targetHead2 = _comboBoxTargetHead2.SelectedIndex;

            _peak1 = _comboBoxPeak1.SelectedIndex;
            _peak2 = _comboBoxPeak2.SelectedIndex;

            if (!int.TryParse(_textBoxFactorA.Text, out _factorA))
            {
                MessageBox.Show(this, "factorA is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxFactorB.Text, out _factorB))
            {
                MessageBox.Show(this, "factorB is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxFactorC.Text, out _factorC))
            {
                MessageBox.Show(this, "factorC is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxTargetOutX.SelectedIndex.ToString(), out _targetOutX))
            {
                MessageBox.Show(this, "targetOutX is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxTargetOutY.SelectedIndex.ToString(), out _targetOutY))
            {
                MessageBox.Show(this, "targetOutY is Invalid Value");
                e.Cancel = true;
                return;
            }

            _targetOutNo |= _checkBoxOut1.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort)0;
            _targetOutNo |= _checkBoxOut2.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort)0;
            _targetOutNo |= _checkBoxOut3.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort)0;
            _targetOutNo |= _checkBoxOut4.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort)0;
            _targetOutNo |= _checkBoxOut5.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort)0;
            _targetOutNo |= _checkBoxOut6.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort)0;
            _targetOutNo |= _checkBoxOut7.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort)0;
            _targetOutNo |= _checkBoxOut8.Checked ? (ushort)CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort)0;

            base.OnClosing(e);
        }
    }
}
