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
    [ServiceContract]
    public interface IRatingService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CreateRating(Rating rating);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateRating(Rating rating);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetRating/{idGamer}/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        Rating GetRating(string idGamer, string game);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetRatings/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        IEnumerable<Rating> GetRatings(string game);
    }
}
