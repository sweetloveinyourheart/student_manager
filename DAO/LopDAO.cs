using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class LopDAO
    {
        private static LopDAO instance;

        public static LopDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopDAO();
                return instance;
            }
        }

        private LopDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<Lop> FormLoad()
        {
            List<Lop> list = new List<Lop>();

            list = db.tblLOPs.Select(s => new Lop(
                s.MaKhoa,
                s.MaLop,
                s.TenLop
                )
            ).ToList();

            return list;
        }

        public List<Lop> CBLoadByMaKhoa(string makhoa)
        {
            List<Lop> list = new List<Lop>();

            list = db.tblLOPs
                .Where(eq => eq.MaKhoa == makhoa)
                .Select(s => new Lop(
                    s.MaKhoa,
                    s.MaLop,
                    s.TenLop
                ))
                .ToList();

            return list;
        }
    }
}
