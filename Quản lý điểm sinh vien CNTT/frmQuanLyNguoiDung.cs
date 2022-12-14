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

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmQuanLyNguoiDung : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            //Kiem tra trung TenDN
            string select2 = "Select * From tblLOGIN where TenDN='" + txtTaikhoan.Text + "'";
            SqlCommand cmd2 = new SqlCommand(select2, conn);
            SqlDataReader reader2;
            reader2 = cmd2.ExecuteReader();

            errorProvider1.Clear();
            if (txtTaikhoan.Text == "")
            {
                errorProvider1.SetError(txtTaikhoan, "Tên tài khoản không  để trống !");
                txtTaikhoan.Focus();
            }
            else if (txtMK.Text == "")
            {
                errorProvider1.SetError(txtMK, "Bạn chưa nhập mật khẩu !");
                txtMK.Focus();
            }
            else if (txtConfimMk.Text == "")
            {
                errorProvider1.SetError(txtConfimMk, "Bạn chưa nhập lại mật khẩu !");
                txtConfimMk.Focus();
            }
            else if (txtConfimMk.Text != txtMK.Text)
           
                MessageBox.Show("Bạn nhập lại mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (reader2.Read())
            {
                MessageBox.Show("Tài khoản " + txtTaikhoan.Text + " đã tồn tại", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
                cmd2.Dispose();
                reader2.Dispose();
            }
            else
            {
                // Trả tài nguyên
                cmd2.Dispose();
                reader2.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblLOGIN(TenDN,MatKhau,HoTen,Gioitinh,Phone,Email,Quyen)" +
                                "Values('" + txtTaikhoan.Text + "','" + txtMK.Text + "',N'" + txtHoTen.Text + "',N'" + cboGioiTinh.Text + "','" +
                                mskPhone.Text + "','" + txtEmail.Text + "',N'" + cboQuyen.Text + "')";
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
            FillDataGridView_Login();
        }

        private void frmQuanLyNguoiDung_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet25.tblLOGIN' table. You can move, or remove it, as needed.
            this.tblLOGINTableAdapter.Fill(this.quanlydiemDataSet25.tblLOGIN);
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;
            //Fill du lieu 
            FillDataGridView_Login();
        }
        public void FillDataGridView_Login()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblLOGIN  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrLogin.DataSource = ds;
            dgrLogin.DataMember = "SINHVIEN";
            cmd.Dispose();
        }

        private void dgrLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaikhoan.Text = dgrLogin.CurrentRow.Cells[0].Value.ToString();
            txtMK.Text = dgrLogin.CurrentRow.Cells[1].Value.ToString();
            txtHoTen.Text = dgrLogin.CurrentRow.Cells[2].Value.ToString();
            cboGioiTinh.Text = dgrLogin.CurrentRow.Cells[3].Value.ToString();
            mskPhone.Text = dgrLogin.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dgrLogin.CurrentRow.Cells[5].Value.ToString();
            cboQuyen.Text = dgrLogin.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu

                SqlCommand cmd = new SqlCommand("delete from tblLOGIN where TenDN='" + txtTaikhoan.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                //Fill du lieu 
                FillDataGridView_Login();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtTaikhoan.Text == "")
                errorProvider1.SetError(txtTaikhoan, "Tên tài khoản không để trống!");
            else
            {
                // Thực hiện truy vấn
                string update = "Update tblLOGIN Set MatKhau=N'" + txtMK.Text + "',HoTen=N'" + txtHoTen.Text + "',GioiTinh=N'" +
                                cboGioiTinh.Text + "',Phone='" + mskPhone.Text + "',Email='" +
                                txtEmail.Text + "',Quyen=N'" + cboQuyen.Text + "' where TenDN='" + txtTaikhoan.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!");
                //Load lai du lieu
                FillDataGridView_Login();
                // Trả tài nguyên
                cmd.Dispose();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
