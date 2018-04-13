using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikDestek.Entities
{
    [Table("ResponsibleOnes")]
    public class Responsible   //responsible çağrı yapacak
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public int res_id { get; set; }
        public int RCompanyId { get; set; }
        public string email { get; set; }
        public virtual Company RCompany { get; set; }
        public virtual User user { get; set; }
        public virtual List<Request> Request { get; set; }
        

        public Responsible()
        {
            Request = new List<Entities.Request>();
        }
    }
}
