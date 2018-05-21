using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelPlain.DAO
{
    public class QuocGiaDAO
    {
        DatVeMayBayDBEntities db = null;
        public QuocGiaDAO()
        {
            db = new DatVeMayBayDBEntities();
        }
        public IEnumerable<QUOCGIA> ListAll(int page,int pageSize)
        {
            return db.QUOCGIAs.ToPagedList(page,pageSize);
        }
        public QUOCGIA Create(QUOCGIA quocGia)
        {
            db.QUOCGIAs.Add(quocGia);
            db.SaveChanges();
            return quocGia;
        }
        public List<QUOCGIA> getList()
        {
            return db.QUOCGIAs.ToList();
        }
        public QUOCGIA Edit(QUOCGIA quocGia)
        {
            db.Entry(quocGia).State = EntityState.Modified;
            db.SaveChanges();
            return quocGia;
        }
        public QUOCGIA getByID(int? id)
        {
            return db.QUOCGIAs.Find(id);
        }
        public bool Delete(int? id)
        {
            try
            {
                QUOCGIA qUOCGIA = db.QUOCGIAs.Find(id);
                db.QUOCGIAs.Remove(qUOCGIA);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
