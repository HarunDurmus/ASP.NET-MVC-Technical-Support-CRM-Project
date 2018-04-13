using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikDestek.BusinessLayer.Abstract;
using TeknikDestek.BusinessLayer.Result;
using TeknikDestek.Entities;
using TeknikDestek.Entities.Message;
using TeknikDestek.Entities.ValueObject;

namespace TeknikDestek.BusinessLayer
{
    public class UserManager : ManagerBase<User>
    {
        public BusinessLayerResult<User> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi?
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = Find(x => x.userName == data.userName && x.password == data.password);
           

            if (res.Result == null)
            {
               res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir.");
               res.AddError(ErrorMessageCode.CheckYourEmail, "Lütfen e-posta adresinizi kontrol ediniz.");
                
            }
          

            return res;
        }
    }
}
