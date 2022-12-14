using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Diagnostics;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmQLDiemThiLai : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmQLDiemThiLai()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopBUS.Instance.FillLopListMaKhoa(cboKhoaHoc, cboLop);
        }

        private void frmQLDiem_Load(object sender, EventArgs e)
        {     
            KhoaBUS.Instance.FillKhoaList(cboKhoaHoc);

            //Load lai du lieu
            FillDataGridView_Diem();

        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonHocBUS.Instance.FillCBByHocKy(cboHocKi, cboMonHoc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KetQua2BUS.Instance.ThemKetQua2(errorProvider1, txtMaSV, cboLop, cboMonHoc, txtDiemThi2, cboHocKi);
            //Load lai du lieu
            FillDataGridView_Diem();
        }

        public void FillDataGridView_Diem()
        {
            KetQua2BUS.Instance.FillKetQua2List(dgrDiem);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KetQua2BUS.Instance.XoaKetQua2(txtMaSV);
                FillDataGridView_Diem();
            }
        }

        private void dgrDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDiem.CurrentRow.Cells[0].Value.ToString();
            cboLop.Text = dgrDiem.CurrentRow.Cells[2].Value.ToString();
            cboMonHoc.Text = dgrDiem.CurrentRow.Cells[3].Value.ToString();  
            txtDiemThi2.Text = dgrDiem.CurrentRow.Cells[4].Value.ToString();
            cboHocKi.Text = dgrDiem.CurrentRow.Cells[5].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KetQua2BUS.Instance.SuaKetQua2(errorProvider1, txtMaSV, cboLop, cboMonHoc, txtDiemThi2, cboHocKi);
            FillDataGridView_Diem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgrDiem);
        }

    }
}
