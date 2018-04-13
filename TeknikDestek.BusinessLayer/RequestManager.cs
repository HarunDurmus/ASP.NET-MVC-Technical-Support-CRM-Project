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
    public class RequestManager : ManagerBase<Request>
    {
        public new BusinessLayerResult<Request> Insert(Request data)
        {
            Request req = Find(x => x.Id == data.Id);
            BusinessLayerResult<Request> res = new BusinessLayerResult<Request>();
            
            res.Result = data;

           
            if (req.SupportersId == data.SupportersId)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "bu suppoerter adı kayıtlı.");
            }

            //if (req.SupportersId == data.SupportersId) 
            //{
            //    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "bu suppoerter zaten ekli");
            //}

            return res;
        }
    }
}
