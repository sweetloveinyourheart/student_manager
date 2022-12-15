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
    public class KhoaBUS
    {
        private static KhoaBUS instance;
        public static KhoaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoaBUS();
                return instance;
            }
        }

        private KhoaBUS() { }

        public void FillKhoaList(ComboBox cboKhoa)
        {
            List<Khoa> khoas = KhoaDAO.Instance.FormLoad();
            foreach (Khoa khoa in khoas)
            {
                cboKhoa.Items.Add(khoa.MaKhoa);
            }
        }

        public void FillKhoaDGR(DataGridView dgrKhoa)
        {
            List<Khoa> khoas = KhoaDAO.Instance.FormLoad();
            dgrKhoa.DataSource = khoas;
        }

        public void ThemKhoa(
            ErrorProvider errorProvider1,
            TextBox txtKhoa,
            TextBox txtTenKhoa
            )
        {
            errorProvider1.Clear();
            if (txtKhoa.Text == "")
            {
                errorProvider1.SetError(txtKhoa, "Khóa học không để trống!");
                txtTenKhoa.Focus();
            }
            else if (!KhoaDAO.Instance.ThemKhoa(txtKhoa.Text, txtTenKhoa.Text))
            {
                MessageBox.Show("Thông tin đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhoa.Focus();
            }
            else
            {
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
        }

        public void SuaKhoa(
            TextBox txtMaKhoa,
            TextBox txtTenKhoa
            )
        {
            KhoaDAO.Instance.SuaKhoa(
                txtMaKhoa.Text,
                txtTenKhoa.Text
                );
            MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void XoaKhoa(
            TextBox txtMaKhoa
            )
        {
            if (!KhoaDAO.Instance.XoaKhoa(txtMaKhoa.Text))
            {
                MessageBox.Show("Bạn phải xóa Mã Khoa " + txtMaKhoa.Text + "từ bảng Lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
            }
        }
    }
}
