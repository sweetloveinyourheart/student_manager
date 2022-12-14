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

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmKhoa : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select1 = "Select MaKhoa from tblKHOA where MaKhoa='" + txtKhoa.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            errorProvider1.Clear();
            if (txtKhoa.Text == "")
            {
                errorProvider1.SetError(txtKhoa, "Khóa học không để trống!");
                txtTenKhoa.Focus();
            }
            else if (reader1.Read())
            {
                {
                    MessageBox.Show("Thông tin đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKhoa.Focus();

                }


                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
            }
            else
            {
                reader1.Dispose();
                cmd1.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblKHOA(MaKhoa,TenKhoa)" +
                "Values('" + txtKhoa.Text + "',N'" + txtTenKhoa.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");

                // Trả tài nguyên


                cmd.Dispose();
                //Fill du lieu vao Database
                FillDataGridView_Khoa();
            }
        }

        public void FillDataGridView_Khoa()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblKHOA  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrKhoa.DataSource = ds;
            dgrKhoa.DataMember = "SINHVIEN";
            cmd.Dispose();
        }

        private void frmLop_Khoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet50.tblKHOA' table. You can move, or remove it, as needed.
            this.tblKHOATableAdapter.Fill(this.quanlydiemDataSet50.tblKHOA);

            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kiem tra 

            string select1 = "Select MaKhoa from tblLOP where MaKhoa='" + txtKhoa.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            if (reader1.Read())
            {
                {
                    MessageBox.Show("Bạn phải xóa Mã Khoa "+ txtKhoa.Text +"từ bảng Lớp","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                reader1.Dispose();
                cmd1.Dispose();
                SqlCommand cmd = new SqlCommand("delete from tblKHOA where MaKhoa='" + txtKhoa.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                //Load lai du lieu
                FillDataGridView_Khoa();
            }
            reader1.Dispose();
            cmd1.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            string update = "Update tblKHOA Set TenKhoa=N'" + txtTenKhoa.Text + "' where MaKhoa='" + txtKhoa.Text + "' ";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Load lai du lieu
            FillDataGridView_Khoa();
            // Trả tài nguyên
            cmd.Dispose();
        }

        private void dgrKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKhoa.Text = dgrKhoa.CurrentRow.Cells[0].Value.ToString();
            txtTenKhoa.Text = dgrKhoa.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
