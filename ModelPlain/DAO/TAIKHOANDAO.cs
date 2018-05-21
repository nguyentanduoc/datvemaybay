using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlain.DAO
{
    public class TAIKHOANDAO
    {
        DatVeMayBayDBEntities db = null;
         public TAIKHOANDAO()
        {
            db = new DatVeMayBayDBEntities();
        }
        public TAIKHOAN getByIDKH(int idKH)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.MA_KHACHHANG == idKH);
        }
        public TAIKHOAN getByUserName(string u)
        {
            return db.TAIKHOANs.SingleOrDefault(x => x.EMAIL_TAIKHOAN == u);
        }
        public int Login(string user,string pass)
        {
            var rs = db.TAIKHOANs.SingleOrDefault(x => x.EMAIL_TAIKHOAN == user);

            if (rs == null)
            {
                return 0;
            }
            else
            {
                if (rs.MATKHAU_TAIKHOAN == pass)
                {
                    return 1;
                }
                else { return -1; }
            }
        }
    }
}
