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
    public partial class frmQLDiem : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmQLDiem()
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
            KetQuaBUS.Instance.ThemKetQua(errorProvider1, dgrDiem, txtMaSV, cboLop, cboMonHoc, txtDiemThi1, txtDiemTB, txtDiemTK, cboHanhKiem, cboHocKi, txtGhiChu);
            //Load lai du lieu
            FillDataGridView_Diem();
        }

        public void FillDataGridView_Diem()
        {
            KetQuaBUS.Instance.FillKetQuaList(dgrDiem);
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
                // Thuc hien xoa du lieu
                KetQuaBUS.Instance.XoaKetQua(txtMaSV);

                //Load lai du lieu
                FillDataGridView_Diem();
            }
        }

        private void dgrDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDiem.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDiem.CurrentRow.Cells[1].Value.ToString();
            cboLop.Text = dgrDiem.CurrentRow.Cells[2].Value.ToString();
            cboMonHoc.Text = dgrDiem.CurrentRow.Cells[3].Value.ToString();
            txtDiemTB.Text = dgrDiem.CurrentRow.Cells[4].Value.ToString();
            txtDiemThi1.Text = dgrDiem.CurrentRow.Cells[5].Value.ToString();
            txtDiemTK.Text = dgrDiem.CurrentRow.Cells[7].Value.ToString();
            cboHanhKiem.Text = dgrDiem.CurrentRow.Cells[8].Value.ToString();
            cboHocKi.Text = dgrDiem.CurrentRow.Cells[9].Value.ToString();
            txtGhiChu.Text = dgrDiem.CurrentRow.Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KetQuaBUS.Instance.SuaKetQua(errorProvider1, dgrDiem, txtMaSV, cboLop, cboMonHoc, txtDiemThi1, txtDiemTB, txtDiemTK, cboHanhKiem, cboHocKi, txtGhiChu);
            FillDataGridView_Diem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void txtDiemTK_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void txtDiemThi2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiemThi1_TextChanged(object sender, EventArgs e )
        {
            double DIEMTHI, DIEMTB, DIEMTK;
            
            if (txtDiemThi1.Text == "")
            {
                this.txtDiemThi1.Text = "0";
                DIEMTB = double.Parse(this.txtDiemTB.Text);
              
                //Tính điểm TK
                DIEMTK = (0.3 * DIEMTB + 0.7 * 0);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            else if (txtDiemTB.Text == "")
            {
                this.txtDiemTB.Text = "0";
                DIEMTHI = double.Parse(this.txtDiemThi1.Text);

                //Tính điểm TK
                DIEMTK = (0.3 * 0 + 0.7 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }

            else
            {
                DIEMTHI = double.Parse(this.txtDiemThi1.Text);
                DIEMTB = double.Parse(this.txtDiemTB.Text);
                //Tính điểm TK
                DIEMTK =  (0.3 * DIEMTB + 0.7 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            DIEMTK = double.Parse(this.txtDiemTK.Text);
            if (DIEMTK <= 4.5)
            {
                this.txtGhiChu.Text = "Thi lại";
            }
            else 
            {
                this.txtGhiChu.Text  = "";
            }

        }

        private void txtDiemTB_TextChanged(object sender, EventArgs e)
        {
            double DIEMTHI, DIEMTB, DIEMTK;
            
            if (txtDiemTB.Text == "")
            {
                this.txtDiemTB.Text = "0";
                DIEMTHI = double.Parse(this.txtDiemThi1.Text);
                
                //Tính điểm TK
                DIEMTK = (0.3 * 0 + 0.7 *DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            else if (txtDiemThi1.Text == "")
            {
                this.txtDiemThi1.Text = "0";
                DIEMTB = double.Parse(this.txtDiemTB.Text);
              
                //Tính điểm TK
                DIEMTK = (0.3 * DIEMTB + 0.7 * 0);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
          
            else
            {
                DIEMTHI = double.Parse(this.txtDiemThi1.Text);
                DIEMTB = double.Parse(this.txtDiemTB.Text);
                //Tính điểm TK
                DIEMTK = (0.3 * DIEMTB + 0.7 * DIEMTHI);
                this.txtDiemTK.Text = Convert.ToString(DIEMTK);
            }
            DIEMTK = double.Parse(this.txtDiemTK.Text);
            if ((DIEMTK <= 4.5))
            {
                this.txtGhiChu.Text = "Thi lại";
            }
            else
            {
                this.txtGhiChu.Text  = "";
            }
           
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgrDiem);
        }

    }
}
