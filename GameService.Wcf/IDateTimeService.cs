using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameService.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDateTimeService" in both code and config file together.
    [ServiceContract]
    public interface IDateTimeService
    {
        [WebInvoke(UriTemplate = "GetCurrentTime/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, Method = "GET")]
        DateTime GetCurrentTime();
    }
}
