using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlain.DAO
{
    public class KHACHHANGDAO
    {
        DatVeMayBayDBEntities db = null;
        public KHACHHANGDAO()
        {
            db = new DatVeMayBayDBEntities();
        }
        public KHACHHANG getByID(int id)
        {
            return db.KHACHHANGs.Find(id);
        }
        public int Regiter(string tenkhachhang,string username,string psw)
        {
            KHACHHANG kh = new KHACHHANG { TEN_KHACHHANG = tenkhachhang, TINHTRANG_KHACHHANG = true };
            db.KHACHHANGs.Add(kh);
            db.SaveChanges();
            if(kh.MA_KHACHHANG > 0)
            {
                var taikhoanDAO = db.TAIKHOANs.SingleOrDefault(x => x.EMAIL_TAIKHOAN == username);
                if (taikhoanDAO==null)//kiem tra tai khoan
                {
                    TAIKHOAN tk = new TAIKHOAN { EMAIL_TAIKHOAN = username, MATKHAU_TAIKHOAN = psw, MA_KHACHHANG = kh.MA_KHACHHANG, ISADMIN = false };
                    db.TAIKHOANs.Add(tk);
                    db.SaveChanges();
                    if (tk.MA_KHACHHANG <= 0)
                        return -2;
                    else return kh.MA_KHACHHANG;
                }
                else
                {
                    KHACHHANG kHACHHANG = db.KHACHHANGs.Find(kh.MA_KHACHHANG);
                    db.KHACHHANGs.Remove(kHACHHANG);
                    db.SaveChanges();
                    return -3;
                }               
            }
            else
            {
                return -1;
            }           
        }
    }
}
