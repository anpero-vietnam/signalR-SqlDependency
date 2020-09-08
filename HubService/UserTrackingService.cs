using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;
namespace HubService
{
    public class UserTrackingService : IDisposable
    {
        private readonly static Lazy<UserTrackingService> _instance = new Lazy<UserTrackingService>(() => new UserTrackingService(GlobalHost.ConnectionManager.GetHubContext<UserHub>().Clients));
        private SqlTableDependency<UserTracking> SqlTableDependency { get; }
        private IHubConnectionContext<dynamic> Clients { get; }
        public static UserTrackingService Instance => _instance.Value;

        private UserTrackingService(IHubConnectionContext<dynamic> clients)
        {
            this.Clients = clients;
            //Because our C# model has a property not matching database table name, an explicit mapping is required just for this property.
            var mapper = new ModelToTableMapper<UserTracking>();
            mapper.AddMapping(x => x.Status, "Status");

            // Because our C# model name differs from table name we have to specify database table name.
            this.SqlTableDependency = new SqlTableDependency<UserTracking>(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString, "Users", mapper: mapper);

            this.SqlTableDependency.OnChanged += this.TableDependency_OnChanged;
            this.SqlTableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, RecordChangedEventArgs<UserTracking> e)
        {
            switch (e.ChangeType)
            {
                case ChangeType.Delete:
                    this.Clients.User(e.Entity.UserId).removeUserTrigger(e.Entity);
                    break;

                case ChangeType.Insert:
                    this.Clients.All.addUserTrigger(e.Entity);
                    break;

                case ChangeType.Update:
                    this.Clients.User(e.Entity.UserId).updateUserTrigger(e.Entity);
                    break;
            }
        }
        public void Dispose()
        {
            // Invoke Stop() in order to remove all DB objects genetated from SqlTableDependency.
            this.SqlTableDependency.Stop();
        }
    }
    public class UserTracking
    {
        public string UserId { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
    }
}
