using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikDestek.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        

        public int? resId { get; set; }
        public int? supId { get; set; }

        public virtual List<Supporter> sup { get; set; }
        public virtual List<Responsible> res { get; set; }

        public User()
        {
            sup = new List<Supporter>();
            res = new List<Responsible>();
        }

    }
}
