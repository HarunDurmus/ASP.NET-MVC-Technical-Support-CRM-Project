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
    [Table("Requests")]
    public class Request 
    {
        //public int request_id { get; set; }

        /* public int ActionsId { get; set; }*/
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? SupportersId { get; set; }
        public DateTime date { get; set; }
        public int ResponsibleId { get; set; }
        public string description { get; set; }
        /*public virtual Company RCompany { get; set; }*/
        //public virtual List<RAction> Actions { get; set; }
        public virtual Responsible Responsible { get; set; }
        public virtual List<Supporter> Supporters { get; set; }
        public object Supporter { get; set; }

        public Request()
        {
            Supporters = new List<Supporter>();
            //Actions = new List<RAction>();
        }

    }
}
