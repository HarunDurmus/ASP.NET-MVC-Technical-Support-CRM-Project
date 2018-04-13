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
    [Table("Companys")]
    public class Company 
    {
        // public string company_id { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /*public string companyName { get; set; }
        [DisplayName("şirket login ismi"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string CloginName { get; set; }
        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string password { get; set; }*/
        public int phoneNumber { get; set; }
        public string email { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; } /* virtual değişkenden sonra nerden getiriyor isek onun id sini 
        vereceğiz örneğin public int LocationId { get; set; }*/
        public virtual List<Responsible> ResponsiblesOnes { get; set; }
        public Company()
        {
            ResponsiblesOnes = new List<Entities.Responsible>();
            
        }
    }
}
