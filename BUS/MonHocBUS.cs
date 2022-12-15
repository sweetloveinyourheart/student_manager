using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class MonHocBUS
    {
        private static MonHocBUS instance;
        public static MonHocBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonHocBUS();
                return instance;
            }
        }

        private MonHocBUS() { }

        public void FillMonDGR(DataGridView dgrMon)
        {
            List<MonHoc> monhocs = MonHocDAO.Instance.FormLoad();
            dgrMon.DataSource = monhocs;
        }

        public void FillMonList(ComboBox cboKhoa)
        {
            List<MonHoc> monhocs = MonHocDAO.Instance.FormLoad();
            cboKhoa.Items.Clear();
            foreach (MonHoc mon in monhocs)
            {
                cboKhoa.Items.Add(mon.TenMon);
            }
        }

        public void FillCBByMaKhoa(ComboBox cboKhoa, ComboBox cboMonHoc)
        {
            List<tblMON> monhocs = MonHocDAO.Instance.CBLoadByName(cboKhoa.Text);
            cboMonHoc.Items.Clear();
            foreach (tblMON mon in monhocs)
            {
                cboMonHoc.Items.Add(mon.MaMon);
            }
        }

        public void FillCBByHocKy(ComboBox cboHocKy, ComboBox cboMonHoc)
        {
            List<tblMON> monhocs = MonHocDAO.Instance.CBLoadByHocKy(cboHocKy.Text);
            cboMonHoc.Items.Clear();
            foreach (tblMON mon in monhocs)
            {
                cboMonHoc.Items.Add(mon.MaMon);
            }
        }

        public void ThemMonHoc(
            ErrorProvider errorProvider1,
            TextBox txtMaMon,
            TextBox txtTenMon,
            TextBox txtSDVHT,
            TextBox txtMaGV,
            TextBox txtHocKy,
            ComboBox cboKhoa
            )
        {
            errorProvider1.Clear();
            if (txtMaMon.Text == "")
            {
                errorProvider1.SetError(txtMaMon, "Mã môn không để trống!");
            }
            else if (!MonHocDAO.Instance.ThemMonHoc(
                txtMaMon.Text, 
                txtTenMon.Text,
                int.Parse(txtSDVHT.Text),
                txtMaGV.Text,
                txtHocKy.Text,
                cboKhoa.Text
                ))
            {
                MessageBox.Show("Bạn đã nhập thông tin cho môn: " + txtTenMon.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMon.Focus();
            }
            else
            {
                // Thực hiện truy vấn
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
        }

        public void SuaMonHoc(
            TextBox txtMaMon,
            TextBox txtTenMon,
            TextBox txtSDVHT,
            TextBox txtMaGV,
            TextBox txtHocKy,
            ComboBox cboKhoa
            )
        {
            MonHocDAO.Instance.SuaMonHoc(
                txtMaMon.Text,
                txtTenMon.Text,
                int.Parse(txtSDVHT.Text),
                txtMaGV.Text,
                txtHocKy.Text,
                cboKhoa.Text
                );
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void XoaMonHoc(
            TextBox txtMaMon
            )
        {
            // Thuc hien xoa du lieu
            MonHocDAO.Instance.XoaMonHoc(txtMaMon.Text);
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
        }
    }
}
