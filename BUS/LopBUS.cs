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
    public class LopBUS
    {
        private static LopBUS instance;
        public static LopBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopBUS();
                return instance;
            }
        }

        private LopBUS() { }

        public void FillLopDGR(DataGridView dgrLop)
        {
            List<Lop> lops = LopDAO.Instance.FormLoad();
            dgrLop.DataSource = lops;
        }

        public void FillLopList(ComboBox cboLop)
        {
            List<Lop> lops = LopDAO.Instance.FormLoad();
            foreach (Lop lop in lops)
            {
                cboLop.Items.Add(lop.MaLop);
            }
        }

        public void FillLopListMaKhoa(ComboBox cboKhoa, ComboBox cboLop)
        {
            List<Lop> lops = LopDAO.Instance.CBLoadByMaKhoa(cboKhoa.Text);
            cboLop.Items.Clear();
            foreach (Lop lop in lops)
            {
                cboLop.Items.Add(lop.MaLop);
            }
        }

        public void ThemLop(
            ErrorProvider errorProvider1,
            TextBox txtMaLop,
            TextBox txtTenLop,
            ComboBox cboKhoa
            )
        {
            errorProvider1.Clear();
            if (txtMaLop.Text == "")
            {
                errorProvider1.SetError(txtMaLop, "Mã lớp không để trống!");
            }
            else if (!LopDAO.Instance.ThemLop(
                txtMaLop.Text,
                txtTenLop.Text,
                cboKhoa.Text
                ))
            {
                MessageBox.Show("Bạn đã nhập thông tin cho lớp: " + txtTenLop.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
            }
            else
            {
                // Thực hiện truy vấn
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
        }

        public void SuaLop(
            TextBox txtMaLop,
            TextBox txtTenLop,
            ComboBox cboKhoa
            )
        {
            LopDAO.Instance.SuaLop(
                txtMaLop.Text,
                txtTenLop.Text,
                cboKhoa.Text
                );
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void XoaLop(
            TextBox txtMaLop
            )
        {
            // Thuc hien xoa du lieu
            if (!LopDAO.Instance.XoaLop(txtMaLop.Text))
            {
                MessageBox.Show("Bạn phải xóa Mã Lớp " + txtMaLop.Text + "từ bảng Sinh Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

            }
        }

    }
}
