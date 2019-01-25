﻿namespace PopForums.Configuration
{
    public class ConfigContainer
    {
		public string DatabaseConnectionString { get; set; }
		public int CacheSeconds { get; set; }
		public string CacheConnectionString { get; set; }
		public bool CacheForceLocalOnly { get; set; }
		public string SearchUrl { get; set; }
		public string SearchKey { get; set; }
	}
}
