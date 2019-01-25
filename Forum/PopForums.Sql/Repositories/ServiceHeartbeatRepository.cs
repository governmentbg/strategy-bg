﻿using System;
using System.Collections.Generic;
using PopForums.Data.Sql;
using PopForums.Models;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class ServiceHeartbeatRepository : IServiceHeartbeatRepository
	{
		public ServiceHeartbeatRepository(ISqlObjectFactory sqlObjectFactory)
		{
			_sqlObjectFactory = sqlObjectFactory;
		}
		
		private readonly ISqlObjectFactory _sqlObjectFactory;

		public void RecordHeartbeat(string serviceName, string machineName, DateTime lastRun)
		{
			// Not crazy about this lock, but there appear to be multiple instances of this running 
			// when in a web context, causing PK violations when the old record isn't deleted. Of course 
			// this goes away when running in Azure functions on a consumption plan.
			lock (_heartbeatlock)
			{
				_sqlObjectFactory.GetConnection()
					.Using(connection =>
					{
						var command = connection.Command(
								_sqlObjectFactory,
								"DELETE FROM pf_ServiceHeartbeat WHERE ServiceName = @ServiceName AND MachineName = @MachineName")
							.AddParameter(_sqlObjectFactory, "@ServiceName", serviceName)
							.AddParameter(_sqlObjectFactory, "@MachineName", machineName);
						command.ExecuteNonQuery();
						command.CommandText =
							"INSERT INTO pf_ServiceHeartbeat (ServiceName, MachineName, LastRun) VALUES (@ServiceName, @MachineName, @LastRun)";
						command.AddParameter(_sqlObjectFactory, "@LastRun", lastRun);
						command.ExecuteNonQuery();
					});
			}
		}

		private static object _heartbeatlock = new Object();

		public List<ServiceHeartbeat> GetAll()
		{
			var list = new List<ServiceHeartbeat>();
			_sqlObjectFactory.GetConnection()
				.Using(connection => connection.Command(_sqlObjectFactory, "SELECT ServiceName, MachineName, LastRun FROM pf_ServiceHeartbeat ORDER BY ServiceName")
					.ExecuteReader()
					.ReadAll(r => list.Add(new ServiceHeartbeat
					{
						ServiceName = r.GetString(0),
						MachineName = r.GetString(1),
						LastRun = r.GetDateTime(2)
					})));
			return list;
		}

		public void ClearAll()
		{
			_sqlObjectFactory.GetConnection()
				.Using(connection => connection.Command(_sqlObjectFactory, "DELETE FROM pf_ServiceHeartbeat")
					.ExecuteNonQuery());
		}
	}
}