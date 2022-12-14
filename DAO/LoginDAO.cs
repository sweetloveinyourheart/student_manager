using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
