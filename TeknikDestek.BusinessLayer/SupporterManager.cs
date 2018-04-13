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
    public class SupporterManager : ManagerBase<Supporter>
    {

        public BusinessLayerResult<Supporter> UpdateProfile(Supporter data)
        {
            Supporter db_user = Find(x => x.user.userName == data.user.userName);
            BusinessLayerResult<Supporter> sup = new BusinessLayerResult<Supporter>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.user.userName == data.user.userName)
                {
                    sup.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }

                return sup;
            }

            sup.Result = Find(x => x.Id == data.Id);
            sup.Result.user.firstName = data.user.firstName;
            sup.Result.user.lastName = data.user.lastName;
            sup.Result.user.userName = data.user.userName;
            sup.Result.user.password = data.user.password;
            sup.Result.user.userStatus = data.user.userStatus;

            if (base.Update(sup.Result) == 0)
            {
                sup.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil güncellenemedi.");
            }

            return sup;
        }

        public BusinessLayerResult<Supporter> RemoveUserById(int id)
        {
            BusinessLayerResult<Supporter> res = new BusinessLayerResult<Supporter>();
            Supporter user = Find(x => x.Id == id);

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
        public new BusinessLayerResult<Supporter> Insert(Supporter data)
        {
            Supporter user = Find(x => x.user.userName == data.user.userName);
            BusinessLayerResult<Supporter> res = new BusinessLayerResult<Supporter>();
            Supporter db_user = List().OrderByDescending(x => x.Id).FirstOrDefault();

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
            if (db_user.user.supId == data.user.supId || db_user.user.supId > data.user.supId || db_user.user.supId + 1 < data.user.supId)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "kullanıcı id kayıtlı.");
            }

            return res;
        }

        public new BusinessLayerResult<Supporter> Update(Supporter data)
        {
            Supporter db_user = Find(x => x.user.userName == data.user.userName);
            BusinessLayerResult<Supporter> res = new BusinessLayerResult<Supporter>();
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
