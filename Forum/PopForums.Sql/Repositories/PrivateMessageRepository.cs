﻿using System;
using System.Collections.Generic;
using PopForums.Configuration;
using PopForums.Data.Sql;
using PopForums.Models;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class PrivateMessageRepository : IPrivateMessageRepository
	{
		public PrivateMessageRepository(ICacheHelper cacheHelper, ISqlObjectFactory sqlObjectFactory)
		{
			_cacheHelper = cacheHelper;
			_sqlObjectFactory = sqlObjectFactory;
		}

		private readonly ICacheHelper _cacheHelper;
		private readonly ISqlObjectFactory _sqlObjectFactory;

		public class CacheKeys
		{
			public static string PMCount(int userID)
			{
				return "PopForums.PrivateMessages.Count." + userID;
			}
		}

		public PrivateMessage Get(int pmID)
		{
			PrivateMessage pm = null;
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT PMID, Subject, LastPostTime, UserNames FROM pf_PrivateMessage WHERE PMID = @PMID")
				.AddParameter(_sqlObjectFactory, "@PMID", pmID)
				.ExecuteReader()
				.ReadOne(r => pm = new PrivateMessage { PMID = r.GetInt32(0),
												Subject = r.GetString(1),
												LastPostTime = r.GetDateTime(2),
												UserNames = r.GetString(3)}));
			return pm;
		}

		public List<PrivateMessagePost> GetPosts(int pmID)
		{
			var list = new List<PrivateMessagePost>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT PMPostID, PMID, UserID, Name, PostTime, FullText FROM pf_PrivateMessagePost WHERE PMID = @PMID ORDER BY PostTime")
				.AddParameter(_sqlObjectFactory, "@PMID", pmID)
				.ExecuteReader()
				.ReadAll(r => list.Add(new PrivateMessagePost
										{
											PMPostID = r.GetInt32(0),
											PMID = r.GetInt32(1),
											UserID = r.GetInt32(2),
											Name = r.GetString(3),
											PostTime = r.GetDateTime(4),
											FullText = r.GetString(5)
										})));
			return list;
		}

		public virtual int CreatePrivateMessage(PrivateMessage pm)
		{
			_sqlObjectFactory.GetConnection().Using(connection => pm.PMID = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "INSERT INTO pf_PrivateMessage (Subject, LastPostTime, UserNames) VALUES (@Subject, @LastPostTime, @UserNames)")
				.AddParameter(_sqlObjectFactory, "@Subject", pm.Subject)
				.AddParameter(_sqlObjectFactory, "@LastPostTime", pm.LastPostTime)
				.AddParameter(_sqlObjectFactory, "@UserNames", pm.UserNames)
				.ExecuteAndReturnIdentity()));
			return pm.PMID;
		}

		public void AddUsers(int pmID, List<int> userIDs, DateTime viewDate, bool isArchived)
		{
			foreach (var id in userIDs)
			{
				_cacheHelper.RemoveCacheObject(CacheKeys.PMCount(id));
				_sqlObjectFactory.GetConnection().Using(connection =>
					connection.Command(_sqlObjectFactory, "INSERT INTO pf_PrivateMessageUser (PMID, UserID, LastViewDate, IsArchived) VALUES (@PMID, @UserID, @LastViewDate, @IsArchived)")
					.AddParameter(_sqlObjectFactory, "@PMID", pmID)
					.AddParameter(_sqlObjectFactory, "@UserID", id)
					.AddParameter(_sqlObjectFactory, "@LastViewDate", viewDate)
					.AddParameter(_sqlObjectFactory, "@IsArchived", isArchived)
					.ExecuteNonQuery());
			}
		}

		public virtual int AddPost(PrivateMessagePost post)
		{
			var users = GetUsers(post.PMID);
			foreach (var user in users)
				_cacheHelper.RemoveCacheObject(CacheKeys.PMCount(user.UserID));
			_sqlObjectFactory.GetConnection().Using(connection => post.PMPostID = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "INSERT INTO pf_PrivateMessagePost (PMID, UserID, Name, PostTime, FullText) VALUES (@PMID, @UserID, @Name, @PostTime, @FullText)")
				.AddParameter(_sqlObjectFactory, "@PMID", post.PMID)
				.AddParameter(_sqlObjectFactory, "@UserID", post.UserID)
				.AddParameter(_sqlObjectFactory, "@Name", post.Name)
				.AddParameter(_sqlObjectFactory, "@PostTime", post.PostTime)
				.AddParameter(_sqlObjectFactory, "@FullText", post.FullText)
				.ExecuteAndReturnIdentity()));
			return post.PMPostID;
		}

		public List<PrivateMessageUser> GetUsers(int pmID)
		{
			var list = new List<PrivateMessageUser>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT PMID, UserID, LastViewDate, IsArchived FROM pf_PrivateMessageUser WHERE PMID = @PMID")
					.AddParameter(_sqlObjectFactory, "@PMID", pmID)
					.ExecuteReader()
					.ReadAll(r => list.Add(new PrivateMessageUser
					{
						PMID = r.GetInt32(0),
						UserID = r.GetInt32(1),
						LastViewDate = r.GetDateTime(2),
						IsArchived = r.GetBoolean(3)
					})));
			return list;
		}

		public void SetLastViewTime(int pmID, int userID, DateTime viewDate)
		{
			_cacheHelper.RemoveCacheObject(CacheKeys.PMCount(userID));
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "UPDATE pf_PrivateMessageUser SET LastViewDate = @LastViewDate WHERE UserID = @UserID AND PMID = @PMID")
				.AddParameter(_sqlObjectFactory, "@LastViewDate", viewDate)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.AddParameter(_sqlObjectFactory, "@PMID", pmID)
				.ExecuteNonQuery());
		}

		public void SetArchive(int pmID, int userID, bool isArchived)
		{
			_cacheHelper.RemoveCacheObject(CacheKeys.PMCount(userID));
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "UPDATE pf_PrivateMessageUser SET IsArchived = @IsArchived WHERE UserID = @UserID AND PMID = @PMID")
				.AddParameter(_sqlObjectFactory, "@IsArchived", isArchived)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.AddParameter(_sqlObjectFactory, "@PMID", pmID)
				.ExecuteNonQuery());
		}

		public List<PrivateMessage> GetPrivateMessages(int userID, PrivateMessageBoxType boxType, int startRow, int pageSize)
		{
			var isArchived = boxType == PrivateMessageBoxType.Archive;
			const string sql =
			@"DECLARE @Counter int
SET @Counter = (@StartRow + @PageSize - 1)

SET ROWCOUNT @Counter;

WITH Entries AS ( 
	SELECT ROW_NUMBER() OVER (ORDER BY [LastPostTime] DESC)
	AS Row, P.PMID, Subject, LastPostTime, UserNames, U.LastViewDate 
	FROM pf_PrivateMessage P JOIN pf_PrivateMessageUser U 
	ON P.PMID = U.PMID WHERE U.UserID = @UserID 
	AND U.IsArchived = @IsArchived)

SELECT PMID, Subject, LastPostTime, UserNames, LastViewDate
FROM Entries 
WHERE Row between 
@StartRow and @StartRow + @PageSize - 1

SET ROWCOUNT 0";
			var messsages = new List<PrivateMessage>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@StartRow", startRow)
				.AddParameter(_sqlObjectFactory, "@PageSize", pageSize)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.AddParameter(_sqlObjectFactory, "@IsArchived", isArchived)
				.ExecuteReader()
				.ReadAll(r => messsages.Add(new PrivateMessage
				                            	{
				                            		PMID = r.GetInt32(0),
													Subject = r.GetString(1),
													LastPostTime = r.GetDateTime(2),
													UserNames = r.GetString(3),
													LastViewDate = r.GetDateTime(4)
				                            	})));
			return messsages;
		}

		public int GetBoxCount(int userID, PrivateMessageBoxType boxType)
		{
			var isArchived = boxType == PrivateMessageBoxType.Archive;
			var sql = "SELECT COUNT(*) FROM pf_PrivateMessage P JOIN pf_PrivateMessageUser U ON P.PMID = U.PMID WHERE U.UserID = @UserID AND U.IsArchived = @IsArchived";
			var count = 0;
			_sqlObjectFactory.GetConnection().Using(connection =>
				count = Convert.ToInt32(connection.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.AddParameter(_sqlObjectFactory, "@IsArchived", isArchived)
				.ExecuteScalar()));
			return count;
		}

		public int GetUnreadCount(int userID)
		{
			var cacheObject = _cacheHelper.GetCacheObject<int?>(CacheKeys.PMCount(userID));
			if (cacheObject.HasValue)
				return cacheObject.Value;
			var count = 0;
			_sqlObjectFactory.GetConnection().Using(connection => count = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "SELECT COUNT(P.PMID) FROM pf_PrivateMessage P JOIN pf_PrivateMessageUser U ON P.PMID = U.PMID WHERE LastPostTime > LastViewDate AND U.UserID = @UserID AND U.IsArchived = 0")
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.ExecuteScalar()));
			_cacheHelper.SetCacheObject(CacheKeys.PMCount(userID), count);
			return count;
		}

		public void UpdateLastPostTime(int pmID, DateTime lastPostTime)
		{
			_sqlObjectFactory.GetConnection().Using(connection => pmID = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "UPDATE pf_PrivateMessage SET LastPostTime = @LastPostTime WHERE PMID = @PMID")
				.AddParameter(_sqlObjectFactory, "@LastPostTime", lastPostTime)
				.AddParameter(_sqlObjectFactory, "@PMID", pmID)
				.ExecuteNonQuery()));
		}
	}
}
