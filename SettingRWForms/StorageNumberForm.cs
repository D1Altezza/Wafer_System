using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class StorageNumberForm : Form
    {
        private byte _overwrite;

        public byte Overwrite
        {
            get { return _overwrite; }
        }

        private uint _storageNumber;

        public uint StorageNumber
        {
            get { return _storageNumber; }
        }
        public StorageNumberForm()
        {
            InitializeComponent();

            _comboBoxOverwrite.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }

            if (!byte.TryParse(_comboBoxOverwrite.SelectedIndex.ToString(), out _overwrite))
            {
                MessageBox.Show(this, "overwrite is Invalid Value");
                e.Cancel = true;
                return;
            }

            if (!uint.TryParse(_textBoxStorageNumber.Text, out _storageNumber))
            {
                MessageBox.Show(this, "storageNumber is Invalid Value");
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }
    }
}
