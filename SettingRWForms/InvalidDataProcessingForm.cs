using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class InvalidDataProcessingForm : Form
    {
        private ushort _invalidationNumber;

        public ushort InvalidationNumber
        {
            get { return _invalidationNumber; }
        }

        private ushort _recoveryNumber;

        public ushort RecoveryNumber
        {
            get { return _recoveryNumber; }
        }

        public InvalidDataProcessingForm()
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

            if (!ushort.TryParse(_textBoxInvalidationNumber.Text, out _invalidationNumber))
            {
                MessageBox.Show(this, "invalidationNumber is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!ushort.TryParse(_textBoxRecoveryNumber.Text, out _recoveryNumber))
            {
                MessageBox.Show(this, "recoveryNumber is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

    }
}
