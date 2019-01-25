-- ******************************************************** pf_PopForumsUser
DELETE FROM [pf_PopForumsUser] 
SET IDENTITY_INSERT pf_PopForumsUser ON
INSERT INTO [pf_PopForumsUser] (
       [UserID]
      ,[Name]
      ,[Email]
      ,[CreationDate]
      ,[IsApproved]
      ,[LastActivityDate]
      ,[LastLoginDate]
      ,[Password]
      ,[AuthorizationKey]
      ,[Salt]
	  )
SELECT [Id]
      ,ISNULL([FullName], '')
	  ,[Email]
	  ,[DateCreated]
	  ,[IsApproved]
	  ,GETDATE() 
	  ,GETDATE() 
	  ,ISNULL([Password], 'r6i9WpV/4WMU8ozJAT4edw==')
	  ,NEWID()
	  ,NEWID()
FROM [StrategyPortalDev2].[account].[users]
SET IDENTITY_INSERT pf_PopForumsUser OFF
GO


-- ******************************************************** pf_Profile
DELETE FROM [pf_Profile] 
INSERT INTO [pf_Profile] (
	   [UserID]
      ,[IsSubscribed]
      ,[Signature]
      ,[ShowDetails]
      ,[Location]
      ,[IsPlainText]
      ,[DOB]
      ,[Web]
      ,[ICQ]
      ,[YahooMessenger]
      ,[Facebook]
      ,[Twitter]
      ,[IsTos]
      ,[TimeZone]
      ,[IsDaylightSaving]
      ,[AvatarID]
      ,[ImageID]
      ,[HideVanity]
      ,[LastPostID]
      ,[Points]
)
SELECT [UserID]
      ,1 IsSubscribed
      ,'' Signature
      ,1 ShowDetails
      ,'' Location
      ,0 IsPlainText
      ,null DOB
      ,'' Web
	  ,'' ICQ
	  ,'' YahooMessenger
	  ,'' Facebook
	  ,'' Twitter
	  ,1 IsTos
	  ,2 TimeZone
	  ,1 IsDaylightSaving
	  ,null AvatarID
	  ,null ImageID
	  ,1 HideVanity
	  ,4 LastPostID
	  ,0 Points
  FROM [StrategyPortalDev2].[dbo].[pf_PopForumsUser]
GO


-- ******************************************************** pf_Category
DELETE FROM [pf_Category]
SET IDENTITY_INSERT [pf_Category] ON
INSERT INTO [pf_Category] (
       [CategoryID]
      ,[Title]
      ,[SortOrder]
)
SELECT [Id]
      ,[Name]
      ,[Priority]

FROM [StrategyPortalDev2].[dbo].[ForumGroups]
SET IDENTITY_INSERT pf_PopForumsUser OFF
GO



-- ******************************************************** pf_Forum
DELETE FROM [pf_Forum] 
SET IDENTITY_INSERT [pf_Forum] ON
INSERT INTO [pf_Forum]
 (     [ForumID]
      ,[CategoryID]
      ,[Title]
      ,[Description]
      ,[IsVisible]
      ,[IsArchived]
      ,[SortOrder]
      ,[TopicCount]
      ,[PostCount]
      ,[LastPostTime]
      ,[LastPostName]
      ,[UrlName]
      ,[ForumAdapterName]
      ,[IsQAForum]
)
SELECT 
	[Id]
      ,[ForumGroupId]
      ,LEFT (ISNULL([Name], 'Няма име'), 99 ) Name
      ,LEFT (ISNULL([Description], 'Няма описание'), 254 ) Description
	  ,[IsApproved]
	  ,[IsDeleted]
	  ,[Priority]
	  ,[NumTopics]
	  ,[NumPosts]
      ,ISNULL([LastPostedDate], GETDATE())
      ,ISNULL((SELECT Topic from ForumTopics WHERE ForumTopics.Id = [LastTopicId]), 'Няма публикации') LastPostName 
      ,NEWID()
	  ,NULL
      ,0
  FROM [StrategyPortalDev2].[dbo].[Forums]
    SET IDENTITY_INSERT [pf_Forum] OFF
GO


-- ******************************************************** pf_Topic
DELETE FROM [pf_Topic] 
SET IDENTITY_INSERT [pf_Topic] ON
INSERT INTO [pf_Topic]
(
       [TopicID]
      ,[ForumID]
      ,[Title]
      ,[ReplyCount]
      ,[ViewCount]
      ,[StartedByUserID]
      ,[StartedByName]
      ,[LastPostUserID]
      ,[LastPostName]
      ,[LastPostTime]
      ,[IsClosed]
      ,[IsPinned]
      ,[IsDeleted]
      ,[IsIndexed]
      ,[UrlName]
      ,[AnswerPostID]
)
SELECT 
	   [Id]
      ,[ForumId]
	  ,[Topic]
	  ,[NumPosts]
	  ,0
	  ,[CreatedByUserId]
	  ,ISNULL((SELECT Name from pf_PopForumsUser WHERE pf_PopForumsUser.UserID = [ForumTopics].CreatedByUserId),'') CreatedUserName
      ,ISNULL([LastUserId],'')
	  ,ISNULL((SELECT Name from pf_PopForumsUser WHERE pf_PopForumsUser.UserID = [ForumTopics].LastUserId),'') LastUserName
	  ,ISNULL([LastPostedDate], GETDATE())
	  ,REPLACE(REPLACE([IsActive],0,1),1,0) AS [IsClosed]
	  ,0
	  ,[IsDeleted]
	  ,0
	  , NEWID()
	  ,[LastMessageId]
  FROM [StrategyPortalDev2].[dbo].[ForumTopics] 

  SET IDENTITY_INSERT [pf_Topic] OFF
GO


-- ******************************************************** pf_Post
DELETE FROM [pf_Post] 
SET IDENTITY_INSERT [pf_Post] ON
INSERT INTO [pf_Post]
(	   [PostID]
      ,[TopicID]
      ,[ParentPostID]
      ,[IP]
      ,[IsFirstInTopic]
      ,[ShowSig]
      ,[UserID]
      ,[Name]
      ,[Title]
      ,[FullText]
      ,[PostTime]
      ,[IsEdited]
      ,[LastEditName]
      ,[LastEditTime]
      ,[IsDeleted]
      ,[Votes]
	  )
SELECT [Id]
      ,[TopicId]
	  ,null ParentPostID
	  ,null IP
	  ,null IsFirstInTopic
	  ,null ShowSig
      ,[UserId]
	  ,ISNULL((SELECT Name from pf_PopForumsUser WHERE pf_PopForumsUser.UserID = [ForumMessages].[UserId]),'') Name
	  ,'Без заглавие' Title
	  ,[Message]
      ,[Posted]
	  ,0 IsEdited
	  ,ISNULL((SELECT Name from pf_PopForumsUser WHERE pf_PopForumsUser.UserID = [ForumMessages].[ModifiedByUserId]),'') LastEditName
	  ,[DateModified]
      ,[IsDeleted]
	  ,0 Votes

  FROM [StrategyPortalDev2].[dbo].[ForumMessages]