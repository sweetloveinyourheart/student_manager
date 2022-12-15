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

        public bool ThemLop(
            string malop,
            string tenlop,
            string makhoa
            )
        {
            Khoa sv = db.tblKHOAs.Where(eq => eq.MaKhoa == makhoa).Select(s => new Khoa()).FirstOrDefault();
            if (sv == null)
            {
                return false;
            }

            tblLOP newLop = new tblLOP();

            newLop.MaLop = malop;
            newLop.TenLop = tenlop;
            newLop.MaKhoa = makhoa;

            db.tblLOPs.InsertOnSubmit(newLop);

            db.SubmitChanges();

            return true;
        }

        public bool SuaLop(
            string malop,
            string tenlop,
            string makhoa
            )
        {
            tblLOP lop = db.tblLOPs.Where(eq => eq.MaLop == malop).Select(s => s).FirstOrDefault();
            if (lop == null)
            {
                return false;
            }

            lop.MaLop = malop;
            lop.TenLop = tenlop;
            lop.MaKhoa = makhoa;

            db.SubmitChanges();

            return true;
        }

        public bool XoaLop(
            string malop
            )
        {
            tblSINH_VIEN sv = db.tblSINH_VIENs.Where(eq => eq.MaLop == malop).Select(s => s).FirstOrDefault();
            if (sv != null)
            {
                return false;
            }

            tblLOP lop = db.tblLOPs.Where(eq => eq.MaLop == malop).Select(s => s).FirstOrDefault();
            if (lop == null)
            {
                return false;
            }

            db.tblLOPs.DeleteOnSubmit(lop);

            db.SubmitChanges();

            return true;
        }
    }
}
