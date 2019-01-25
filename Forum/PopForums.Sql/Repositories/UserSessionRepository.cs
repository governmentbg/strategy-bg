﻿using System;
using System.Collections.Generic;
using PopForums.Configuration;
using PopForums.Data.Sql;
using PopForums.Models;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class UserSessionRepository : IUserSessionRepository
	{
		public UserSessionRepository(ICacheHelper cacheHelper, ISqlObjectFactory sqlObjectFactory)
		{
			_cacheHelper = cacheHelper;
			_sqlObjectFactory = sqlObjectFactory;
		}

		private readonly ICacheHelper _cacheHelper;
		private readonly ISqlObjectFactory _sqlObjectFactory;

		public class CacheKeys
		{
			public const string CurrentSessionCount = "PopForums.Session.CurrentCount";
		}

		public void CreateSession(int sessionID, int? userID, DateTime lastTime)
		{
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "INSERT INTO pf_UserSession (SessionID, UserID, LastTime) VALUES (@SessionID, @UserID, @LastTime)")
				.AddParameter(_sqlObjectFactory, "@SessionID", sessionID)
				.AddParameter(_sqlObjectFactory, "@UserID", userID.GetObjectOrDbNull())
				.AddParameter(_sqlObjectFactory, "@LastTime", lastTime)
				.ExecuteNonQuery());
		}

		public bool UpdateSession(int sessionID, DateTime lastTime)
		{
			var result = false;
			_sqlObjectFactory.GetConnection().Using(connection => result = 
				connection.Command(_sqlObjectFactory, "UPDATE pf_UserSession SET LastTime = @LastTime WHERE SessionID = @SessionID")
				.AddParameter(_sqlObjectFactory, "@SessionID", sessionID)
				.AddParameter(_sqlObjectFactory, "@LastTime", lastTime)
				.ExecuteNonQuery() == 1);
			return result;
		}

		public bool IsSessionAnonymous(int sessionID)
		{
			var result = false;
			_sqlObjectFactory.GetConnection().Using(connection => result =
				connection.Command(_sqlObjectFactory, "SELECT UserID FROM pf_UserSession WHERE SessionID = @SessionID AND UserID IS NULL")
				.AddParameter(_sqlObjectFactory, "@SessionID", sessionID)
				.ExecuteReader().Read());
			return result;
		}

		public List<ExpiredUserSession> GetAndDeleteExpiredSessions(DateTime cutOffDate)
		{
			var list = new List<ExpiredUserSession>();
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, "SELECT SessionID, UserID, LastTime FROM pf_UserSession WHERE LastTime < @CutOff")
				.AddParameter(_sqlObjectFactory, "@CutOff", cutOffDate)
				.ExecuteReader()
				.ReadAll(r => list.Add(new ExpiredUserSession
					{
						SessionID = r.GetInt32(0),
						UserID = r.NullIntDbHelper(1),
						LastTime = r.GetDateTime(2)
					})));
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, "DELETE FROM pf_UserSession WHERE LastTime < @CutOff")
				.AddParameter(_sqlObjectFactory, "@CutOff", cutOffDate)
				.ExecuteNonQuery());
			return list;
		}

		public ExpiredUserSession GetSessionIDByUserID(int userID)
		{
			ExpiredUserSession session = null;
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT SessionID, UserID, LastTime FROM pf_UserSession WHERE UserID = @UserID")
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.ExecuteReader()
				.ReadOne(r => session = new ExpiredUserSession { SessionID = r.GetInt32(0), UserID = r.GetInt32(1), LastTime = r.GetDateTime(2)}));
			return session;
		}

		public void DeleteSessions(int? userID, int sessionID)
		{
			if (userID.HasValue)
				_sqlObjectFactory.GetConnection().Using(connection =>
					connection.Command(_sqlObjectFactory, "DELETE FROM pf_UserSession WHERE SessionID = @SessionID OR UserID = @UserID")
					.AddParameter(_sqlObjectFactory, "@SessionID", sessionID)
					.AddParameter(_sqlObjectFactory, "@UserID", userID)
					.ExecuteNonQuery());
			else
				_sqlObjectFactory.GetConnection().Using(connection =>
					connection.Command(_sqlObjectFactory, "DELETE FROM pf_UserSession WHERE SessionID = @SessionID")
					.AddParameter(_sqlObjectFactory, "@SessionID", sessionID)
					.ExecuteNonQuery());
		}

		public int GetTotalSessionCount()
		{
			var cacheObject = _cacheHelper.GetCacheObject<int>(CacheKeys.CurrentSessionCount);
			if (cacheObject != 0)
				return cacheObject;
			var count = 0;
			_sqlObjectFactory.GetConnection().Using(connection => count = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "SELECT COUNT(*) FROM pf_UserSession")
				.ExecuteScalar()));
			_cacheHelper.SetCacheObject(CacheKeys.CurrentSessionCount, count, 60);
			return count;
		}
	}
}
