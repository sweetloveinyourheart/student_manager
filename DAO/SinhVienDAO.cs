using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
     public class SinhVienDAO
     {
        private static SinhVienDAO instance;

        public static SinhVienDAO Instance { 
            get { 
                if (instance == null) 
                    instance = new SinhVienDAO();
                return instance; 
            } 
        }

        private SinhVienDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<SinhVien> FormLoad()
        {
            List<SinhVien> list = new List<SinhVien>();
      
            list = db.tblSINH_VIENs.Select(s => new SinhVien(
                s.MaSv, 
                s.HoTen, 
                s.NgaySinh,
                s.GioiTinh,
                s.DiaChi,
                s.MaLop
                )
            ).ToList();

            return list;
        }

        public List<SinhVien> FindSvByMaLop(string malop)
        {
            List<SinhVien> list = new List<SinhVien>();

            list = db.tblSINH_VIENs
                .Where(eq => eq.MaLop == malop)
                .Select(s => new SinhVien(
                    s.MaSv,
                    s.HoTen,
                    s.NgaySinh,
                    s.GioiTinh,
                    s.DiaChi,
                    s.MaLop
                )
            ).ToList();

            return list;
        }

        public bool ThemSV(
            string masv,
            string hoten,
            string ngaysinh,
            string gioitinh,
            string diachi,
            string malop
            )
        {
            SinhVien sv = db.tblSINH_VIENs.Where(eq => eq.MaSv == masv).Select(s => new SinhVien()).FirstOrDefault();
            if(sv != null)
            {
                return false;
            }

            tblSINH_VIEN newSv = new tblSINH_VIEN();

            newSv.MaSv = masv;
            newSv.HoTen = hoten;
            newSv.NgaySinh = ngaysinh;
            newSv.GioiTinh = gioitinh;
            newSv.DiaChi = diachi;
            newSv.MaLop = malop;

            db.tblSINH_VIENs.InsertOnSubmit(newSv);

            db.SubmitChanges();

            return true;
        }

        public bool SuaSV(
            string masv,
            string hoten,
            string ngaysinh,
            string gioitinh,
            string diachi,
            string malop
            )
        {
            tblSINH_VIEN sv = db.tblSINH_VIENs.Where(eq => eq.MaSv == masv).Select(s => s).FirstOrDefault();
            if (sv == null)
            {
                return false;
            }

            sv.MaSv = masv;
            sv.HoTen = hoten;
            sv.NgaySinh = ngaysinh;
            sv.GioiTinh = gioitinh;
            sv.DiaChi = diachi;
            sv.MaLop = malop;

            db.SubmitChanges();

            return true;
        }

        public bool XoaSV(string masv)
        {
            tblKET_QUA isExist = db.tblKET_QUAs.Select(s => s).FirstOrDefault(s => s.MaSV.Equals(masv));
            if (isExist != null)
            {
                return false;
            }

            tblSINH_VIEN deleted = db.tblSINH_VIENs.Select(s => s).FirstOrDefault(s => s.MaSv.Equals(masv));

            db.tblSINH_VIENs.DeleteOnSubmit(deleted);

            db.SubmitChanges();

            return true;
        }
    }
}
