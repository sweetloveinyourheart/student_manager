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
using BUS;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmQLSV : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmQLSV()
        {
            InitializeComponent();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            conn=cc.Connected();
            if (conn.State == ConnectionState.Open) ;
            //Add du lieu vao cboKhoa
            string select = "Select MaKhoa from tblKHOA ";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                cboKhoahoc.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();


            //Add du lieu vao MaLop
            string selects = "Select MaLop from tblLOP";
            SqlCommand cmd1 = new SqlCommand(selects, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {

                cboMalop.Items.Add(reader1.GetString(0));
            }
            reader1.Dispose();
            cmd1.Dispose();
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
            cboLop.Items.Clear();
            string select = "Select MaLop from tblLOP where MaKhoa='" + cboKhoahoc.Text + "'";
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

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            string select = "Select * From tblSINH_VIEN  where MaLop='"+ cboLop.Text +"'";
            SqlCommand cmd = new SqlCommand(select, conn);

            // Tạo đối tượng DataSet
            DataSet ds = new DataSet();

            // Tạo đối tượng điều hợp
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            // Fill dữ liệu từ adapter vào DataSet
            adapter.Fill(ds, "SINHVIEN");

            // Đưa ra DataGridView
            dgrDSSV.DataSource = ds;
            dgrDSSV.DataMember = "SINHVIEN";

            cmd.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
