using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class KetQua3BUS
    {
        private static KetQua3BUS instance;
        public static KetQua3BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQua3BUS();
                return instance;
            }
        }

        private KetQua3BUS() { }

        public void FillKetQua3List(DataGridView dgrDiem)
        {
            // Đưa ra DataGridView
            dgrDiem.DataSource = KetQua3DAO.Instance.FormLoad();
        }

        public void ThemKetQua3(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            ComboBox cboMalop,
            ComboBox cboMonHoc,
            TextBox txtDiemThi3,
            ComboBox cboHocKi
            )
        {
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
                txtMaSV.Focus();
            }

            else if (KetQua3DAO.Instance.ThemKetQua3(
                txtMaSV.Text,
                cboMalop.Text,
                cboMonHoc.Text,
                Double.Parse(txtDiemThi3.Text),
                int.Parse(cboHocKi.Text)
            ))
            {
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập mã sinh viên không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
            }
        }

        public void SuaKetQua3(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            ComboBox cboMalop,
            ComboBox cboMonHoc,
            TextBox txtDiemThi3,
            ComboBox cboHocKi
            )
        {
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            }
            else
            {
                KetQua3DAO.Instance.SuaKetQua3(
                txtMaSV.Text,
                cboMalop.Text,
                cboMonHoc.Text,
                Double.Parse(txtDiemThi3.Text),
                int.Parse(cboHocKi.Text)
                );

                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            };
        }

        public void XoaKetQua3(TextBox txtMaSV)
        {
            if (KetQua3DAO.Instance.XoaKetQua3(txtMaSV.Text))
            {
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
            }

        }
    }
}
