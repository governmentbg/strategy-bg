﻿using System;
using PopForums.Configuration;
using PopForums.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace PopForums.Email
{
	public interface ISmtpWrapper
	{
		SmtpStatusCode? Send(EmailMessage message);
	}

	public class SmtpWrapper : ISmtpWrapper
	{
		public SmtpWrapper(ISettingsManager settingsManager, IErrorLog errorLog)
		{
			_settingsManager = settingsManager;
			_errorLog = errorLog;
		}

		private readonly ISettingsManager _settingsManager;
		private readonly IErrorLog _errorLog;

		public SmtpStatusCode? Send(EmailMessage message)
		{
			if (message == null)
				throw new ArgumentNullException("message");
			var parsedMessage = ConvertEmailMessage(message);
			var settings = _settingsManager.Current;
			SmtpStatusCode? result = SmtpStatusCode.Ok;
			using (var client = new SmtpClient())
			{

				client.Connect(settings.SmtpServer, settings.SmtpPort, settings.UseSslSmtp ? SecureSocketOptions.StartTls : SecureSocketOptions.None);
				if (settings.UseEsmtp)
					client.Authenticate(settings.SmtpUser, settings.SmtpPassword);
				try
				{
					client.Send(parsedMessage);
				}
				catch (SmtpCommandException exc)
				{
					var statusCode = (int) exc.StatusCode;
					result = (SmtpStatusCode) statusCode;
					_errorLog.Log(exc, ErrorSeverity.Email, String.Format("To: {0}, Subject: {1}", message.ToEmail, message.Subject));
				}
				catch (Exception exc)
				{
					result = null;
					_errorLog.Log(exc, ErrorSeverity.Email, String.Format("To: {0}, Subject: {1}", message.ToEmail, message.Subject));
				}
				finally
				{
					client.Disconnect(true);
				}
			}
			return result;
		}

		private MimeMessage ConvertEmailMessage(EmailMessage forumMessage)
		{
			var message = new MimeMessage();
			message.Headers.Add("X-Mailer", "POP Forums");
			message.To.Add(new MailboxAddress(forumMessage.ToName, forumMessage.ToEmail));
			message.From.Add(new MailboxAddress(forumMessage.FromName, forumMessage.FromEmail));
			message.Subject = forumMessage.Subject;
			var builder = new BodyBuilder();
			builder.TextBody = forumMessage.Body;
			builder.HtmlBody = forumMessage.HtmlBody;
			message.Body = builder.ToMessageBody();
			return message;
		}
	}
}
