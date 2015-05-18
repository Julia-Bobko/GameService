using GameService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameService.Wcf
{
    [ServiceContract]
    interface IOnlineGameService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CreateGame/{idFirstGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        bool CreateGame(string idFirstGamer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "StartGame/{idGame}/{idSecondGamer}/{idCurrentGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        bool StartGame(string idGame, string idSecondGamer, string idCurrentGamer);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "UpdateStatusGame/{idGame}/{xmlCurrentStatus}/{idGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        //bool UpdateStatusGame(string idGame, string xmlCurrentStatus, string idGamer);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool UpdateStatusGame(UpdateStatus obj);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetStatusGame/{idGame}/{idGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        StatusGame GetStatusGame(string idGame, string idGamer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetFullStatusGame/{idGame}/{idGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        string GetFullStatusGame(string idGame, string idGamer);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "GetGames/{userName}/{online}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        //List<CheckersGame> GetGames(string userName, string online);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetGames/{idCurrentGamer}/{userName}/{online}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        List<CheckersGame> GetGames(string idCurrentGamer, string userName, string online);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "CheckInputGame/{idFirstGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        InputGame CheckInputGame(string idFirstGamer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCurrentGames/{idCurrentGamer}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        List<CurrentGame> GetCurrentGames(string idCurrentGamer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCurrentStatusGame/{idGame}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        CurrentStatusGame GetCurrentStatusGame(string idGame);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FinishGame/{idGame}/{idWinner}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Xml)]
        bool FinishGame(string idGame, string idWinner);
    }

}
