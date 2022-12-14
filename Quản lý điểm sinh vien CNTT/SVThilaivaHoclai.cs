using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class SVThilaivaHoclai : Form
    {
        public SVThilaivaHoclai()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportDSThilai frm = new ReportDSThilai();
            
        }
    }
}
