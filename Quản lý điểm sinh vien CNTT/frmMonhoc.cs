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
    public partial class frmMonHoc : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet52.tblMON' table. You can move, or remove it, as needed.
            this.tblMONTableAdapter.Fill(this.quanlydiemDataSet52.tblMON);
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;

            
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                cboKhoa.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select1 = "Select MaMon from tblMON where MaMon='" + txtMaMon.Text + "' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            errorProvider1.Clear();
            if (txtMaMon.Text == "")
            {
                errorProvider1.SetError(txtMaMon, "Mã môn không để trống!");
            }
            else if (reader1.Read())
            {
                {
                    MessageBox.Show("Bạn đã nhập thông tin cho môn: " + txtTenMon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMon.Focus();

                }

                //Download source code tại Sharecode.vn
                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
            }
            else
            {
                reader1.Dispose();
                cmd1.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblMON(MaMon,TenMon,SoDVHT,MaGV,HocKi,MaKhoa)" +
                "Values('" + txtMaMon.Text + "',N'" + txtTenMon.Text + "','" + txtSDVHT.Text + "','" +
                txtMaGV.Text + "','" + txtHocKy.Text + "','" + cboKhoa.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");

                // Trả tài nguyên


                cmd.Dispose();
                //Fill du lieu vao Database
                FillDataGridView_MON();
            }
            reader1.Dispose();
            cmd1.Dispose();
        }
        public void FillDataGridView_MON()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblMON  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrMON.DataSource = ds;
            dgrMON.DataMember = "SINHVIEN";
            cmd.Dispose();
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
            // Thuc hien xoa du lieu
            string delete = "delete from tblMON where MaMon='" + txtMaMon.Text + "' ";
            SqlCommand cmd = new SqlCommand(delete, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

            // Trả tài nguyên
            cmd.Dispose();
            //Load lai du lieu
            FillDataGridView_MON();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            string update = "Update tblMON Set TenMon=N'" + txtTenMon.Text + "',SoDVHT='" + 
                            txtSDVHT.Text + "',MaGV='" + txtMaGV.Text + "',HocKi='" +
                            txtHocKy.Text + "',MaKhoa='" + cboKhoa.Text + "' where MaMon='" + txtMaMon.Text + "' ";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Load lai du lieu
            FillDataGridView_MON();
            // Trả tài nguyên
            cmd.Dispose();
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
