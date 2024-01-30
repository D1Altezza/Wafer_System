using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class ScalingForm : Form
    {
        private int _inputValue1;

        public int InputValue1
        {
            get { return _inputValue1; }
        }

        private int _outputValue1;

        public int OutputValue1
        {
            get { return _outputValue1; }
        }

        private int _inputValue2;

        public int InputValue2
        {
            get { return _inputValue2; }
        }

        private int _outputValue2;

        public int OutputValue2
        {
            get { return _outputValue2; }
        }
        
        public ScalingForm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!int.TryParse(_textBoxInputValue1.Text, out _inputValue1))
            {
                MessageBox.Show(this, "inputValue1 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxOutputValue1.Text, out _outputValue1))
            {
                MessageBox.Show(this, "outputValue1 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxInputValue2.Text, out _inputValue2))
            {
                MessageBox.Show(this, "inputValue2 is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(_textBoxOutputValue2.Text, out _outputValue2))
            {
                MessageBox.Show(this, "outputValue2 is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
