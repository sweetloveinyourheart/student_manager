using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quản_lý_điểm_sinh_vien_CNTT
{
    public partial class frmTimDiemSV : Form
    {
        private CommonConnect cc = new CommonConnect();
        SqlConnection conn = null;
        public frmTimDiemSV()
        {
            InitializeComponent();
        }

        private void frmTimDiemSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanlydiemDataSet49.tblKET_QUA' table. You can move, or remove it, as needed.
            this.tblKET_QUATableAdapter.Fill(this.quanlydiemDataSet49.tblKET_QUA);

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


            

        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Download source code tại Sharecode.vn
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string select = "Select * From tblKET_QUA  where MaSV='" + txtMaSV.Text + "' and MaMon=N'" + cboMonHoc.Text + "'";
                SqlCommand cmd = new SqlCommand(select, conn);

                // Tạo đối tượng DataSet
                DataSet ds = new DataSet();

                // Tạo đối tượng điều hợp
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                // Fill dữ liệu từ adapter vào DataSet
                adapter.Fill(ds, "SINHVIEN");

                // Đưa ra DataGridView
                dgrDIEMSV.DataSource = ds;
                dgrDIEMSV.DataMember = "SINHVIEN";

                cmd.Dispose();
         
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Thaotac.Export2Excel(dgrDIEMSV);
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "Select MaMon from tblMON where MaKhoa='"+ cboKhoa.Text +"'";
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
    }
}
