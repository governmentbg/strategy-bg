﻿using System;
using System.Threading;
using PopForums.Configuration;

namespace PopForums.Services
{
	public class UserSessionWorker
	{
		private static readonly object _syncRoot = new Object();

		private UserSessionWorker()
		{
			// only allow Instance to create a new instance
		}

		public void CleanUpExpiredSessions(IUserSessionService sessionService, IErrorLog errorLog)
		{
			if (!Monitor.TryEnter(_syncRoot)) return;
			try
			{
				sessionService.CleanUpExpiredSessions();
			}
			catch (Exception exc)
			{
				errorLog.Log(exc, ErrorSeverity.Error);
			}
			finally
			{
				Monitor.Exit(_syncRoot);
			}
		}

		private static UserSessionWorker _instance;
		public static UserSessionWorker Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new UserSessionWorker();
				}
				return _instance;
			}
		}
	}
}