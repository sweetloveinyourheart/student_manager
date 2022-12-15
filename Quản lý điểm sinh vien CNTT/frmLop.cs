using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmLop : Form
    {

        public frmLop()
        {
            InitializeComponent();
        }

        private void txtMaKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet37.tblLOP' table. You can move, or remove it, as needed.
            KhoaBUS.Instance.FillKhoaList(cboKhoa);

            //Load lai du lieu
            FillDataGridView_Lop();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            LopBUS.Instance.ThemLop(errorProvider1, txtTenlop, txtTenlop, cboKhoa);
            FillDataGridView_Lop();
        }
        public void FillDataGridView_Lop()
        {
            LopBUS.Instance.FillLopDGR(dgrLop);
        }

        private void dgrLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboKhoa.Text = dgrLop.CurrentRow.Cells[0].Value.ToString();
            txtMaLop.Text = dgrLop.CurrentRow.Cells[1].Value.ToString();
            txtTenlop.Text = dgrLop.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LopBUS.Instance.XoaLop(txtMaLop);
            //Load lai du lieu
            FillDataGridView_Lop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            LopBUS.Instance.SuaLop(txtMaLop, txtTenlop, cboKhoa);
            //Load lai du lieu
            FillDataGridView_Lop();
        }


    }
}
