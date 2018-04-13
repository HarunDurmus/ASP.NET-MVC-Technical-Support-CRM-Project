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
    [Table("RActions")]
    public class RAction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RequestId { get; set; }
        [DisplayName("işlem durumu"),
            StringLength(150, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string statusText { get; set; }
        public DateTime dateLogged { get; set; }
        public bool status_bit { get; set; }

        public virtual Request Request { get; set; }
        

    }
}
