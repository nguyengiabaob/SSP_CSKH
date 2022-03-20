using CSKH_SSP.Interfaces.INotificationRealtimeService;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CSKH_SSP.Services.RealtimeServices
{
    public class NotificationRealtime : INotificationRealtime
    {
        private readonly IHubContext<SignalServer> _iHubContext;
        string connectionString = "";

        public NotificationRealtime(IHubContext<SignalServer> iHubContext, IConfiguration configuration)
        {
            _iHubContext = iHubContext;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public int CountNotification(string UserName)
        {
            //var employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = @"SELECT [RequestID] from [dbo].[Notification] where [UserName] = @UserName";
                
                SqlCommand cmd = new SqlCommand(commandText, conn);
                cmd.Parameters.AddWithValue("@UserName", UserName);

                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    var employee = new Employee
                //    {
                //        Id = Convert.ToInt32(reader["Id"]),
                //        Name = reader["Name"].ToString(),
                //        Age = Convert.ToInt32(reader["Age"])
                //    };

                //    employees.Add(employee);
                //}
            }

            return 0;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            _iHubContext.Clients.All.SendAsync("ListenNotification");
        }
    }
}
