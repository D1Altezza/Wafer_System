using System.ComponentModel;
using System.Windows.Forms;

namespace CL3_IF_DllSample.SettingRWForms
{
    public partial class EncoderForm : Form
    {
        private bool _encoderEncoderOnOff;
        
        public bool EncoderOnOff
        {
            get { return _encoderEncoderOnOff; }
        }

        private byte _operatingMode;

        public byte OperatingMode
        {
            get { return _operatingMode; }
        }

        private byte _enterMode;

        public byte EnterMode
        {
            get { return _enterMode; }
        }

        private short _decimationPoint;

        public short DecimationPoint
        {
            get { return _decimationPoint; }
        }

        private byte _detectionEdge;

        public byte DetectionEdge
        {
            get { return _detectionEdge; }
        }

        private byte _minInputTime;

        public byte MinInputTime
        {
            get { return _minInputTime; }
        }

        private byte _pulseCountOffsetDetectionLogic;

        public byte PulseCountOffsetDetectionLogic
        {
            get { return _pulseCountOffsetDetectionLogic; }
        }

        private int _presetValue;

        public int PresetValue
        {
            get { return _presetValue; }
        }

        public EncoderForm()
        {
            InitializeComponent();

            _comboBoxEncoderOnOff.SelectedIndex = 1;
            _comboBoxOperatingMode.SelectedIndex = 0;
            _comboBoxEnterMode.SelectedIndex = 0;
            _comboBoxDetectionEdge.SelectedIndex = 2;
            _comboBoxMinInputTime.SelectedIndex = 2;
            _comboBoxPulseCountOffsetDetectionLogic.SelectedIndex = 0;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                base.OnClosing(e);
                return;
            }
            if (!byte.TryParse(_comboBoxOperatingMode.SelectedIndex.ToString(), out _operatingMode))
            {
                MessageBox.Show(this, "operatingMode is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!byte.TryParse(_comboBoxEnterMode.SelectedIndex.ToString(), out _enterMode))
            {
                MessageBox.Show(this, "enterMode is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!short.TryParse(_textBoxDecimationPoint.Text, out _decimationPoint))
            {
                MessageBox.Show(this, "decimationPoint is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!byte.TryParse(_comboBoxDetectionEdge.SelectedIndex.ToString(), out _detectionEdge))
            {
                MessageBox.Show(this, "detectionEdge is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!byte.TryParse(_comboBoxMinInputTime.SelectedIndex.ToString(), out _minInputTime))
            {
                MessageBox.Show(this, "minInputTime is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!byte.TryParse(_comboBoxPulseCountOffsetDetectionLogic.SelectedIndex.ToString(), out _pulseCountOffsetDetectionLogic))
            {
                MessageBox.Show(this, "pulseCountOffsetDetectionLogic is Invalid Value");
                e.Cancel = true;
                return;
            }
            if (!int.TryParse(_textBoxPresetValue.Text, out _presetValue))
            {
                MessageBox.Show(this, "presetValue is Invalid Value");
                e.Cancel = true;
                return;
            }
            _encoderEncoderOnOff = _comboBoxEncoderOnOff.SelectedIndex == 0;

            base.OnClosing(e);
        }
    }
}
