using GameService.Entities;
using GameService.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewStatisticsService" in both code and config file together.
    [ServiceContract]
    public interface INewStatisticsService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool CreateStatistics(NewStatistics obj);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateStatistics(NewStatistics obj);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateStatisticsWithoutProgress(NewStatistics obj);
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        IEnumerable<NewStatistics> GetStatisticsCollectionBySocial(FriendsRequest obj);
        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteStatistics/{userId}/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool DeleteStatistics(string userId, string game);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetStatisticsCollection/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        IEnumerable<NewStatistics> GetStatisticsCollection(string game);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetStatisticsCollectionByCity/{game}/{city}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        IEnumerable<NewStatistics> GetStatisticsCollectionByCity(string game, string city);
        //[OperationContract]
        //[WebInvoke(UriTemplate = "GetStatisticsCollectionBySocial/{game}/{social}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        //IEnumerable<NewStatistics> GetStatisticsCollectionBySocial(string game, string social);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetStatistics/{userId}/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        NewStatistics GetStatistics(string userId, string game);
        [OperationContract]
        [WebInvoke(UriTemplate = "IsExistUserName/{userId}/{game}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool IsExistUserName(string userId, string game);
    }
}
