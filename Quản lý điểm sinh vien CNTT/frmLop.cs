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
    public partial class frmLop : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
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
            this.tblLOPTableAdapter.Fill(this.quanlydiemDataSet37.tblLOP);
         
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;
            //Add du lieu vao cboKhoaHoc
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

               cboKhoa.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();


            //Load lai du lieu
            FillDataGridView_Lop();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {

            string select1 = "Select MaKhoa from tblKHOA where MaKhoa='" + cboKhoa.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            errorProvider1.Clear();
            if (txtMaLop.Text == "")
            {
                errorProvider1.SetError(txtMaLop, "!");
                txtMaLop.Focus();
            }
            else if (txtMaLop.Text == dgrLop.CurrentRow.Cells[1].Value.ToString())
            {
                errorProvider1.SetError(txtMaLop, "!");
                MessageBox.Show("Mã lớp đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtMaLop.Focus();
            }
            else if (reader1.Read())
            {

                reader1.Dispose();
                cmd1.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblLOP(MaLop,TenLop,Makhoa)" +
                "Values('" + txtMaLop.Text + "',N'" + txtTenlop.Text + "','" + cboKhoa.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");

                // Trả tài nguyên


                cmd.Dispose();
                //Fill du lieu vao Database
                FillDataGridView_Lop();

            }
            else
            {
                    MessageBox.Show("Nhập mã khoa không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboKhoa.Focus();
                    reader1.Dispose();
                    cmd1.Dispose();
            }
            reader1.Dispose();
            cmd1.Dispose();
        }
        public void FillDataGridView_Lop()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblLop  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrLop.DataSource = ds;
            dgrLop.DataMember = "SINHVIEN";
            cmd.Dispose();
        }

        private void dgrLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cboKhoa.Text = dgrLop.CurrentRow.Cells[0].Value.ToString();
            txtMaLop.Text = dgrLop.CurrentRow.Cells[1].Value.ToString();
            txtTenlop.Text = dgrLop.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kiem tra 

            string select1 = "Select MaLop from tblSINH_VIEN where MaLop='" + txtMaLop.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            if (reader1.Read())
            {
                {
                    MessageBox.Show("Bạn phải xóa Mã Lớp "+ txtMaLop.Text+"từ bảng Sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }

            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                cmd1.Dispose();
                reader1.Dispose();
                SqlCommand cmd = new SqlCommand("delete from tblLOP where MaLop='" + txtMaLop.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                //Load lai du lieu
                FillDataGridView_Lop();
            }
            cmd1.Dispose();
            reader1.Dispose();
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
            string update = "Update tblLOP Set MaKhoa='" + cboKhoa.Text + "',MaLop='" + txtMaLop.Text + "',TenLop='" +
                            txtTenlop.Text + "' where MaLop='" + txtMaLop.Text + "' ";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Load lai du lieu
            FillDataGridView_Lop();
            // Trả tài nguyên
            cmd.Dispose();
        }


    }
}
