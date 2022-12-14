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
    public partial class frmDangNhap : Form
    {
        //Khai báo đối tượng Commonconnect
        private CommonConnect cc = new CommonConnect();
        //Khai báo đối tượng SqlConnection
        private SqlConnection  conn = null;
        //public static bool kt1, kt2;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (LoginBUS.Instance.KiemTraAdmin(txtTenDN, txtMatKhau))
            {
                MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");
                frmMain frm = new frmMain();
                frm.Show();
                frm.mnuDN.Enabled = false;
                this.Hide();
            }

            else
            {
                if (LoginBUS.Instance.KiemTraMember(txtTenDN, txtMatKhau))
                {
                    MessageBox.Show("Đăng nhập vào hệ thống !", "Thông báo !");

                    frmMain frm = new frmMain();
                    frm.Show();
                    frm.mnuDN.Enabled = false;
                    frm.MnuItemDanhMuc.Enabled = false;
                    frm.mnuItemQuanli.Enabled = false;
                    this.Hide();

                    frm.mnuQuanlinguoidung.Enabled = false;

                    frm.menuBarToolStripMenuItem.Enabled = false;
                    frm.menuBarToolStripMenuItem.Checked = true;
                    frm.pictureBox3.Hide();
                    frm.pictureBox2.Hide();
                    frm.btl1.Hide();
                    frm.btl2.Hide();
                    frm.btl3.Hide();
                    frm.btl4.Hide();
                    frm.btl5.Hide();
                    frm.btl6.Hide();
                    //frm.menuBarToolStripMenuItem.Checked = true;
                    //frm.pictureBox3.Show();
                    //frm.pictureBox2.Show();
                    //frm.btl1.Show();
                    //frm.btl2.Show();
                    //frm.btl3.Show();
                    //frm.btl4.Show();
                    //frm.btl5.Show();
                    //frm.btl6.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
 
                }

            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Mở kết nối
            conn = cc.Connected();
            if (conn.State == ConnectionState.Open)
            cboName.Items.Add(SystemInformation.UserDomainName.ToString() + "\\SQLServer");
            cboName.Text = cboName.Items[0].ToString();
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
