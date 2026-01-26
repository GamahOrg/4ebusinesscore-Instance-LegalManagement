using Legal.API.Protos;
using Notification.Aggregator.Protos;

namespace _4EPlatform_LegalManagement_API.GrpClientsConfig
{
    public static class GrpcClients
    {
        #region PermissionGrouping
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string UserManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(UserManagmentUrl);

        }
        #endregion
        #region Notification
        public static void AddNotification(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<ReceivedNotificationServices.ReceivedNotificationServicesClient>(url);
        }
        #endregion
        #region UserManagement
        public static void AddUser(this IServiceCollection services, string url)
        {
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(url);
        }
        #endregion
    }
}
