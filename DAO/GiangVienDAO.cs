using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;

        public static GiangVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiangVienDAO();
                return instance;
            }
        }

        private GiangVienDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<GiangVien> FormLoad()
        {
            List<GiangVien> list = new List<GiangVien>();

            list = db.tblGIANG_VIENs.Select(s => new GiangVien(
                s.MaGV,
                s.TenGV,
                s.GioiTinh,
                s.Phone,
                s.Email,
                s.PhanLoaiGV,
                s.Anh
                )
            ).ToList();

            return list;
        }

        public bool ThemGiangVien(
            string maGV, 
            string tenGV, 
            string gioitinh, 
            string phone,
            string email, 
            string phanloaiGV
            )
        {
            GiangVien gv = db.tblGIANG_VIENs.Where(eq => eq.MaGV == maGV).Select(s => new GiangVien()).FirstOrDefault();
            if (gv != null)
            {
                return false;
            }

            tblGIANG_VIEN newGv = new tblGIANG_VIEN();

            newGv.MaGV = maGV;
            newGv.TenGV = tenGV;
            newGv.GioiTinh = gioitinh;
            newGv.Phone = phone;
            newGv.Email = email;
            newGv.PhanLoaiGV = phanloaiGV;

            db.tblGIANG_VIENs.InsertOnSubmit(newGv);

            db.SubmitChanges();

            return true;
        }

        public bool SuaGiangVien(
            string maGV,
            string tenGV,
            string gioitinh,
            string phone,
            string email,
            string phanloaiGV
            )
        {
            tblGIANG_VIEN gv = db.tblGIANG_VIENs.Where(eq => eq.MaGV == maGV).Select(s => s).FirstOrDefault();
            if (gv == null)
            {
                return false;
            }

            gv.MaGV = maGV;
            gv.TenGV = tenGV;
            gv.GioiTinh = gioitinh;
            gv.Phone = phone;
            gv.Email = email;
            gv.PhanLoaiGV = phanloaiGV;

            db.SubmitChanges();

            return true;
        }

        public bool XoaGiangVien(
            string maGV
            )
        {
            tblGIANG_VIEN gv = db.tblGIANG_VIENs.Where(eq => eq.MaGV == maGV).Select(s => s).FirstOrDefault();
            
            if (gv == null)
            {
                return false;
            }

            db.tblGIANG_VIENs.DeleteOnSubmit(gv);

            db.SubmitChanges();

            return true;
        }
    }
}
