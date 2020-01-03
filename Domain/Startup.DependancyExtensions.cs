using FileCDN.Models.Service;
using Elastic.Models.Services;
using Elastic.Models.Data;
using Elastic.Models.Contracts;
using ImageProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Models.Context;
using Models.Contracts;
using Models.Services;
using WebCommon.Services;

namespace Domain
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<IHtmlService, HtmlService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IConsultationService, ConsultationService>();
            services.AddTransient<INomenclatureService, NomenclatureService>();
            services.AddTransient<IQuestionaryService, QuestionaryService>();
            services.AddTransient<ILinksService, LinksService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IPCSubjectsService, PCSubjectsService>();
            services.AddTransient<IChangeProposalsService, ChangeProposalsService>();
            services.AddTransient<ITargetGroupsService, TargetGroupsService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IPublicationService, PublicationService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IStrategicDocumentsService, StrategicDocumentsService>();
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IMulticriteriaAnalisysService, MulticriteriaAnalisysService>();
            services.AddTransient<IAboutUsService, AboutUsService>();
            services.AddTransient<IInstitutionTypeService, InstitutionTypeService>();
            services.AddTransient<IPublicationCategoriesService, PublicationCategoriesService>();
            services.AddTransient<INewsCategoriesService, NewsCategoriesService>();
            services.AddTransient<IDocumentKindService, DocumentKindService>();
            services.AddTransient<IBannersService, BannersService>();
            services.AddTransient<IUsersInfoService, UsersInfoService>();
            services.AddTransient<ISiteLogService, SiteLogService>();

            //services.AddTransient<IApplicationService, ApplicationService>();
            //services.AddTransient<INomService, NomService>();

            //services.AddTransient<IRiskService, RiskService>();
            //services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<ICdnService<MainContext>, CdnService<MainContext>>();

            // Add Elastic services.
            services.AddTransient(typeof(elasticData));
            services.AddTransient<IDataIndexerService, DataIndexerService>();
            services.AddTransient<ISearchService, SearchService>();

            // Add  StaticPages services
            services.AddTransient<IStaticPagesService, StaticPagesService>();

            //Add Ogp service
            services.AddTransient<IOgpService, OgpService>();


            return services;
        }
    }
}
