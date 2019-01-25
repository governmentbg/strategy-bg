using System;
using Newtonsoft.Json;
using PopForums.Data.Sql;
using PopForums.Email;
using PopForums.Models;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class QueuedEmailMessageRepository : IQueuedEmailMessageRepository
	{
		public QueuedEmailMessageRepository(ISqlObjectFactory sqlObjectFactory)
		{
			_sqlObjectFactory = sqlObjectFactory;
		}

		private readonly ISqlObjectFactory _sqlObjectFactory;

		public void CreateMessage(QueuedEmailMessage message)
		{
			var id = 0;
			_sqlObjectFactory.GetConnection().Using(connection => id = Convert.ToInt32(
				connection.Command(_sqlObjectFactory, "INSERT INTO pf_QueuedEmailMessage (FromEmail, FromName, ToEmail, ToName, Subject, Body, HtmlBody, QueueTime) VALUES (@FromEmail, @FromName, @ToEmail, @ToName, @Subject, @Body, @HtmlBody, @QueueTime)")
					.AddParameter(_sqlObjectFactory, "@FromEmail", message.FromEmail)
					.AddParameter(_sqlObjectFactory, "@FromName", message.FromName)
					.AddParameter(_sqlObjectFactory, "@ToEmail", message.ToEmail)
					.AddParameter(_sqlObjectFactory, "@ToName", message.ToName)
					.AddParameter(_sqlObjectFactory, "@Subject", message.Subject)
					.AddParameter(_sqlObjectFactory, "@Body", message.Body)
					.AddParameter(_sqlObjectFactory, "@HtmlBody", message.HtmlBody.GetObjectOrDbNull())
					.AddParameter(_sqlObjectFactory, "@QueueTime", message.QueueTime)
					.ExecuteAndReturnIdentity()));
			if (id == 0)
				throw new Exception("MessageID was not returned from creation of a QueuedEmailMessage.");
			var payload = new EmailQueuePayload { MessageID = id, EmailQueuePayloadType = EmailQueuePayloadType.FullMessage };
			WriteMessageToEmailQueue(payload);
		}

		protected void WriteMessageToEmailQueue(EmailQueuePayload payload)
		{
			var serializedPayload = JsonConvert.SerializeObject(payload);
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "INSERT INTO pf_EmailQueue (Payload) VALUES (@Payload)")
					.AddParameter(_sqlObjectFactory, "@Payload", serializedPayload)
					.ExecuteNonQuery());
		}

		public void DeleteMessage(int messageID)
		{
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "DELETE FROM pf_QueuedEmailMessage WHERE MessageID = @MessageID")
					.AddParameter(_sqlObjectFactory, "@MessageID", messageID)
					.ExecuteNonQuery());
		}

		protected EmailQueuePayload DequeueEmailQueuePayload()
		{
			var serializedPayload = String.Empty;
			var sql = @"WITH cte AS (
SELECT TOP(1) Payload
FROM pf_EmailQueue WITH (ROWLOCK, READPAST)
ORDER BY Id)
DELETE FROM cte
OUTPUT DELETED.Payload;";
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, sql)
					.ExecuteReader()
					.ReadOne(r => serializedPayload = r.GetString(0)));
			if (String.IsNullOrEmpty(serializedPayload))
				return null;
			var payload = JsonConvert.DeserializeObject<EmailQueuePayload>(serializedPayload);
			return payload;
		}

		public QueuedEmailMessage GetOldestQueuedEmailMessage()
		{
			var payload = DequeueEmailQueuePayload();
			if (payload == null)
				return null;
			if (payload.EmailQueuePayloadType != EmailQueuePayloadType.FullMessage)
				throw new NotImplementedException($"EmailQueuePayloadType {payload.EmailQueuePayloadType} not implemented.");
			QueuedEmailMessage message = null;
			_sqlObjectFactory.GetConnection().Using(connection =>
				connection.Command(_sqlObjectFactory, "SELECT MessageID, FromEmail, FromName, ToEmail, ToName, Subject, Body, HtmlBody, QueueTime FROM pf_QueuedEmailMessage WHERE MessageID = @MessageID")
					.AddParameter(_sqlObjectFactory, "@MessageID", payload.MessageID)
					.ExecuteReader()
					.ReadOne(r => message = new QueuedEmailMessage
												{
													MessageID = r.GetInt32(0),
													FromEmail = r.GetString(1),
													FromName = r.GetString(2),
													ToEmail = r.GetString(3),
													ToName = r.GetString(4),
													Subject = r.GetString(5),
													Body = r.GetString(6),
													HtmlBody = r.NullStringDbHelper(7),
													QueueTime = r.GetDateTime(8)
												}));
			if (message == null)
				throw new Exception($"Queued email with MessageID {payload.MessageID} was not found.");
			return message;
		}
	}
}