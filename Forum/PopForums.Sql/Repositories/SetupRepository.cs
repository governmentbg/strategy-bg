﻿using System;
using System.IO;
using System.Reflection;
using PopForums.Data.Sql;
using PopForums.Repositories;

namespace PopForums.Sql.Repositories
{
	public class SetupRepository : ISetupRepository
	{
		public SetupRepository(ISqlObjectFactory sqlObjectFactory)
		{
			_sqlObjectFactory = sqlObjectFactory;
		}

		protected readonly ISqlObjectFactory _sqlObjectFactory;

		public bool IsConnectionPossible()
		{
			try
			{
				var connection = _sqlObjectFactory.GetConnection();
				connection.Open();
				connection.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public virtual bool IsDatabaseSetup()
		{
			const string sql = @"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'pf_PopForumsUser'))
BEGIN
    SELECT 0
END
ELSE
BEGIN
	SELECT 1
END";
			var result = false;
			_sqlObjectFactory.GetConnection().Using(c => result = Convert.ToBoolean(c.Command(_sqlObjectFactory, sql).ExecuteScalar()));
			return result;
		}

		public void SetupDatabase()
		{
			var assembly = typeof(SetupRepository).GetTypeInfo().Assembly;
			var stream = assembly.GetManifestResourceStream("PopForums.Sql.PopForums.sql");
			var reader = new StreamReader(stream);
			var sql = reader.ReadToEnd();
			_sqlObjectFactory.GetConnection().Using(c => c.Command(_sqlObjectFactory, sql).ExecuteNonQuery());
		}
	}
}
