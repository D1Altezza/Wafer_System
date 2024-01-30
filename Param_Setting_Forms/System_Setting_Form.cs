
using Azuria.Controls.ColorPicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Config_Fun;
using Wafer_System.Log_Fun;
using Wafer_System.Param_Setting_Forms;
using Label = System.Windows.Forms.Label;

namespace Wafer_System.Param_Settin_Forms
{
    public partial class System_Setting_Form : Form
    {
        private LogRW logRW;
        private ConfigWR configWR;
        IniRW iniRW_Morph;
        public List<PointF> Path_8Inch = new List<PointF>();
        public List<PointF> Path_12Inch = new List<PointF>();
        public Systematics config;
        Systematics_RW systematics_RW;
        string FilePath;
        Classify classify;
        List<GradeScore> gradeScores = new List<GradeScore>();
        public System_Setting_Form(LogRW logRW, ConfigWR configWR)
        {
            InitializeComponent();
            this.logRW = logRW;
            this.configWR = configWR;
            var str = System.Environment.CurrentDirectory;
            iniRW_Morph = new IniRW(str + "\\MorphPath.ini");

            string DIRNAME = Application.StartupPath + @"\Classify";
            if (!Directory.Exists(DIRNAME))
                Directory.CreateDirectory(DIRNAME);
            Path_Setting_UI();

            config = new Systematics();
            systematics_RW = new Systematics_RW();


            FilePath = DIRNAME + "\\Classify.json";
            var tt = systematics_RW.ReadConfiguration(FilePath, config);

            Classify_Setup_UI();
            combo_Mode_update();

        }

        #region Path UI Build        
        private void Path_Setting_UI()
        {
            var index = 0;
            foreach (Settings_Param_Enum.ScanPath_Setting para_ in Enum.GetValues(typeof(Settings_Param_Enum.ScanPath_Setting)))
            {
                Label DynamicSettingLabel = new Label();
                DynamicSettingLabel.Name = "lb_" + para_;
                DynamicSettingLabel.Text = para_.ToString();
                DynamicSettingLabel.TextAlign = ContentAlignment.MiddleLeft;
                DynamicSettingLabel.Margin = new Padding(10, 8, 0, 0);
                DynamicSettingLabel.Font = new Font("Consolas", 9.0F, FontStyle.Regular);
                DynamicSettingLabel.AutoSize = false;

                NumericUpDown DynamicSettingNu = new NumericUpDown();
                DynamicSettingNu.Name = "nu_" + para_;
                DynamicSettingNu.TextAlign = HorizontalAlignment.Left;
                DynamicSettingNu.Margin = new Padding(0, 5, 50, 0);
                DynamicSettingNu.Font = new Font("Consolas", 9.0F, FontStyle.Regular);
                DynamicSettingNu.Maximum = 1000000;
                DynamicSettingNu.Minimum = -1000000;
                DynamicSettingNu.DecimalPlaces = 3;
                DynamicSettingNu.Increment = 1;
                DynamicSettingNu.AutoSize = false;
                DynamicSettingNu.Dock = DockStyle.Fill;
                DynamicSettingNu.ValueChanged += DynamicSettingNu_ValueChanged;

                if (Regex.IsMatch(para_.ToString(), @"^Scan_8_X"))
                {
                    if (DynamicSettingNu.Name == "nu_Scan_8_X_1" || DynamicSettingNu.Name == "nu_Scan_8_X_2"
                        || DynamicSettingNu.Name == "nu_Scan_8_X_3" || DynamicSettingNu.Name == "nu_Scan_8_X_4"
                        || DynamicSettingNu.Name == "nu_Scan_8_X_27" || DynamicSettingNu.Name == "nu_Scan_8_X_28"
                        || DynamicSettingNu.Name == "nu_Scan_8_X_29" || DynamicSettingNu.Name == "nu_Scan_8_X_30")
                    {
                        DynamicSettingNu.Enabled = false;
                    }
                    tbLP_8_Morph_Path.Controls.Add(DynamicSettingLabel, 0, index);
                    DynamicSettingNu.Value = Convert.ToDecimal(iniRW_Morph.GetValue(para_.ToString(), "8Inch", "0"));
                    tbLP_8_Morph_Path.Controls.Add(DynamicSettingNu, 1, index);
                }
                else if (Regex.IsMatch(para_.ToString(), @"^Scan_8_Y"))
                {
                    if (DynamicSettingNu.Name == "nu_Scan_8_Y_1" || DynamicSettingNu.Name == "nu_Scan_8_Y_2"
                        || DynamicSettingNu.Name == "nu_Scan_8_Y_3" || DynamicSettingNu.Name == "nu_Scan_8_Y_4"
                        || DynamicSettingNu.Name == "nu_Scan_8_Y_27" || DynamicSettingNu.Name == "nu_Scan_8_Y_28"
                        || DynamicSettingNu.Name == "nu_Scan_8_Y_29" || DynamicSettingNu.Name == "nu_Scan_8_Y_30")
                    {
                        DynamicSettingNu.Enabled = false;
                    }
                    tbLP_8_Morph_Path.Controls.Add(DynamicSettingLabel, 2, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_8_Y_1));
                    DynamicSettingNu.Value = Convert.ToDecimal(iniRW_Morph.GetValue(para_.ToString(), "8Inch", "0"));
                    tbLP_8_Morph_Path.Controls.Add(DynamicSettingNu, 3, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_8_Y_1));
                }
                else if (Regex.IsMatch(para_.ToString(), @"^Scan_12_X"))
                {
                    tbLP_12_Morph_Path.Controls.Add(DynamicSettingLabel, 0, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_12_X_1));
                    DynamicSettingNu.Value = Convert.ToDecimal(iniRW_Morph.GetValue(para_.ToString(), "12Inch", "0"));
                    tbLP_12_Morph_Path.Controls.Add(DynamicSettingNu, 1, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_12_X_1));
                }
                else if (Regex.IsMatch(para_.ToString(), @"^Scan_12_Y"))
                {
                    tbLP_12_Morph_Path.Controls.Add(DynamicSettingLabel, 2, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_12_Y_1));
                    DynamicSettingNu.Value = Convert.ToDecimal(iniRW_Morph.GetValue(para_.ToString(), "12Inch", "0"));
                    tbLP_12_Morph_Path.Controls.Add(DynamicSettingNu, 3, index - ((int)Settings_Param_Enum.ScanPath_Setting.Scan_12_Y_1));
                }
                #region Creat INI
                //if (Regex.IsMatch(DynamicSettingNu.Name, @"^nu_Scan_8_"))
                //{
                //    iniRW.WriteValue(DynamicSettingNu.Name.Remove(0, 3), "8Inch", DynamicSettingNu.Value.ToString());
                //}
                //else if (Regex.IsMatch(DynamicSettingNu.Name, @"^nu_Scan_12_"))
                //{
                //    iniRW.WriteValue(DynamicSettingNu.Name.Remove(0, 3), "12Inch", DynamicSettingNu.Value.ToString());
                //}
                //iniRW.Save();
                #endregion
                index++;
            }
            Button Dynamic_UpdateSettingButton = new Button();
            Dynamic_UpdateSettingButton.Name = "btn_Path_Update";
            Dynamic_UpdateSettingButton.Text = "Update";
            Dynamic_UpdateSettingButton.TextAlign = ContentAlignment.MiddleCenter;
            Dynamic_UpdateSettingButton.Margin = new Padding(0, 10, 0, 0);
            Dynamic_UpdateSettingButton.Font = new Font("Consolas", 9.0F, FontStyle.Regular);
            Dynamic_UpdateSettingButton.AutoSize = true;
            Dynamic_UpdateSettingButton.Dock = DockStyle.Fill;
            tbLP_8_Morph_Path.Controls.Add(Dynamic_UpdateSettingButton, 1, tbLP_8_Morph_Path.RowCount);
            tbLP_12_Morph_Path.Controls.Add(Dynamic_UpdateSettingButton, 1, tbLP_12_Morph_Path.RowCount);
            Dynamic_UpdateSettingButton.Click += Dynamic_UpdateSettingButton_Click;
            Path_Generator();
        }

        private void Dynamic_UpdateSettingButton_Click(object sender, EventArgs e)
        {
            Path_Generator();
        }

        private void DynamicSettingNu_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = (NumericUpDown)sender;
            if (Regex.IsMatch(upDown.Name, @"^nu_Scan_8_"))
            {
                iniRW_Morph.WriteValue(upDown.Name.Remove(0, 3), "8Inch", upDown.Value.ToString());
            }
            else if (Regex.IsMatch(upDown.Name, @"^nu_Scan_12_"))
            {
                iniRW_Morph.WriteValue(upDown.Name.Remove(0, 3), "12Inch", upDown.Value.ToString());
            }
            iniRW_Morph.Save();
        }
        #endregion

        #region Path Generator
        private void Path_Generator()
        {
            Path_8Inch.Clear();
            Path_12Inch.Clear();
            for (int i = 1; i < 31; i++)
            {
                if (i > 4 && i < 27)
                {
                    var x = float.Parse(iniRW_Morph.GetValue("Scan_8_X_" + i, "8Inch", "0"));
                    var y = float.Parse(iniRW_Morph.GetValue("Scan_8_Y_" + i, "8Inch", "0"));
                    Path_8Inch.Add(new PointF(x, y));
                }

                var x1 = float.Parse(iniRW_Morph.GetValue("Scan_12_X_" + i, "12Inch", "0"));
                var y1 = float.Parse(iniRW_Morph.GetValue("Scan_12_Y_" + i, "12Inch", "0"));
                Path_12Inch.Add(new PointF(x1, y1));
            }
        }
        #endregion

        #region Classify UI Build
        string[] classify_column = new string[] { "評比階級", "分級標準", "容許誤差上限", "容許誤差下限", "標記顏色" };
        private void Classify_Setup_UI()
        {
            Label _label;
            TextBox _textBox;
            NumericUpDown _numericUpDown;
            ColorPicker colorPicker;
            for (int i = 0; i < tbp_Classify_Setup.ColumnCount; i++)
            {
                _label = new Label();
                _label.TextAlign = ContentAlignment.MiddleLeft;
                _label.Margin = new Padding(3, 3, 3, 3);
                _label.Font = new Font("Consolas", 14.0F, FontStyle.Regular);
                _label.AutoSize = true;
                _label.Dock = DockStyle.Fill;
                _label.Text = classify_column[i];
                tbp_Classify_Setup.Controls.Add(_label, i, 0);
            }
            for (int i = 1; i < tbp_Classify_Setup.RowCount + 1; i++)
            {
                _textBox = new TextBox();
                _textBox.Margin = new Padding(3, 3, 3, 3);
                _textBox.Font = new Font("Consolas", 14.0F, FontStyle.Regular);
                _textBox.AutoSize = true;
                _textBox.Dock = DockStyle.Fill;
                _textBox.Text = i.ToString();
                _textBox.TextChanged += _textBox_TextChanged;
                tbp_Classify_Setup.Controls.Add(_textBox, 0, i);
                _textBox.Hide();
                _numericUpDown = new NumericUpDown();
                _numericUpDown.Margin = new Padding(3, 3, 3, 3);
                _numericUpDown.Font = new Font("Consolas", 14.0F, FontStyle.Regular);
                _numericUpDown.AutoSize = false;
                _numericUpDown.Dock = DockStyle.Fill;
                _numericUpDown.ValueChanged += _numericUpDown_ValueChanged;
                tbp_Classify_Setup.Controls.Add(_numericUpDown, 1, i);
                _numericUpDown.Hide();
                _numericUpDown = new NumericUpDown();
                _numericUpDown.Margin = new Padding(3, 3, 3, 3);
                _numericUpDown.Font = new Font("Consolas", 14.0F, FontStyle.Regular);
                _numericUpDown.AutoSize = false;
                _numericUpDown.Dock = DockStyle.Fill;
                _numericUpDown.ValueChanged += _numericUpDown_ValueChanged;
                tbp_Classify_Setup.Controls.Add(_numericUpDown, 2, i);
                _numericUpDown.Hide();
                _numericUpDown = new NumericUpDown();
                _numericUpDown.Margin = new Padding(3, 3, 3, 3);
                _numericUpDown.Font = new Font("Consolas", 14.0F, FontStyle.Regular);
                _numericUpDown.AutoSize = false;
                _numericUpDown.Dock = DockStyle.Fill;
                _numericUpDown.ValueChanged += _numericUpDown_ValueChanged;
                tbp_Classify_Setup.Controls.Add(_numericUpDown, 3, i);
                _numericUpDown.Hide();
                colorPicker = new ColorPicker();
                colorPicker.Margin = new Padding(3, 3, 3, 3);
                colorPicker.Font = new Font("Consolas", 12.0F, FontStyle.Regular);
                colorPicker.AutoSize = false;
                colorPicker.Items = new KnownColorCollection(KnownColorFilter.Web);
                colorPicker.Dock = DockStyle.Fill;
                colorPicker.SelectedValueChanged += ColorPicker_SelectedValueChanged;
                tbp_Classify_Setup.Controls.Add(colorPicker, 4, i);
                colorPicker.Hide();
            }
        }
        int edit_row = 1;
        string edit_value;
        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            edit_row = tbp_Classify_Setup.GetRow(textBox);
            edit_value = textBox.Text;
        }

        private void ColorPicker_SelectedValueChanged(object sender, EventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            edit_row = tbp_Classify_Setup.GetRow(colorPicker);
            edit_value=colorPicker.Text;
        }

        private void _numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            edit_row = tbp_Classify_Setup.GetRow(numericUpDown);
            edit_value = numericUpDown.Text;
        }


        #endregion

        private void btn_Create_Classify_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Creat_Name.Text))
            {
                var exists = false;
                //判斷分級模式是否已存在
                if (config.Mode != null)
                {
                    exists = config.Mode.Exists(o => (o.Name).Contains(txt_Creat_Name.Text));
                }
                else
                {
                    config.Mode = new List<Classify>();
                }
                if (!exists)
                {
                    classify = new Classify();
                    classify.Name = txt_Creat_Name.Text;
                    classify.DiameterLevel = new List<GradeScore>();
                    classify.ThicknessLevel = new List<GradeScore>();
                    classify.TTVLevel = new List<GradeScore>();
                    classify.BowLevel = new List<GradeScore>();
                    classify.WARPLevel = new List<GradeScore>();
                    config.Mode.Add(classify);
                    systematics_RW.SaveConfiguration(FilePath, config);
                    combo_Mode_update();
                    combo_Mode.SelectedItem = classify.Name;
                }
                else
                {
                    MessageBox.Show("exists");
                }
            }
            else
            {
                MessageBox.Show("name empty");
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            config.Mode.Clear();
            systematics_RW.ReadConfiguration(FilePath, config);
            var t = new List<GradeScore>();
            //combo_Mode
            //combo_Detect_Item
            switch (combo_Detect_Item.SelectedItem)
            {
                case "Diameter":
                    t = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel;
                    break;
                case "Thickness":
                    t = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel;
                    break;
                case "TTV":
                    t = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel;
                    break;
                case "BOW":
                    t = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel;
                    break;
                case "WARP":
                    t = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel;
                    break;
            }
            combo_Classify.SelectedIndex = t.Count - 1;
            for (int i = 0; i < t.Count; i++)
            {
                for (int j = 0; j < tbp_Classify_Setup.ColumnCount; j++)
                {
                    var row = tbp_Classify_Setup.GetControlFromPosition(j, i + 1);
                    switch (j)
                    {
                        case 0:
                            row.Text = t[i].Grade;
                            break;
                        case 1:
                            row.Text = t[i].Threshold;
                            break;
                        case 2:
                            row.Text = t[i].hLimit;
                            break;
                        case 3:
                            row.Text = t[i].lLimit;
                            break;
                        case 4:
                            row.Text = t[i].Mark;
                            break;
                    }
                }
            }

        }

        private void combo_Mode_update()
        {
            combo_Mode.Items.Clear();
            if (config.Mode != null)
            {
                foreach (var item in config.Mode)
                {
                    combo_Mode.Items.Add(item.Name);
                }
            }


        }

        private void combo_Classify_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in tbp_Classify_Setup.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = String.Empty;
                }
                if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 0;
                }
                if (item is ColorPicker)
                {
                    ((ColorPicker)item).SelectedIndex = 136;
                }
            }

            for (int i = 1; i < tbp_Classify_Setup.RowCount + 1; i++)
            {
                for (int j = 0; j < tbp_Classify_Setup.ColumnCount; j++)
                {
                    var row = tbp_Classify_Setup.GetControlFromPosition(j, i);

                    if (i < Convert.ToInt32(combo_Classify.Text) + 1)
                    {
                        row.Show();
                    }
                    else
                    {
                        row.Hide();
                    }
                }
            }
        }

        private void btn_Save_Param_Click(object sender, EventArgs e)
        {
            tpb_to_grade_scores();
            switch (combo_Detect_Item.SelectedItem)
            {
                case "Diameter":
                    classify_update("Diameter");
                    break;
                case "Thickness":
                    classify_update("Thickness");
                    break;
                case "TTV":
                    classify_update("TTV");
                    break;
                case "BOW":
                    classify_update("BOW");
                    break;
                case "WARP":
                    classify_update("WARP");
                    break;
            }
            systematics_RW.SaveConfiguration(FilePath, config);
        }

        private void btn_Del_Param_Click(object sender, EventArgs e)
        {
            gradeScores.Clear();
            switch (combo_Detect_Item.SelectedItem)
            {
                case "Diameter":
                    gradeScores = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel;
                    break;
                case "Thickness":
                    gradeScores = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel;
                    break;
                case "TTV":
                    gradeScores = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel;
                    break;
                case "BOW":
                    gradeScores = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel;
                    break;
                case "WARP":
                    gradeScores = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel;
                    break;
            }
        }

        private void classify_update(string detection)
        {
            bool exists = false;
            GradeScore score;
            foreach (var item in gradeScores)
            {
                switch (detection)
                {
                    case "Diameter":
                        exists = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel.Exists(o => (o.Grade).Contains(item.Grade));
                        break;
                    case "Thickness":
                        exists = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel.Exists(o => (o.Grade).Contains(item.Grade));
                        break;
                    case "TTV":
                        exists = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel.Exists(o => (o.Grade).Contains(item.Grade));
                        break;
                    case "BOW":
                        exists = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel.Exists(o => (o.Grade).Contains(item.Grade));
                        break;
                    case "WARP":
                        exists = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel.Exists(o => (o.Grade).Contains(item.Grade));
                        break;
                }

                if (exists)
                {
                    switch (detection)
                    {
                        case "Diameter":
                            score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel.Find(o => (o.Grade).Contains(item.Grade));                           
                            score.hLimit = item.hLimit;
                            score.lLimit = item.lLimit;
                            score.Threshold = item.Threshold;
                            score.Mark = item.Mark;
                            break;
                        case "Thickness":
                            score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel.Find(o => (o.Grade).Contains(item.Grade));
                            score.hLimit = item.hLimit;
                            score.lLimit = item.lLimit;
                            score.Threshold = item.Threshold;
                            score.Mark = item.Mark;
                            break;
                        case "TTV":
                            score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel.Find(o => (o.Grade).Contains(item.Grade));
                            score.hLimit = item.hLimit;
                            score.lLimit = item.lLimit;
                            score.Threshold = item.Threshold;
                            score.Mark = item.Mark;
                            break;
                        case "BOW":
                            score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel.Find(o => (o.Grade).Contains(item.Grade));
                            score.hLimit = item.hLimit;
                            score.lLimit = item.lLimit;
                            score.Threshold = item.Threshold;
                            score.Mark = item.Mark;
                            break;
                        case "WARP":
                            score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel.Find(o => (o.Grade).Contains(item.Grade));
                            score.hLimit = item.hLimit;
                            score.lLimit = item.lLimit;
                            score.Threshold = item.Threshold;
                            score.Mark = item.Mark;
                            break;
                    }
                }
                else
                {
                    switch (detection)
                    {
                        case "Diameter":
                            if (config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel.Count<edit_row)
                            {
                                config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel.Add(item);
                            }
                            else
                            {
                                score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).DiameterLevel[edit_row - 1];
                                score.Grade=item.Grade; 
                                score.hLimit = item.hLimit;
                                score.lLimit = item.lLimit;
                                score.Threshold = item.Threshold;
                                score.Mark = item.Mark;
                            }
                           
                            break;
                        case "Thickness":
                            if (config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel.Count < edit_row)
                            {
                                config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel.Add(item);
                            }
                            else
                            {
                                score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).ThicknessLevel[edit_row - 1];
                                score.Grade = item.Grade;
                                score.hLimit = item.hLimit;
                                score.lLimit = item.lLimit;
                                score.Threshold = item.Threshold;
                                score.Mark = item.Mark;
                            }
                            break;
                        case "TTV":
                            if (config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel.Count < edit_row)
                            {
                                config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel.Add(item);
                            }
                            else
                            {
                                score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).TTVLevel[edit_row - 1];
                                score.Grade = item.Grade;
                                score.hLimit = item.hLimit;
                                score.lLimit = item.lLimit;
                                score.Threshold = item.Threshold;
                                score.Mark = item.Mark;
                            }
                            break;
                        case "BOW":
                            if (config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel.Count < edit_row)
                            {
                                config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel.Add(item);
                            }
                            else
                            {
                                score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).BowLevel[edit_row - 1];
                                score.Grade = item.Grade;
                                score.hLimit = item.hLimit;
                                score.lLimit = item.lLimit;
                                score.Threshold = item.Threshold;
                                score.Mark = item.Mark;
                            }
                            break;
                        case "WARP":
                            if (config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel.Count < edit_row)
                            {
                                config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel.Add(item);
                            }
                            else
                            {
                                score = config.Mode.Find(o => o.Name == (string)combo_Mode.SelectedItem).WARPLevel[edit_row - 1];
                                score.Grade = item.Grade;
                                score.hLimit = item.hLimit;
                                score.lLimit = item.lLimit;
                                score.Threshold = item.Threshold;
                                score.Mark = item.Mark;
                            }
                            break;
                    }
                }
            }
        }

        private void tpb_to_grade_scores()
        {
            gradeScores.Clear();
            for (int i = 1; i < tbp_Classify_Setup.RowCount; i++)
            {
                var s = new GradeScore();
                for (int j = 0; j < tbp_Classify_Setup.ColumnCount; j++)
                {

                    var row = tbp_Classify_Setup.GetControlFromPosition(j, i);

                    switch (j)
                    {
                        case 0:
                            s.Grade = row.Text;
                            break;
                        case 1:
                            s.Threshold = row.Text;
                            break;
                        case 2:
                            s.hLimit = row.Text;
                            break;
                        case 3:
                            s.lLimit = row.Text;
                            break;
                        case 4:
                            s.Mark = row.Text;
                            break;
                    }

                }
                gradeScores.Add(s);
            }
        }


        #region Form close


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown
                 || e.CloseReason == CloseReason.ApplicationExitCall
                 || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            e.Cancel = true;
            this.Hide();
        }
        public void System_Setting_Form_Close()
        {
        }





        #endregion

       
    }
}
