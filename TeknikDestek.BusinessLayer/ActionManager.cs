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
    public class ActionManager : ManagerBase<RAction>
    {
        public new BusinessLayerResult<RAction> Insert(RAction data)
        {
            //RAction act = Find(x => x.RequestId == data.RequestId);
            BusinessLayerResult<RAction> res = new BusinessLayerResult<RAction>();
            RAction db_act = List().OrderByDescending(x => x.Id).FirstOrDefault();

            res.Result = data;
            

            //if (base.Insert(res.Result) == 0)
            //{
            //        res.AddError(ErrorMessageCode.UserCouldNotInserted, "aksiyon eklenemedi eklenemedi.");
            //}
         

            if (db_act.RequestId > data.RequestId || db_act.RequestId < data.RequestId)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "request id yanlış girilidi.");
            }

            return res;
        }
    }
}
