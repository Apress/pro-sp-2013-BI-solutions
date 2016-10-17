using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
namespace WcfDataProvider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerStatus" in both code and config file together.
    [ServiceContract]
    public interface IServerStatus
    {
        [OperationContract]
        DataTable GetServerStatusDetails();
    }
}
