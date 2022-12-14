using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LoginDAO
    {
        private static LoginDAO instance;
        public static LoginDAO Instance
        {
            get { 
                if(instance == null)
                instance = new LoginDAO();
                return instance;
            }
        }

        private LoginDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<Login> FormLoad()
        {
            List<Login> list = new List<Login>();

            list = db.tblLOGINs.Select(s => new Login(
                s.TenDN,
                s.MatKhau,
                s.HoTen,
                s.GioiTinh,
                s.Phone,
                s.Email,
                s.Quyen
                )
            ).ToList();

            return list;
        }

        public bool KiemTraAdmin(
            string tendn,
            string matkhau
            )
        {
            tblLOGIN admin = db.tblLOGINs.Select(s => s).Where(eq => eq.TenDN == tendn && eq.MatKhau == matkhau && eq.Quyen == "Admin").FirstOrDefault();
            if (admin != null)
            {
                return true;
            }
            return false;
        }

        public bool KiemTraMember(
            string tendn,
            string matkhau
    )
        {
            tblLOGIN member = db.tblLOGINs.Select(s => s).Where(eq => eq.TenDN == tendn && eq.MatKhau == matkhau && eq.Quyen == "Member").FirstOrDefault();
            if (member != null)
            {
                return true;
            }
            return false;
        }

        public bool isValidAccount(
            string tendn,
            string matkhau
            )
        {
            tblLOGIN isvalid = db.tblLOGINs.Select(s => s).Where(eq => eq.TenDN == tendn && eq.MatKhau == matkhau).FirstOrDefault();
            if (isvalid != null)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(
           string accountName,
           string newPassowrd,
           string oldPassword,
           string role
           )
        {
            tblLOGIN user = db.tblLOGINs
                .Where(eq => eq.TenDN == accountName)
                .Select(s => s)
                .FirstOrDefault();
            tblLOGIN checkOldPassword = db.tblLOGINs.Where(eq => eq.MatKhau == oldPassword).Select(s => s).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else if (checkOldPassword == null)
            {
                return false;
            }
            user.TenDN = accountName;
            user.MatKhau = newPassowrd;
            user.Quyen = role;

            db.SubmitChanges();

            return true;
        }

        public bool ThemNguoiDung(
            string tendn,
            string matkhau,
            string hoten,
            string gioitinh,
            string phone,
            string email,
            string quyen
            )
        {
            Login user = db.tblLOGINs
                .Where(eq => eq.TenDN == tendn)
                .Select(s => new Login(
                    s.TenDN,
                    s.MatKhau,
                    s.HoTen,
                    s.GioiTinh,
                    s.Phone,
                    s.Email,
                    s.Quyen
                    ))
                .FirstOrDefault();
            if (user != null)
            {
                return false;
            }

            tblLOGIN newUser = new tblLOGIN();

            newUser.TenDN = tendn;
            newUser.HoTen = hoten;
            newUser.MatKhau = matkhau;
            newUser.GioiTinh = gioitinh;
            newUser.Phone = phone;
            newUser.Email = email;
            newUser.Quyen = quyen;  

            db.tblLOGINs.InsertOnSubmit(newUser);

            db.SubmitChanges();

            return true;
        }

        public bool SuaNguoiDung(
            string tendn,
            string matkhau,
            string hoten,
            string gioitinh,
            string phone,
            string email,
            string quyen
            )
        {
            tblLOGIN user = db.tblLOGINs
                .Where(eq => eq.TenDN == tendn)
                .Select(s => s)
                .FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            user.TenDN = tendn;
            user.HoTen = hoten;
            user.MatKhau = matkhau;
            user.GioiTinh = gioitinh;
            user.Phone = phone;
            user.Email = email;
            user.Quyen = quyen;

            db.SubmitChanges();

            return true;
        }

        public bool XoaSV(string tendn)
        {
            tblLOGIN deleted = db.tblLOGINs.Select(s => s).FirstOrDefault(s => s.TenDN.Equals(tendn));

            db.tblLOGINs.DeleteOnSubmit(deleted);

            db.SubmitChanges();

            return true;
        }
    }
}
