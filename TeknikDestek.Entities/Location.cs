using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikDestek.Entities
{
    [Table("Locations")]
    public class Location 
    {
        // public int location_id { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string streetAddres { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }

       
    }
}
