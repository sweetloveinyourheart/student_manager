using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;



namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class Trogiup : Form
    {
        public Trogiup()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Baocao.ppt");

        }

        private void label8_Click(object sender, EventArgs e)
        {
            using (Process process = new Process())
            {
            process.StartInfo.FileName = "mailto:quocvanict@gmail.com";
            process.Start();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
