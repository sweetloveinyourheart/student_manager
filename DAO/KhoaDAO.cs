using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KhoaDAO
    {
        private static KhoaDAO instance;

        public static KhoaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoaDAO();
                return instance;
            }
        }

        private KhoaDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();
        public List<Khoa> FormLoad()
        {
            List<Khoa> list = new List<Khoa>();

            list = db.tblKHOAs.Select(s => new Khoa(
                s.MaKhoa,
                s.TenKhoa
                )
            ).ToList();

            return list;
        }

    }
}
