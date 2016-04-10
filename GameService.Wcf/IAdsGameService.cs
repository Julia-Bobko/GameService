using GameService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdsGameService" in both code and config file together.
    [ServiceContract]
    public interface IAdsGameService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAdsGames/{language}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        IEnumerable<AdsGame> GetAdsGames(string language);
    }
}
