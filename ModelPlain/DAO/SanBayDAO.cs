using ModelPlain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPlain.DAO
{
    public class SanBayDAO
    {
        DatVeMayBayDBEntities db = null;

        public SanBayDAO()
        {
            db = new DatVeMayBayDBEntities();
        }
        public List<SANBAY> getList()
        {
            return db.SANBAYs.ToList();
        }
    }
}
