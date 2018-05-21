using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlain.DAO
{
    public class LoaiGheDAO
    {
        DatVeMayBayDBEntities db = null;
        public LoaiGheDAO()
        {
            db = new DatVeMayBayDBEntities();
        }
        public List<LOAIGHE> getList()
        {            
            return db.LOAIGHEs.ToList();
        }
        
    }
}
