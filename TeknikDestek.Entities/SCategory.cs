using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikDestek.Entities
{
    [Table("SCategories")]
    public class SCategory 
    {
        //public int scategory_id { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string scategoryName { get; set; }
        public int manager_Id{ get; set; }
        public virtual List<Supporter> Supporters { get; set; }
        public SCategory()
        {
            Supporters = new List<Entities.Supporter>();
        }
        
    }
}
