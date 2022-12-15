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

        public bool ThemKhoa(
            string maKhoa,
            string tenKhoa
            )
        {
            Khoa khoa = db.tblKHOAs.Where(eq => eq.MaKhoa == maKhoa).Select(s => new Khoa()).FirstOrDefault();
            if (khoa != null)
            {
                return false;
            }

            tblKHOA newKhoa = new tblKHOA();

            newKhoa.MaKhoa = maKhoa;
            newKhoa.TenKhoa = tenKhoa;

            db.tblKHOAs.InsertOnSubmit(newKhoa);

            db.SubmitChanges();

            return true;
        }

        public bool SuaKhoa(
            string maKhoa,
            string tenKhoa
            )
        {
            tblKHOA Khoa = db.tblKHOAs.Where(eq => eq.MaKhoa == maKhoa).Select(s => s).FirstOrDefault();
            if (Khoa == null)
            {
                return false;
            }

            Khoa.MaKhoa = maKhoa;
            Khoa.TenKhoa = tenKhoa;

            db.SubmitChanges();

            return true;
        }

        public bool XoaKhoa(
            string maKhoa
            )
        {
            tblLOP sv = db.tblLOPs.Where(eq => eq.MaKhoa == maKhoa).Select(s => s).FirstOrDefault();
            if (sv != null)
            {
                return false;
            }

            tblKHOA Khoa = db.tblKHOAs.Where(eq => eq.MaKhoa == maKhoa).Select(s => s).FirstOrDefault();
            if (Khoa == null)
            {
                return false;
            }

            db.tblKHOAs.DeleteOnSubmit(Khoa);

            db.SubmitChanges();

            return true;
        }

    }
}
