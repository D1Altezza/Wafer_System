﻿using System;
using System.Windows.Forms;

namespace Wafer_System.BaslerMutiCam
{
    class Helper
    {
        public static void ShowException(Exception exception)
        {
            MessageBox.Show("Exception caught:\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessage(String message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
