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
using System.IO;
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmGiangVien : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
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
       
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Kiem tra trung ten MaSV
            string select2 = "Select * From tblGIANG_VIEN where MaGV='" + txtMaGV.Text + "'";
            SqlCommand cmd2 = new SqlCommand(select2, conn);
            SqlDataReader reader2;
            reader2 = cmd2.ExecuteReader();

            errorProvider1.Clear();
            if (txtMaGV.Text == "")
            {
                errorProvider1.SetError(txtMaGV, "Mã giảng viên không để trống!");
            }

            else if (reader2.Read())
            {
                MessageBox.Show("Bạn đã nhập trùng mã giảng viên", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
                cmd2.Dispose();
                reader2.Dispose();
            }
            else
            {
                // Trả tài nguyên
                cmd2.Dispose();
                reader2.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblGIANG_VIEN(MaGV,TenGV,Gioitinh,Phone,Email,PhanloaiGV)" +
                                "Values('" + txtMaGV.Text + "',N'" + txtHoTen.Text + "',N'" + cboGioiTinh.Text + "','" +
                                mskPhone.Text + "','" + txtEmail.Text + "',N'" + cboPhanloai.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm mới thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();

            }
            // Trả tài nguyên
            cmd2.Dispose();
            reader2.Dispose();
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
            // Thực hiện truy vấn
            string select = "Select * From tblGIANG_VIEN  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrDSGV.DataSource = ds;
            dgrDSGV.DataMember = "SINHVIEN";
            cmd.Dispose();
        }

        private void dgrDSGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu

                SqlCommand cmd = new SqlCommand("delete from tblGIANG_VIEN where MaGV='" + txtMaGV.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                //Load lai du lieu
                FillDataGridView_SV();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (txtMaGV.Text == "")
                errorProvider1.SetError(txtMaGV, "Mã giảng viên không để trống!");
            else
            {
                // Thực hiện truy vấn
                string update = "Update tblGIANG_VIEN Set TenGV=N'" + txtHoTen.Text + "',GioiTinh=N'" + 
                                cboGioiTinh.Text + "',Phone='" + mskPhone.Text + "',Email='" + 
                                txtEmail.Text + "',PhanLoaiGV=N'" + cboPhanloai.Text + "' where MaGV='" + txtMaGV.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!");
                //Load lai du lieu
                FillDataGridView_SV();
                // Trả tài nguyên
                cmd.Dispose();
            }
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
