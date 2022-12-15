using System;
using System.Windows.Forms;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmQLSV : Form
    {
        public frmQLSV()
        {
            InitializeComponent();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {

            //Add du lieu vao cboKhoa
            KhoaBUS.Instance.FillKhoaList(cboKhoahoc);

            //Add du lieu vao MaLop
            LopBUS.Instance.FillLopList(cboLop);

            //Load lai du lieu
            FillDataGridView_SV();
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgrDSSV.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSSV.CurrentRow.Cells[1].Value.ToString();
            mskNgaySinh.Text = dgrDSSV.CurrentRow.Cells[2].Value.ToString();
            cboGioiTinh.Text = dgrDSSV.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dgrDSSV.CurrentRow.Cells[4].Value.ToString();
            cboMalop.Text = dgrDSSV.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            SinhVienBUS.Instance.ThemSinhVien(
                errorProvider1,
                txtMaSV,
                txtHoTen,
                txtDiaChi,
                mskNgaySinh,
                cboGioiTinh,
                cboMalop
                );
            FillDataGridView_SV();
        }
        public void FillDataGridView_SV()
        {
            SinhVienBUS.Instance.FillSinhVienList(dgrDSSV);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Kiem tra 
            SinhVienBUS.Instance.XoaSinhVien(txtMaSV);
            FillDataGridView_SV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVienBUS.Instance.SuaSinhVien(
                errorProvider1,
                txtMaSV,
                txtHoTen,
                txtDiaChi,
                mskNgaySinh,
                cboGioiTinh,
                cboMalop
                );
            FillDataGridView_SV();

        }

        private void cboKhoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           LopBUS.Instance.FillLopListMaKhoa(cboKhoahoc, cboLop);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Đưa ra DataGridView
            SinhVienBUS.Instance.FillSinhVienListByMaLop(dgrDSSV, cboLop);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
