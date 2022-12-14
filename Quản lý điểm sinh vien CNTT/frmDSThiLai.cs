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

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmDSThiLai : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmDSThiLai()
        {
            InitializeComponent();
        }

        private void frmDSThiLai_Load(object sender, EventArgs e)
        {
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
            


        }

        //private void cboHocKi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cboMaMon .Items.Clear();
        //    string select = "Select TenMon from tblMON where HocKi='" + cboHocKi.Text + "'";
        //    SqlCommand cmd = new SqlCommand(select, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    //Add vao cboLop
        //    while (reader.Read())
        //    {

        //        cboMaMon .Items.Add(reader.GetString(0));
        //    }
        //    //Tra tai nguyen 
        //    reader.Dispose();
        //    cmd.Dispose();

        //}
        public void FillDataGridView_DSSV()
        {
            // Thực hiện truy vấn
            string select = "Select * From tblSINH_VIEN ";
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
            cboMonHoc.Items.Clear();
            string select = "Select TenMon from tblMON where HocKi='" + cboHocKi.Text + "'";
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

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            string select = "Select tblSINH_VIEN.MaSV,tblSINH_VIEN.HoTen,tblSINH_VIEN.Ngaysinh,tblSINH_VIEN.Gioitinh From tblSINH_VIEN INNER JOIN tblKET_QUA ON tblSINH_VIEN.MaSv = tblKET_QUA.MaSv " +
                            "where tblKET_QUA.GhiChu=N'" + cboLoai.Text + "' ";
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

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgrDSSV);
        }

    }
}
