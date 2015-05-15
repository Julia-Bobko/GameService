using GameService.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStatisticsService" in both code and config file together.
    [ServiceContract]
    public interface IStatisticsService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "CreateStatistics/{titleGame}/{userName}/{country}/{count}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool CreateStatistics(string titleGame, string userName, string country, string count);
        [OperationContract]
        [WebInvoke(UriTemplate = "UpdateStatistics/{userName}/{titleGame}/{count}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool UpdateStatistics(string userName, string titleGame, string count);
        [OperationContract]
        [WebInvoke(UriTemplate = "DeleteStatistics/{userName}/{titleGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool DeleteStatistics(string userName, string titleGame);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetStatisticsCollection/{titleGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        IEnumerable<Statistics> GetStatisticsCollection(string titleGame);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetStatistics/{userName}/{titleGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        Statistics GetStatistics(string userName, string titleGame);
        [OperationContract]
        [WebInvoke(UriTemplate = "Test/{userName}/{titleGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        string Test(string userName, string titleGame);
        [OperationContract]
        [WebInvoke(UriTemplate = "IsExistUserName/{userName}/{titleGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        bool IsExistUserName(string userName, string titleGame);
    }
}
