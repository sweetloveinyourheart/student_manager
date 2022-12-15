using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmDSThiLai : Form
    {

        public frmDSThiLai()
        {
            InitializeComponent();
        }

        private void frmDSThiLai_Load(object sender, EventArgs e)
        {
            KhoaBUS.Instance.FillKhoaList(cboKhoaHoc);
        }

        public void FillDataGridView_DSSV()
        {
            SinhVienBUS.Instance.FillSinhVienList(dgrDSSV);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonHocBUS.Instance.FillCBByHocKy(cboHocKi, cboMonHoc);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLop.Text = "";
            LopBUS.Instance.FillLopListMaKhoa(cboKhoaHoc, cboLop);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SinhVienBUS.Instance.FillSinhVienListByGhiChu(dgrDSSV, cboLoai);
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgrDSSV);
        }

    }
}
