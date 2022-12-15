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

    }
}
