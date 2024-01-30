using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wafer_System
{
    public partial class Auto_run_page0 : Form
    {
        private const int EM_GETLINECOUNT = 0xba;
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);
        public Auto_run_page0()
        {
            InitializeComponent();
        }

        private void Auto_run_page0_Load(object sender, EventArgs e)
        {
            txt_IniStatus.Text += "\r\n";
        }

        private void txt_IniStatus_TextChanged(object sender, EventArgs e)
        {
            var numberOfLines = SendMessage(txt_IniStatus.Handle.ToInt32(), EM_GETLINECOUNT, 0, 0);
            this.txt_IniStatus.Height = (txt_IniStatus.Font.Height + 2) * numberOfLines;
        }
    }
}
