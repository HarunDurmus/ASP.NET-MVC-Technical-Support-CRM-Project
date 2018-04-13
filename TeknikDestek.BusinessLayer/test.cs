using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikDestek.BusinessLayer
{
    public class test
    {
        public test()
        {
            DataAccessLayer.EntityFramework.DataBaseContext db = new DataAccessLayer.EntityFramework.DataBaseContext();
            db.Supporters.ToList();
        }
    }
}
