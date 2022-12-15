using System;
using System.Windows.Forms;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmMonHoc : Form
    {

        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet52.tblMON' table. You can move, or remove it, as needed.
            MonHocBUS.Instance.FillMonDGR(dgrMON);
            KhoaBUS.Instance.FillKhoaList(cboKhoa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonHocBUS.Instance.ThemMonHoc(errorProvider1, txtMaMon, txtTenMon, txtSDVHT, txtMaGV, txtHocKy, cboKhoa);
            FillDataGridView_MON();
            
        }
        public void FillDataGridView_MON()
        {
            MonHocBUS.Instance.FillMonDGR(dgrMON);
        }

        private void dgrMON_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Text = dgrMON.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = dgrMON.CurrentRow.Cells[1].Value.ToString();
            txtSDVHT.Text = dgrMON.CurrentRow.Cells[2].Value.ToString();
            txtMaGV.Text = dgrMON.CurrentRow.Cells[3].Value.ToString();
            txtHocKy.Text = dgrMON.CurrentRow.Cells[4].Value.ToString();
            cboKhoa.Text = dgrMON.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MonHocBUS.Instance.XoaMonHoc(txtMaMon);
            //Load lai du lieu
            FillDataGridView_MON();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            MonHocBUS.Instance.SuaMonHoc(txtMaMon, txtTenMon, txtSDVHT, txtMaGV, txtHocKy, cboKhoa);
            //Load lai du lieu
            FillDataGridView_MON();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
