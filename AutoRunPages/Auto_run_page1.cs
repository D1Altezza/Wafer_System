using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Config_Fun;
using Wafer_System.Param_Settin_Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Wafer_System.Auto_run_page1;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Wafer_System
{
    public partial class Auto_run_page1 : Form
    {
        Systematics config;
        public class Autorun_Prarm
        {
            public Wafer_Material wafer_Material;
            public Wafer_Size wafer_Size;
            public Wafer_Notch wafer_Notch;
            public string classify_mode;
            public string file_name;
            public string cassette1_number;
            public string cassette2_number;
            public string cassette3_number;
        }
        public enum Wafer_Material
        {
            Si,
            Glass,
            unknow
        }
        public enum Wafer_Size
        {
            eight,
            tweleve,
            unknow
        }
        public enum Wafer_Notch
        {
            notch,
            flat,
            neither,
            unknow
        }
        public Autorun_Prarm autorun_Prarm;
        public Auto_run_page1(Systematics config)
        {
            InitializeComponent();
            autorun_Prarm = new Autorun_Prarm();
            this.config = config;
        }



        private void Auto_run_page1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                clear_setup();
                tmr_check.Start();
            }
            else
            {
                tmr_check.Stop();
            }
        }

        private void clear_setup()
        {
            foreach (var item in groupBox_WaferType.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
            }
            foreach (var item in groupBox_WaferSize.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
            }
            foreach (var item in groupBox_WaferNotch.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).Checked = false;
                }
            }
            foreach (var item in groupBox_Classify.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).Text = String.Empty;
                }
            }
            foreach (var item in groupBox_setup.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
            }
        }

        private void tmr_check_Tick(object sender, EventArgs e)
        {
            var type = radio_type_Si.Checked | radio_type_Glass.Checked;
            var size = radio_size_8inch.Checked | radio_size_12inch.Checked;
            var notch = radio_notch_v.Checked | radio_notch_flat.Checked | radio_notch_non.Checked;
            var classify = !string.IsNullOrEmpty(combo_Classify.Text);
            var txt = !string.IsNullOrEmpty(txt_cassette1_number.Text) & !string.IsNullOrEmpty(txt_cassette2_number.Text) &
                !string.IsNullOrEmpty(txt_cassette3_number.Text) & !string.IsNullOrEmpty(txt_file_name.Text);

            if (type && size && notch && classify && txt)
            {

                btn_Go_Page2.Enabled = true;
            }
            else
            {
                btn_Go_Page2.Enabled = false;
            }
        }

        private void combo_Classify_DropDown(object sender, EventArgs e)
        {
            combo_Classify.Items.Clear();
            if (config.Mode != null)
            {
                foreach (var item in config.Mode)
                {
                    combo_Classify.Items.Add(item.Name);
                }
            }
        }

        private void btn_next_page_Click(object sender, EventArgs e)
        {
            if (radio_type_Si.Checked)
            {
                autorun_Prarm.wafer_Material = Wafer_Material.Si;
            }
            else if (radio_type_Glass.Checked)
            {
                autorun_Prarm.wafer_Material = Wafer_Material.Glass;
            }
            else
            {
                autorun_Prarm.wafer_Material = Wafer_Material.unknow;
            }
            if (radio_notch_v.Checked)
            {
                autorun_Prarm.wafer_Notch = Wafer_Notch.notch;
            }
            else if (radio_notch_flat.Checked)
            {
                autorun_Prarm.wafer_Notch = Wafer_Notch.flat;
            }
            else if (radio_notch_non.Checked)
            {
                autorun_Prarm.wafer_Notch = Wafer_Notch.neither;
            }
            else
            {
                autorun_Prarm.wafer_Notch = Wafer_Notch.unknow;
            }
            if (radio_size_8inch.Checked)
            {
                autorun_Prarm.wafer_Size = Wafer_Size.eight;
            }
            else if (radio_size_12inch.Checked)
            {
                autorun_Prarm.wafer_Size = Wafer_Size.tweleve;
            }
            else
            {
                autorun_Prarm.wafer_Size = Wafer_Size.unknow;
            }
            autorun_Prarm.classify_mode = combo_Classify.Text;
            autorun_Prarm.file_name = txt_file_name.Text;
            autorun_Prarm.cassette1_number = txt_cassette1_number.Text;
            autorun_Prarm.cassette2_number = txt_cassette2_number.Text;
            autorun_Prarm.cassette3_number = txt_cassette3_number.Text;

            this.Hide();

        }
    }
}
