using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmGiangVien : Form
    {
        public frmGiangVien()
        {
            InitializeComponent();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = open.FileName;
                pictureBox1.Image = Image.FromFile(txtAnh.Text);
            }

        }

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet24.tblGIANG_VIEN' table. You can move, or remove it, as needed.
            GiangVienBUS.Instance.FillGiangVienDGR(dgrDSGV);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GiangVienBUS.Instance.ThemGiangVien(errorProvider1, txtMaGV, txtHoTen, cboGioiTinh, mskPhone, txtEmail, cboPhanloai);
            //Fill du lieu 
            FillDataGridView_SV();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        public void FillDataGridView_SV()
        {
            GiangVienBUS.Instance.FillGiangVienDGR(dgrDSGV);

        }

        private void dgrDSGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GiangVienBUS.Instance.XoaGiangVien(txtMaGV);
            FillDataGridView_SV();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            GiangVienBUS.Instance.SuaGiangVien(errorProvider1,txtMaGV, txtHoTen, cboGioiTinh, mskPhone, txtEmail, cboPhanloai);
            FillDataGridView_SV();
        }


        private void dgrDSGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGV.Text = dgrDSGV.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSGV.CurrentRow.Cells[1].Value.ToString();
            cboGioiTinh.Text = dgrDSGV.CurrentRow.Cells[2].Value.ToString();
            mskPhone.Text = dgrDSGV.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgrDSGV.CurrentRow.Cells[4].Value.ToString();
            cboPhanloai.Text = dgrDSGV.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
