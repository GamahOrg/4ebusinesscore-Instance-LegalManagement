using _4EPlatform.Application.Helpers.CauseHistoryHelper;
using _4EPlatform.Application.Services.AssignMember;
using _4EPlatform.Application.Services.CauseServices;
using _4EPlatform.Application.Services.CauseStageAttachments;
using _4EPlatform.Application.Services.CauseStageServices;
using _4EPlatform.Application.Services.JudgementGround;
using _4EPlatform.Application.Services.LawyerServices;
using _4EPlatform.Application.Services.SessionNote;
using _4EPlatform.Application.Services.SessionService;
using _4EPlatform.PermissionsGroupingChecker;
using MicroBlocks.Application;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace _4EPlatform_LegalManagement_API.Extention
{
    public static class ServiceExtension
    {

        public static void AddMapGrpcServicesApp(this WebApplication app)
        {
            app.MapGrpcService<CauseService>();
            app.MapGrpcService<CauseStageService>();
            app.MapGrpcService<SessionService>();
            app.MapGrpcService<SessionNoteService>();
            app.MapGrpcService<AssignMemberServices>();
            app.MapGrpcService<JudgmentGroundService>();
            app.MapGrpcService<LawyerService>();
            app.MapGrpcService<CauseStageAttachmentsService>();
            app.MapGrpcService<GetAllSessionsService>();
        }
        public static void AddUnitOfWorkRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            services.AddScoped<HistoryHelper>();
            services.AddScoped<CheckUserTeamHelper>();
            services.AddScoped<HangFireHelper>();
        }
        public static void AddDiServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(AppDomain.CurrentDomain.Load("4EPlatform.Application"));
            services.AddAutoMapper((typeof(ApplicationLayer)));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR((typeof(ApplicationLayer)));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(AppDomain.CurrentDomain.Load("4EPlatform.Application"));
            services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddScoped(typeof(IResponseHelper), typeof(ResponseHelper));
            services.AddSingleton<ITokenService, TokenService>();
        }
        public static void AddRateLimitings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(options =>
            {
                var rateLimitSection = configuration.GetSection("RateLimit");
                var permitLimit = rateLimitSection.GetValue<int>("PermitLimit");
                var queueLimit = rateLimitSection.GetValue<int>("QueueLimit");
                var windowSeconds = rateLimitSection.GetValue<int>("WindowSeconds");
                options.AddFixedWindowLimiter("FixedWindowPolicy", opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(windowSeconds);
                    opt.PermitLimit = permitLimit;
                    opt.QueueLimit = queueLimit;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = 429;
            });
        }
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning().AddApiExplorer(options =>
            {
                // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
            });
        }
        public static void AddLocalizationOptions(this IServiceCollection services)
        {
            services.AddLocalization(options => { options.ResourcesPath = ""; });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de-DE"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar")
                };
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
