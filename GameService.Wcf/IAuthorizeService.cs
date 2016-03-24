using Checkers.Entities;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorizeService" in both code and config file together.
    [ServiceContract]
    public interface IAuthorizeService
    {
        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "CreateGamer/{login}/{email}/{hashPassword}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        //int CreateGamer(string login, string email, string hashPassword);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CreateGamer(Gamer obj);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        int JVCreateGamer(Gamer obj);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "JVAuthorize/{login}/{email}/{hashPassword}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        int JVAuthorize(string login, string email, string hashPassword);
    }
}
