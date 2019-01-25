using FileCDN.Models.Data;
using Microsoft.EntityFrameworkCore;
using Models.Context.Account;
using Models.Context.Consultations;
using Models.Context.Legacy;
using Models.Context.Questionary;
using Models.Context.Ogp;
using Models.Context.Notifications;
using Models.Context.LinksModels;
using Models.Context.PCSubjectsModels;
using Models.Context.MulticriteriaAnalysis;

namespace Models.Context
{
	public class MainContext : DbContext
	{
		public MainContext(DbContextOptions<MainContext> options)
										: base(options)
		{ }

		//CMS
		public virtual DbSet<Page> Pages { get; set; }
		public virtual DbSet<PageLink> PageLinks { get; set; }
		public virtual DbSet<Library> Libraries { get; set; }
		public virtual DbSet<PageType> PageTypes { get; set; }
		public virtual DbSet<PageState> PageStates { get; set; }
		public virtual DbSet<GenericContent> GenericContent { get; set; }

		// Legacy
		public virtual DbSet<TargetGroups> TargetGroups { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<NewsCategories> NewsCategories { get; set; }
		public virtual DbSet<Publications> Publications { get; set; }
		public virtual DbSet<PublicationCategories> PublicationCategories { get; set; }
		public virtual DbSet<Articles> Articles { get; set; }
		public virtual DbSet<ArticleCategories> ArticleCategories { get; set; }

		public virtual DbSet<StrategicDocuments> StrategicDocuments { get; set; }
		public virtual DbSet<StrategicDocumentTypes> StrategicDocumentTypes { get; set; }
		public virtual DbSet<InstitutionTypes> InstitutionTypes { get; set; }



		//Account
		public virtual DbSet<vOldUser> vOldUsers { get; set; }
		public virtual DbSet<Users> Users { get; set; }
		public virtual DbSet<UsersTypes> UsersTypes { get; set; }

		public virtual DbSet<Roles> Roles { get; set; }
		public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }
		public virtual DbSet<Groups> Groups { get; set; }
		public virtual DbSet<UsersInCategories> UsersInCategories { get; set; }
		public virtual DbSet<UsersInGroups> UsersInGroups { get; set; }
		public virtual DbSet<UsersInTargetGroups> UsersInTargetGroups { get; set; }

		// Questionary
		public virtual DbSet<QuestionaryHeaders> QuestionaryHeaders { get; set; }
		public virtual DbSet<QuestionaryQuestions> QuestionaryQuestions { get; set; }
		public virtual DbSet<QuestionaryAnswers> QuestionaryAnswers { get; set; }
		public virtual DbSet<QuestionaryPossibleAnswers> QuestionaryPossibleAnswers { get; set; }
		public virtual DbSet<QuestionaryAnsweredUsers> QuestionaryAnsweredUsers { get; set; }

		// Links
		public virtual DbSet<LinksCategories> LinksCategories { get; set; }
		public virtual DbSet<Links> Links { get; set; }

		// Public Consultation Subjects
		public virtual DbSet<PCSubjects> PCSubjects { get; set; }

		// About Us
		public virtual DbSet<AboutUs> AboutUs { get; set; }

		//StaticPages
		public virtual DbSet<StaticPages> StaticPages { get; set; }

		//CDN entity models
		public virtual DbSet<FileCdn> FileCdn { get; set; }
		public virtual DbSet<FileCdnContent> FileCdnContent { get; set; }
		public virtual DbSet<FilesCDNUsed> FilesCDNUsed { get; set; }

		//Old Files
		public virtual DbSet<FileFolders> FileFolders { get; set; }
		public virtual DbSet<Files> Files { get; set; }
		public virtual DbSet<Used_Files> Used_Files { get; set; }

		// Public Consultations
		public virtual DbSet<PublicConsultation> PublicConsultations { get; set; }
		public virtual DbSet<PublicConsultationComment> PublicConsultationComments { get; set; }
		public virtual DbSet<PublicConsultationDocument> PublicConsultationDocuments { get; set; }
		public virtual DbSet<Comments> Comments { get; set; }

		public virtual DbSet<CommentState> CommentStates { get; set; }
		public virtual DbSet<DocumentType> DocumentTypes { get; set; }
		public virtual DbSet<vSourceItems> vSourceItems { get; set; }

		////OGP
		public virtual DbSet<ElementTypes> ElementTypes { get; set; }
		public virtual DbSet<EstimationTypes> EstimationTypes { get; set; }
		public virtual DbSet<NationalPlanElements> NationalPlanElements { get; set; }
		public virtual DbSet<NationalPlanEstimations> NationalPlanEstimations { get; set; }
		public virtual DbSet<NationalPlanEstimationResults> NationalPlanEstimationResults { get; set; }
		public virtual DbSet<NationalPlanStates> NationalPlanStates { get; set; }

		///Notifications
		public virtual DbSet<Attachments> Attachments { get; set; }
		public virtual DbSet<NotificationMessages> NotificationMessages { get; set; }
		public virtual DbSet<UserNotifications> UserNotifications { get; set; }

		public virtual DbSet<ChangeProposals> ChangeProposals { get; set; }

		///MultiCriteriaAnalysis
		public virtual DbSet<Criteria> Criteria { get; set; }
		public virtual DbSet<CriteriaValue> CriteriaValue { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UsersInRoles>()
								.HasKey(ur => new { ur.UserId, ur.RoleId });

			modelBuilder.Entity<UsersInGroups>()
								.HasKey(ug => new { ug.UserId, ug.GroupUserId });

			modelBuilder.Entity<UsersInTargetGroups>()
								.HasKey(ug => new { ug.UserId, ug.TargetGroupId });

			modelBuilder.Entity<UsersInGroups>()
								.HasOne(x => x.User)
								.WithMany(x => x.UsersInGroups)
								.HasForeignKey(x => x.UserId);

			modelBuilder.Entity<UsersInCategories>()
							 .HasKey(x => new { x.UserId, x.CategoryId });

			modelBuilder.Entity<vSourceItems>()
							.HasKey(x => new { x.SourceType, x.SourceId });
		}
	}
}
