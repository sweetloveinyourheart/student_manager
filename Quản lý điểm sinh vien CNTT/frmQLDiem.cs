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
            cboLop.Items.Clear();
            cboLop.Text = "";
            string select = "Select MaLop from tblLOP where  MaKhoa='" + cboKhoaHoc.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //Add vao cboLop
            while (reader.Read())
            {

                cboLop.Items.Add(reader.GetString(0));
            }
            //Tra tai nguyen 
            reader.Dispose();
            cmd.Dispose();
        }

        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet47.tblKET_QUA' table. You can move, or remove it, as needed.
            //this.tblKET_QUATableAdapter.Fill(this.quanlydiemDataSet47.tblKET_QUA); 
  
          
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open) ;

            //Add du lieu vao cboKhoaHoc
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                cboKhoaHoc.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();


            //Load lai du lieu
            FillDataGridView_Diem();

        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMonHoc.Items.Clear();
            string select = "Select MaMon from tblMON where HocKi='" + cboHocKi.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //Add vao cboLop
            while (reader.Read())
            {

                cboMonHoc.Items.Add(reader.GetString(0));
            }
            //Tra tai nguyen 
            reader.Dispose();
            cmd.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kiem tra trung ten MonHoc va MASV

            string select1 = "Select MaSV from tblSINH_VIEN where MaSV=N'" + txtMaSV.Text + "' and Hoten=N'"+ txtHoTen.Text +"' ";
            SqlCommand cmd1 = new SqlCommand(select1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV,"Mã sinh viên không để trống!");
                txtMaSV.Focus();
            }
            else if (txtMaSV.Text == dgrDiem.CurrentRow.Cells[0].Value.ToString() && cboMonHoc.Text == dgrDiem.CurrentRow.Cells[3].Value.ToString())
            {
                {
                    MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text,"Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtMaSV.Focus();

                }
            }
            else if (cboLop.Text == "")
            {
                errorProvider1.SetError(cboLop, "Mã lớp không để trống!");
                cboLop.Focus();
            }
            else if (cboHocKi.Text == "")
            {
                errorProvider1.SetError(cboHocKi, "Học kỳ không để trống!");
                cboHocKi.Focus();
            }
            else if (cboMonHoc.Text == "")
            {
                errorProvider1.SetError(cboMonHoc, "Mã môn không để trống!");
                cboMonHoc.Focus();
            }
            else if (reader1.Read())
            {

                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
                // Thực hiện truy vấn
                string insert = "Insert Into tblKET_QUA(MaSV,HoTen,MaLop,MaMon,DiemThiLan1,DiemTB,DiemTongket,HanhKiem,HocKi,GhiChu)" +
                "Values('" + txtMaSV.Text + "',N'" + txtHoTen.Text + "','" + cboLop.Text + "',N'" + cboMonHoc.Text + "','" + txtDiemThi1.Text + "','" +
                 txtDiemTB.Text + "','" + txtDiemTK.Text + "',N'" + cboHanhKiem.Text + "',N'" +
                cboHocKi.Text + "',N'" + txtGhiChu.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
            }
            else
            {
                {
                    MessageBox.Show("Nhập mã sinh viên không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();

                }
                //Tra tai nguyen 
                reader1.Dispose();
                cmd1.Dispose();
            }
            //Tra tai nguyen 
            reader1.Dispose();
            cmd1.Dispose();
            //Load lai du lieu
            FillDataGridView_Diem();
        }

        public void FillDataGridView_Diem()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblKET_QUA  ";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrDiem.DataSource = ds;
            dgrDiem.DataMember = "SINHVIEN";
            cmd.Dispose();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

            //// Thực hiện truy vấn
            //string select = "Select * From tblKET_QUA Where MaLop='"+cboLop .Text +"'";
            //SqlCommand cmd = new SqlCommand(select, conn);

            //// Tạo đối tượng DataSet
            //DataSet ds = new DataSet();

            //// Tạo đối tượng điều hợp
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = cmd;

            //// Fill dữ liệu từ adapter vào DataSet
            //adapter.Fill(ds, "SINHVIEN");

            //// Đưa ra DataGridView
            //dgrDiem.DataSource = ds;
            //dgrDiem.DataMember = "SINHVIEN";
            //cmd.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                string delete = "delete from tblKET_QUA where MaSV='" + txtMaSV.Text + "' and MaMon='" + cboMonHoc.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
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
            txtDiemTK.Text = dgrDiem.CurrentRow.Cells[6].Value.ToString();
            cboHanhKiem.Text = dgrDiem.CurrentRow.Cells[7].Value.ToString();
            cboHocKi.Text = dgrDiem.CurrentRow.Cells[8].Value.ToString();
            txtGhiChu.Text = dgrDiem.CurrentRow.Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kiem tra trung ten MonHoc va MASV

            //string select1 = "Select MaSV,TenMon from tblKET_QUA where TenMon=N'" + cboMonHoc.Text + "' ";
            //SqlCommand cmd1 = new SqlCommand(select1, conn);
            //SqlDataReader reader1 = cmd1.ExecuteReader();
            //errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            }
            //else if (reader1.Read())
            //{
            //    {
            //        MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtMaSV.Focus();

            //    }


                ////Tra tai nguyen 
                //reader1.Dispose();
                //cmd1.Dispose();
            //}
            else
            {

                ////Tra tai nguyen 
                //reader1.Dispose();
                //cmd1.Dispose();

                // Thực hiện truy vấn
                string update = "Update tblKET_QUA Set HoTen=N'" + txtHoTen.Text + "',MaMon=N'" +cboMonHoc.Text + "',MaLop='" + 
                                cboLop.Text + "',DiemThiLan1='" + txtDiemThi1.Text + "',DiemTB='" +txtDiemTB.Text + "' ,DiemTongket='" + 
                                txtDiemTK.Text + "',HanhKiem=N'" + cboHanhKiem.Text + "',HocKi=N'" + cboHocKi.Text + "',GhiChu=N'" +
                                txtGhiChu.Text + "' where MaSV='" + txtMaSV.Text + "' and MaMon=N'" + cboMonHoc.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Load lai du lieu
                FillDataGridView_Diem();
                // Trả tài nguyên
                cmd.Dispose();
            }
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
