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
    public partial class frmKhoa : Form
    {

        public frmKhoa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KhoaBUS.Instance.ThemKhoa(errorProvider1, txtKhoa, txtTenKhoa);
            //Fill du lieu vao Database
            FillDataGridView_Khoa();
            
        }

        public void FillDataGridView_Khoa()
        {
            KhoaBUS.Instance.FillKhoaDGR(dgrKhoa);
        }

        private void frmLop_Khoa_Load(object sender, EventArgs e)
        {
            FillDataGridView_Khoa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kiem tra 

            KhoaBUS.Instance.XoaKhoa(txtKhoa);
            FillDataGridView_Khoa();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Thực hiện truy vấn
            KhoaBUS.Instance.SuaKhoa(txtKhoa, txtTenKhoa);
            //Load lai du lieu
            FillDataGridView_Khoa();
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
