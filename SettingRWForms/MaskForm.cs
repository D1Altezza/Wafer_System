using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class MaskForm : Form
    {
        private bool _onOff;

        public bool OnOff
        {
            get { return _onOff; }
        }

        private int _position1;

        public int Position1
        {
            get { return _position1; }
        }

        private int _position2;

        public int Position2
        {
            get { return _position2; }
        }

        public MaskForm()
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
            if (!int.TryParse(_textBoxPosition1.Text, out _position1))
            {
                MessageBox.Show(this, "position1 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxPosition2.Text, out _position2))
            {
                MessageBox.Show(this, "position2 is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
