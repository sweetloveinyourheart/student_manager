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


    }
}
