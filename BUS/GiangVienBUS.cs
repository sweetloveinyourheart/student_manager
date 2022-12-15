using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;

namespace BUS
{
    public class GiangVienBUS
    {
        private static GiangVienBUS instance;
        public static GiangVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiangVienBUS();
                return instance;
            }
        }

        private GiangVienBUS() { }

        public void FillGiangVienDGR(DataGridView dgrGiangVien)
        {
            List<GiangVien> GiangViens = GiangVienDAO.Instance.FormLoad();
            dgrGiangVien.DataSource = GiangViens;
        }
    }
}
