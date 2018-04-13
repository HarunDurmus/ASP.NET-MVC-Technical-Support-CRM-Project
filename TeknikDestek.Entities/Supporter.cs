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
    [Table("Supporters")]
    public class Supporter 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public int supporter_id { get; set; }
        public int? manager_id { get; set; }//boş geçilebilir
        public int? SCategoryId { get; set; }
        public virtual SCategory SCategory { get; set; }
        public virtual List<Request> Request { get; set; }
        public virtual User user { get; set; }
        public Supporter()
        {
            Request = new List<Entities.Request>();
        }


    }
}
