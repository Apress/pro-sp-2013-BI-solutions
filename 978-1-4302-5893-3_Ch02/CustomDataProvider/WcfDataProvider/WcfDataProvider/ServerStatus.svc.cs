using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace WcfDataProvider
{

    public class ServerStatus : IServerStatus
    {
        [OperationBehavior]
        public DataTable GetServerStatusDetails()
        {
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["VisioServicesConnectionString"].ConnectionString);

            SqlCommand command = new SqlCommand("uspGetServerDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            dataAdapter.Fill(dataSet);
            connection.Close();
            return dataSet.Tables[0];
        }
    }
}
