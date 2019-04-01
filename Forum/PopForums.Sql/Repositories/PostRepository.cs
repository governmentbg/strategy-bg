﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using PopForums.Configuration;
using PopForums.Data.Sql;
using PopForums.Models;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class PostRepository : IPostRepository
	{
		public PostRepository(ISqlObjectFactory sqlObjectFactory, ICacheHelper cache)
		{
			_sqlObjectFactory = sqlObjectFactory;
			_cache = cache;
		}

		public class CacheKeys
		{
			public const string PostPages = "PopForums.PostPages.{0}";
		}

		private readonly ISqlObjectFactory _sqlObjectFactory;
		private readonly ICacheHelper _cache;
		private const string PostFields = "PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes";

		public virtual int Create(int topicID, int parentPostID, string ip, bool isFirstInTopic, bool showSig, int userID, string name, string title, string fullText, DateTime postTime, bool isEdited, string lastEditName, DateTime? lastEditTime, bool isDeleted, int votes)
		{
			object postID = null;
			_sqlObjectFactory.GetConnection().Using(c => postID = c.Command(_sqlObjectFactory, "INSERT INTO pf_Post (TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes) VALUES (@TopicID, @ParentPostID, @IP, @IsFirstInTopic, @ShowSig, @UserID, @Name, @Title, @FullText, @PostTime, @IsEdited, @LastEditName, @LastEditTime, @IsDeleted, @Votes)")
				.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
				.AddParameter(_sqlObjectFactory, "@ParentPostID", parentPostID)
				.AddParameter(_sqlObjectFactory, "@IP", ip)
				.AddParameter(_sqlObjectFactory, "@IsFirstInTopic", isFirstInTopic)
				.AddParameter(_sqlObjectFactory, "@ShowSig", showSig)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.AddParameter(_sqlObjectFactory, "@Name", name)
				.AddParameter(_sqlObjectFactory, "@Title", title)
				.AddParameter(_sqlObjectFactory, "@FullText", fullText)
				.AddParameter(_sqlObjectFactory, "@PostTime", postTime)
				.AddParameter(_sqlObjectFactory, "@IsEdited", isEdited)
				.AddParameter(_sqlObjectFactory, "@LastEditTime", lastEditTime.GetObjectOrDbNull())
				.AddParameter(_sqlObjectFactory, "@LastEditName", lastEditName)
				.AddParameter(_sqlObjectFactory, "@IsDeleted", isDeleted)
				.AddParameter(_sqlObjectFactory, "@Votes", votes)
				.ExecuteAndReturnIdentity());
			var key = String.Format(CacheKeys.PostPages, topicID);
			_cache.RemoveCacheObject(key);
			return Convert.ToInt32(postID);
		}

		public bool Update(Post post)
		{
			var result = false;
			_sqlObjectFactory.GetConnection().Using(c => result = c.Command(_sqlObjectFactory, "UPDATE pf_Post SET TopicID = @TopicID, ParentPostID = @ParentPostID, IP = @IP, IsFirstInTopic = @IsFirstInTopic, ShowSig = @ShowSig, UserID = @UserID, Name = @Name, Title = @Title, FullText = @FullText, PostTime = @PostTime, IsEdited = @IsEdited, LastEditName = @LastEditName, LastEditTime = @LastEditTime, IsDeleted = @IsDeleted, Votes = @Votes WHERE PostID = @PostID")
				.AddParameter(_sqlObjectFactory, "@TopicID", post.TopicID)
				.AddParameter(_sqlObjectFactory, "@ParentPostID", post.ParentPostID)
				.AddParameter(_sqlObjectFactory, "@IP", post.IP)
				.AddParameter(_sqlObjectFactory, "@IsFirstInTopic", post.IsFirstInTopic)
				.AddParameter(_sqlObjectFactory, "@ShowSig", post.ShowSig)
				.AddParameter(_sqlObjectFactory, "@UserID", post.UserID)
				.AddParameter(_sqlObjectFactory, "@Name", post.Name)
				.AddParameter(_sqlObjectFactory, "@Title", post.Title)
				.AddParameter(_sqlObjectFactory, "@FullText", post.FullText)
				.AddParameter(_sqlObjectFactory, "@PostTime", post.PostTime)
				.AddParameter(_sqlObjectFactory, "@IsEdited", post.IsEdited)
				.AddParameter(_sqlObjectFactory, "@LastEditTime", post.LastEditTime.GetObjectOrDbNull())
				.AddParameter(_sqlObjectFactory, "@LastEditName", post.LastEditName)
				.AddParameter(_sqlObjectFactory, "@IsDeleted", post.IsDeleted)
				.AddParameter(_sqlObjectFactory, "@PostID", post.PostID)
				.AddParameter(_sqlObjectFactory, "@Votes", post.Votes)
				.ExecuteNonQuery() == 1);
			var key = String.Format(CacheKeys.PostPages, post.TopicID);
			_cache.RemoveCacheObject(key);
			return result;
		}

		public List<Post> Get(int topicID, bool includeDeleted, int startRow, int pageSize)
		{
			var key = String.Format(CacheKeys.PostPages, topicID);
			var page = startRow == 1 ? 1 : (startRow - 1) / pageSize + 1;
			if (!includeDeleted)
			{
				// we're only caching paged threads that do not include deleted posts, since only moderators
				// ever see thereads that way, a small percentage of users
				var cachedList = _cache.GetPagedListCacheObject<Post>(key, page);
				if (cachedList != null)
					return cachedList;
			}
			const string sql = @"
DECLARE @Counter int
SET @Counter = (@StartRow + @PageSize - 1)

SET ROWCOUNT @Counter;

WITH Entries AS ( 
SELECT ROW_NUMBER() OVER (ORDER BY PostTime)
AS Row, PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes 
FROM pf_Post WHERE TopicID = @TopicID 
AND ((@IncludeDeleted = 1) OR (@IncludeDeleted = 0 AND IsDeleted = 0)))

SELECT PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes
FROM Entries 
WHERE Row between 
@StartRow and @StartRow + @PageSize - 1

SET ROWCOUNT 0";
			var posts = new List<Post>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
					.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
					.AddParameter(_sqlObjectFactory, "@IncludeDeleted", includeDeleted)
					.AddParameter(_sqlObjectFactory, "@StartRow", startRow)
					.AddParameter(_sqlObjectFactory, "@PageSize", pageSize)
					.ExecuteReader()
					.ReadAll(r => posts.Add(GetPostFromReader(r))));
			if (!includeDeleted)
			{
				_cache.SetPagedListCacheObject(key, page, posts);
			}
			return posts;
		}

		public List<Post> Get(int topicID, bool includeDeleted)
		{
			const string sql = "SELECT PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes FROM pf_Post WHERE TopicID = @TopicID AND ((@IncludeDeleted = 1) OR (@IncludeDeleted = 0 AND IsDeleted = 0)) ORDER BY PostTime";
			var posts = new List<Post>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
					.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
					.AddParameter(_sqlObjectFactory, "@IncludeDeleted", includeDeleted)
					.ExecuteReader()
					.ReadAll(r => posts.Add(GetPostFromReader(r))));
			return posts;
		}

		public List<Post> GetPostWithRepies(int postID, bool includeDeleted)
		{
			const string sql = "SELECT PostID, TopicID, ParentPostID, IP, IsFirstInTopic, ShowSig, UserID, Name, Title, FullText, PostTime, IsEdited, LastEditName, LastEditTime, IsDeleted, Votes FROM pf_Post WHERE (PostID = @PostID OR ParentPostID = @PostID) AND ((@IncludeDeleted = 1) OR (@IncludeDeleted = 0 AND IsDeleted = 0)) ORDER BY PostTime";
			var posts = new List<Post>();
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
					.AddParameter(_sqlObjectFactory, "@PostID", postID)
					.AddParameter(_sqlObjectFactory, "@IncludeDeleted", includeDeleted)
					.ExecuteReader()
					.ReadAll(r => posts.Add(GetPostFromReader(r))));
			return posts;
		}

		public Post GetFirstInTopic(int topicID)
		{
			Post post = null;
			_sqlObjectFactory.GetConnection().Using(connection =>
				//connection.Command(_sqlObjectFactory, "SELECT " + PostFields + " FROM pf_Post WHERE TopicID = @TopicID AND IsFirstInTopic = 1")

         connection.Command(_sqlObjectFactory, "SELECT TOP(1)" + PostFields + " FROM pf_Post WHERE TopicID = @TopicID ORDER BY PostID ASC")
          .AddParameter(_sqlObjectFactory, "@TopicID", topicID)
					.ExecuteReader()
					.ReadOne(r => post = GetPostFromReader(r)));
			return post;
		}

		public Post GetLastInTopic(int topicID)
		{
			Post post = null;
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT TOP 1 " + PostFields + " FROM pf_Post WHERE TopicID = @TopicID AND IsDeleted = 0 ORDER BY PostTime DESC")
					.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
					.ExecuteReader()
					.ReadOne(r => post = GetPostFromReader(r)));
			return post;
		}

		public int GetReplyCount(int topicID, bool includeDeleted)
		{
			var sql = "SELECT COUNT(*) FROM pf_Post WHERE TopicID = @TopicID";
			if (!includeDeleted)
				sql += " AND IsDeleted = 0 AND IsFirstInTopic = 0";
			var replyCount = 0;
			_sqlObjectFactory.GetConnection().Using(c =>
				replyCount = Convert.ToInt32(c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
				.ExecuteScalar()));
			return replyCount;
		}

		public Post Get(int postID)
		{
			Post post = null;
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, "SELECT " + PostFields + " FROM pf_Post WHERE PostID = @PostID")
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.ExecuteReader()
				.ReadOne(r => post = GetPostFromReader(r)));
			return post;
		}

		public Dictionary<int, DateTime> GetPostIDsWithTimes(int topicID, bool includeDeleted)
		{
			var dictionary = new Dictionary<int, DateTime>();
			var sql = "SELECT PostID, PostTime FROM pf_Post WHERE TopicID = @TopicID";
			if (!includeDeleted)
				sql += " AND IsDeleted = 0";
			sql += " ORDER BY PostTime";
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
				.ExecuteReader()
				.ReadAll(r => dictionary.Add(r.GetInt32(0), r.GetDateTime(1))));
			return dictionary;
		}

		public int GetPostCount(int userID)
		{
			var postCount = 0;
			_sqlObjectFactory.GetConnection().Using(c =>
				postCount = Convert.ToInt32(c.Command(_sqlObjectFactory, "SELECT COUNT(PostID) FROM pf_Post JOIN pf_Topic ON pf_Post.TopicID = pf_Topic.TopicID WHERE pf_Post.UserID = @UserID AND pf_Post.IsDeleted = 0 AND pf_Topic.IsDeleted = 0")
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.ExecuteScalar()));
			return postCount;
		}

		public List<IPHistoryEvent> GetIPHistory(string ip, DateTime start, DateTime end)
		{
      var list = new List<IPHistoryEvent>();
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, "SELECT PostID, PostTime, UserID, Name, Title FROM pf_Post WHERE IP = @IP")
				.AddParameter(_sqlObjectFactory, "@IP", ip)
				.ExecuteReader()
				.ReadAll(r => list.Add(new IPHistoryEvent
				                       	{
				                       		ID = r.GetInt32(0),
											EventTime = r.GetDateTime(1),
											UserID = r.GetInt32(2),
											Name = r.GetString(3),
											Description = r.GetString(4),
											Type = typeof(Post)
				                       	})));
			return list;
		}

		public Dictionary<int, int> GetFirstPostIDsFromTopicIDs(List<int> topicIDs)
		{
			var ids = String.Join(",", topicIDs);
			var sql = "SELECT TopicID, PostID FROM pf_Post WHERE IsFirstInTopic = 1 AND TopicID IN (" + ids + ")";
			var dictionary = new Dictionary<int, int>();
			_sqlObjectFactory.GetConnection().Using(c =>
			    c.Command(_sqlObjectFactory, sql)
			    .ExecuteReader()
			    .ReadAll(r => dictionary.Add(r.GetInt32(0), r.GetInt32(1))));
			return dictionary;
		}

		public int GetLastPostID(int topicID)
		{
			const string sql = "SELECT PostID FROM pf_Post WHERE TopicID = @TopicID AND IsDeleted = 0 ORDER BY PostTime DESC";
			var id = 0;
			_sqlObjectFactory.GetConnection().Using(c => id = Convert.ToInt32(
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@TopicID", topicID)
				.ExecuteScalar()));
			return id;
		}

		public int GetVoteCount(int postID)
		{
			const string sql = "SELECT Votes FROM pf_Post WHERE PostID = @PostID";
			var votes = 0;
			_sqlObjectFactory.GetConnection().Using(c => votes = Convert.ToInt32(
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.ExecuteScalar()));
			return votes;
		}

		public int CalculateVoteCount(int postID)
		{
			const string sql = "SELECT COUNT(*) FROM pf_PostVote WHERE PostID = @PostID";
			var count = 0;
			_sqlObjectFactory.GetConnection().Using(c => count = Convert.ToInt32(
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.ExecuteScalar()));
			return count;
		}

		public void SetVoteCount(int postID, int votes)
		{
			const string sql = "UPDATE pf_Post SET Votes = @Votes WHERE PostID = @PostID";
			_sqlObjectFactory.GetConnection().Using(c => 
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@Votes", votes)
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.ExecuteNonQuery());
		}

		public void VotePost(int postID, int userID)
		{
			const string sql = "INSERT INTO pf_PostVote (PostID, UserID) VALUES (@PostID, @UserID)";
			_sqlObjectFactory.GetConnection().Using(c => 
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.AddParameter(_sqlObjectFactory, "@UserID", userID)
				.ExecuteNonQuery());
		}

		public Dictionary<int, string> GetVotes(int postID)
		{
			var results = new Dictionary<int, string>();
			const string sql = "SELECT V.UserID, U.Name FROM pf_PostVote V LEFT JOIN pf_PopForumsUser U ON V.UserID = U.UserID WHERE V.PostID = @PostID";
			_sqlObjectFactory.GetConnection().Using(c =>
				c.Command(_sqlObjectFactory, sql)
				.AddParameter(_sqlObjectFactory, "@PostID", postID)
				.ExecuteReader()
				.ReadAll(r => results.Add(r.GetInt32(0), r.NullStringDbHelper(1))));
			return results;
		}

		public List<int> GetVotedPostIDs(int userID, List<int> postIDs)
		{
			var list = new List<int>();
			if (postIDs.Count == 0)
				return list;
			var inList = postIDs.Aggregate(String.Empty, (current, postID) => current + ("," + postID));
			if (inList.StartsWith(","))
				inList = inList.Remove(0, 1);
			var sql = String.Format("SELECT PostID FROM pf_PostVote WHERE PostID IN ({0}) AND UserID = @UserID", inList);
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
					.AddParameter(_sqlObjectFactory, "@UserID", userID)
					.ExecuteReader()
					.ReadAll(r => list.Add(r.GetInt32(0))));
			return list;
		}

		private static Post GetPostFromReader(DbDataReader r)
		{
			return new Post(r.GetInt32(0))
			       	{
			       		TopicID = r.GetInt32(1),
						ParentPostID = r.GetInt32(2),
						IP = r.GetString(3),
						IsFirstInTopic = r.GetBoolean(4),
						ShowSig = r.GetBoolean(5),
						UserID = r.GetInt32(6),
						Name = r.GetString(7),
						Title = r.GetString(8),
						FullText = r.GetString(9),
						PostTime = r.GetDateTime(10),
						IsEdited = r.GetBoolean(11),
						LastEditName = r.GetString(12),
						LastEditTime = r.NullDateTimeDbHelper(13),
						IsDeleted = r.GetBoolean(14),
						Votes = r.GetInt32(15)
			       	};
		}
	}
}
