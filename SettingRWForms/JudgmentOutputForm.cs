using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class JudgmentOutputForm : Form
    {
        private const int OutputCount = 8;
        private CL3IF_JUDGMENT_OUTPUT[] _judgmentOutput = new CL3IF_JUDGMENT_OUTPUT[OutputCount];

        public CL3IF_JUDGMENT_OUTPUT[] JudgmentOutput
        {
            get { return _judgmentOutput; }
        }

        public JudgmentOutputForm()
        {
            InitializeComponent();

            _comboBoxLogic1.SelectedIndex = 0;
            _comboBoxStrobe1.SelectedIndex = 1;
            _comboBoxLogic2.SelectedIndex = 0;
            _comboBoxStrobe2.SelectedIndex = 1;
            _comboBoxLogic3.SelectedIndex = 0;
            _comboBoxStrobe3.SelectedIndex = 1;
            _comboBoxLogic4.SelectedIndex = 0;
            _comboBoxStrobe4.SelectedIndex = 0;
            _comboBoxLogic5.SelectedIndex = 0;
            _comboBoxStrobe5.SelectedIndex = 0;
            _comboBoxLogic6.SelectedIndex = 0;
            _comboBoxStrobe6.SelectedIndex = 0;
            _comboBoxLogic7.SelectedIndex = 0;
            _comboBoxStrobe7.SelectedIndex = 0;
            _comboBoxLogic8.SelectedIndex = 0;
            _comboBoxStrobe8.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxLogic1.SelectedIndex.ToString(), out _judgmentOutput[0].logic))
            {
                MessageBox.Show(this, "JudgmentOutput1 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe1.SelectedIndex.ToString(), out _judgmentOutput[0].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput1 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[0].hi |= _checkBoxHiOut1_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[0].hi |= _checkBoxHiOut1_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[0].go |= _checkBoxGoOut1_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[0].go |= _checkBoxGoOut1_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[0].lo |= _checkBoxLoOut1_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[0].lo |= _checkBoxLoOut1_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic2.SelectedIndex.ToString(), out _judgmentOutput[1].logic))
            {
                MessageBox.Show(this, "JudgmentOutput2 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe2.SelectedIndex.ToString(), out _judgmentOutput[1].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput2 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[1].hi |= _checkBoxHiOut2_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[1].hi |= _checkBoxHiOut2_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[1].go |= _checkBoxGoOut2_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[1].go |= _checkBoxGoOut2_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[1].lo |= _checkBoxLoOut2_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[1].lo |= _checkBoxLoOut2_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic3.SelectedIndex.ToString(), out _judgmentOutput[2].logic))
            {
                MessageBox.Show(this, "JudgmentOutput3 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe3.SelectedIndex.ToString(), out _judgmentOutput[2].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput3 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[2].hi |= _checkBoxHiOut3_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[2].hi |= _checkBoxHiOut3_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[2].go |= _checkBoxGoOut3_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[2].go |= _checkBoxGoOut3_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[2].lo |= _checkBoxLoOut3_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[2].lo |= _checkBoxLoOut3_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic4.SelectedIndex.ToString(), out _judgmentOutput[3].logic))
            {
                MessageBox.Show(this, "JudgmentOutput4 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe4.SelectedIndex.ToString(), out _judgmentOutput[3].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput4 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[3].hi |= _checkBoxHiOut4_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[3].hi |= _checkBoxHiOut4_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[3].go |= _checkBoxGoOut4_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[3].go |= _checkBoxGoOut4_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[3].lo |= _checkBoxLoOut4_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[3].lo |= _checkBoxLoOut4_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic5.SelectedIndex.ToString(), out _judgmentOutput[4].logic))
            {
                MessageBox.Show(this, "JudgmentOutput5 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe5.SelectedIndex.ToString(), out _judgmentOutput[4].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput5 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[4].hi |= _checkBoxHiOut5_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[4].hi |= _checkBoxHiOut5_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[4].go |= _checkBoxGoOut5_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[4].go |= _checkBoxGoOut5_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[4].lo |= _checkBoxLoOut5_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[4].lo |= _checkBoxLoOut5_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic6.SelectedIndex.ToString(), out _judgmentOutput[5].logic))
            {
                MessageBox.Show(this, "JudgmentOutput6 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe6.SelectedIndex.ToString(), out _judgmentOutput[5].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput6 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[5].hi |= _checkBoxHiOut6_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[5].hi |= _checkBoxHiOut6_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[5].go |= _checkBoxGoOut6_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[5].go |= _checkBoxGoOut6_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[5].lo |= _checkBoxLoOut6_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[5].lo |= _checkBoxLoOut6_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic7.SelectedIndex.ToString(), out _judgmentOutput[6].logic))
            {
                MessageBox.Show(this, "JudgmentOutput7 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe7.SelectedIndex.ToString(), out _judgmentOutput[6].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput7 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[6].hi |= _checkBoxHiOut7_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[6].hi |= _checkBoxHiOut7_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[6].go |= _checkBoxGoOut7_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[6].go |= _checkBoxGoOut7_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[6].lo |= _checkBoxLoOut7_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[6].lo |= _checkBoxLoOut7_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            if (!byte.TryParse(_comboBoxLogic8.SelectedIndex.ToString(), out _judgmentOutput[7].logic))
            {
                MessageBox.Show(this, "JudgmentOutput8 logic is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!byte.TryParse(_comboBoxStrobe8.SelectedIndex.ToString(), out _judgmentOutput[7].strobe))
            {
                MessageBox.Show(this, "JudgmentOutput8 strobe is Invalid Value");
                e.Cancel = true;
                return;
            }

            _judgmentOutput[7].hi |= _checkBoxHiOut8_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[7].hi |= _checkBoxHiOut8_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[7].go |= _checkBoxGoOut8_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[7].go |= _checkBoxGoOut8_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            _judgmentOutput[7].lo |= _checkBoxLoOut8_1.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_01 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_2.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_02 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_3.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_03 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_4.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_04 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_5.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_05 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_6.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_06 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_7.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_07 : (ushort) 0;
            _judgmentOutput[7].lo |= _checkBoxLoOut8_8.Checked ? (ushort) CL3IF_OUTNO.CL3IF_OUTNO_08 : (ushort) 0;

            base.OnClosing(e);
        }
    }
}
