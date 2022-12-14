using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace BUS
{
    public class KetQua2BUS
    {
        private static KetQua2BUS instance;
        public static KetQua2BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQua2BUS();
                return instance;
            }
        }

        private KetQua2BUS() { }

        public void FillKetQua2List(DataGridView dgrDiem)
        {
            // Đưa ra DataGridView
            dgrDiem.DataSource = KetQua2DAO.Instance.FormLoad();
        }

        public void ThemKetQua2(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            ComboBox cboMalop,
            ComboBox cboMonHoc,
            TextBox txtDiemThi2,
            ComboBox cboHocKi
            )
        {
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
                txtMaSV.Focus();
            }

            else if (KetQua2DAO.Instance.ThemKetQua2(
                txtMaSV.Text,
                cboMalop.Text,
                cboMonHoc.Text,
                txtDiemThi2.Text,
                cboHocKi.Text
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

        public void SuaKetQua2(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            ComboBox cboMalop,
            ComboBox cboMonHoc,
            TextBox txtDiemThi2,
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
                KetQua2DAO.Instance.SuaKetQua2(
                txtMaSV.Text,
                cboMalop.Text,
                cboMonHoc.Text,
                txtDiemThi2.Text,
                cboHocKi.Text
                );

                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            };
        }

        public void XoaKetQua2(TextBox txtMaSV)
        {
            if (KetQua2DAO.Instance.XoaKetQua2(txtMaSV.Text))
            {
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
            }

        }
    }
}
