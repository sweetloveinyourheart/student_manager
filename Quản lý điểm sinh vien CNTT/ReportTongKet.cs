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
    public partial class ReportTongKet : Form
    {
        public ReportTongKet()
        {
            InitializeComponent();
        }

        private void ReportTongKet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSettongketdiem.tblKET_QUA' table. You can move, or remove it, as needed.
            this.tblKET_QUATableAdapter.Fill(this.DataSettongketdiem.tblKET_QUA);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
