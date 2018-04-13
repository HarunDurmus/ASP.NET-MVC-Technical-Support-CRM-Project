using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikDestek.BusinessLayer.Abstract;
using TeknikDestek.BusinessLayer.Result;
using TeknikDestek.Entities;
using TeknikDestek.Entities.Message;

namespace TeknikDestek.BusinessLayer
{
    public class ResponsibleManager : ManagerBase<Responsible>
    {
        
        
        public BusinessLayerResult<Responsible> UpdateProfile(Responsible data)
        {
            Responsible db_user = Find(x => x.user.userName == data.user.userName );
            BusinessLayerResult<Responsible> res = new BusinessLayerResult<Responsible>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.user.userName == data.user.userName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.user.firstName = data.user.firstName;
            res.Result.user.lastName = data.user.lastName;
            res.Result.user.userName = data.user.userName;
            res.Result.user.password = data.user.password;
            res.Result.user.userStatus = data.user.userStatus;
            
            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil güncellenemedi.");
            }

            return res;
        }

        public BusinessLayerResult<Responsible> RemoveUserById(int id)
        {
            BusinessLayerResult<Responsible> res = new BusinessLayerResult<Responsible>();
            Responsible user = Find(x => x.Id == id);

            if (user != null)
            {
                if (Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı bulunamadı.");
            }

            return res;
        }

        

        // Method hiding..
        public new BusinessLayerResult<Responsible> Insert(Responsible data)
        {
            Responsible user = Find(x => x.user.userName == data.user.userName);
            BusinessLayerResult<Responsible> res = new BusinessLayerResult<Responsible>();

            Responsible db_user = List().OrderByDescending(x => x.Id).FirstOrDefault();
            

            res.Result = data;

            if (user != null)
            {
                if (user.user.userName == data.user.userName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }

               
            }
            else
            {
      
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotInserted, "Kullanıcı eklenemedi.");
                }
            }
            if (db_user.user.resId == data.user.resId || db_user.user.resId > data.user.resId || db_user.user.resId + 1 < data.user.resId)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "kullanıcı id kayıtlı.");
            }

            return res;
        }

        public new BusinessLayerResult<Responsible> Update(Responsible data)
        {
            Responsible db_user = Find(x => x.user.userName == data.user.userName );
            BusinessLayerResult<Responsible> res = new BusinessLayerResult<Responsible>();
            res.Result = data;

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.user.userName == data.user.userName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }

                
                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.user.firstName = data.user.firstName;
            res.Result.user.lastName = data.user.lastName;
            res.Result.user.userName = data.user.userName;
            res.Result.user.password = data.user.password;
            res.Result.user.userStatus = data.user.userStatus;

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdated, "Kullanıcı güncellenemedi.");
            }

            return res;
        }

        


    }
}
