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
        bool CreateRatingPOST(Rating rating);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CreateRatingGET/{idGamer}/{game}/{score}/{additionalInfo}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        bool CreateRatingGET(string idGamer, string game, string score, string additionalInfo);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateRatingPOST(Rating rating);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UpdateRatingGET/{idGamer}/{game}/{score}/{additionalInfo}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        bool UpdateRatingGET(string idGamer, string game, string score, string additionalInfo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetRating/{idGamer}/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        Rating GetRating(string idGamer, string game);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetRatings/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        IEnumerable<RatingInfo> GetRatings(string game);
    }
}
