using Grpc.Core;

namespace _4EPlatform_LegalManagement_API.GrpClientsConfig
{
    public static class GrpcServiceClients
    {
        public static IHttpClientBuilder AddGrpcServiceClient<TService>(
    this IServiceCollection services, string serviceUrl)
    where TService : ClientBase
        {
            return services.AddGrpcClient<TService>(o =>
            {
                o.Address = new Uri(serviceUrl);
                o.CallOptionsActions.Add(async (callOptionsContext) =>
                {
                    var tokenService = callOptionsContext.ServiceProvider.GetRequiredService<ITokenService>();

                    // لو مفيش HttpContext معناها Hangfire
                    if (callOptionsContext.ServiceProvider
                            .GetRequiredService<IHttpContextAccessor>()
                            .HttpContext == null)
                    {
                        var callOptions = tokenService.GetAccessTokenHangFireAsync().Result;
                        callOptionsContext.CallOptions = callOptions;
                    }
                    else
                    {
                        var callOptions = tokenService.AcquireToken().Result;
                        callOptionsContext.CallOptions = callOptions;
                    }
                });
            });
        }

    }
}