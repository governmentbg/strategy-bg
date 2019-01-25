﻿using System;
using System.Collections.Generic;
using System.Reflection;
using PopForums.Repositories;

namespace PopForums.Configuration
{
	public interface ISettingsManager
	{
		Settings Current { get; }
		void SaveCurrent();
		void FlushCurrent();
		void SaveCurrent(Dictionary<string, object> dictionary);
		bool IsLoaded();
	}

	public class SettingsManager : ISettingsManager
	{
		public SettingsManager(ISettingsRepository settingsRepository, IErrorLog errorLog)
		{
			_settingsRepository = settingsRepository;
			_errorLog = errorLog;
		}

		private readonly ISettingsRepository _settingsRepository;
		private readonly IErrorLog _errorLog;
		private static Settings _settings;
		private static DateTime _lastLoad;
		private static readonly object SyncRoot = new object();

		public Settings Current
		{
			get
			{
				if (_settings == null || _settingsRepository.IsStale(_lastLoad))
					LoadSettings();
				return _settings;
			}
		}

		public bool IsLoaded()
		{
			return _settings != null;
		}

		private void LoadSettings()
		{
			var dictionary = _settingsRepository.Get();
			var settings = new Settings();
			foreach (var setting in dictionary.Keys)
			{
				var property = settings.GetType().GetProperty(setting);
				if (property == null)
				{
					_errorLog.Log(null, ErrorSeverity.Warning, String.Format("Settings repository returned a setting called {0}, which does not exist in code.", setting));
				}
				else
				{
					switch (property.PropertyType.FullName)
					{
						case "System.Boolean":
							property.SetValue(settings, Convert.ToBoolean(dictionary[setting]), null);
							break;
						case "System.String":
							property.SetValue(settings, dictionary[setting], null);
							break;
						case "System.Int32":
							property.SetValue(settings, Convert.ToInt32(dictionary[setting]), null);
							break;
						case "System.Double":
							property.SetValue(settings, Convert.ToDouble(dictionary[setting]), null);
							break;
						case "System.DateTime":
							property.SetValue(settings, Convert.ToDateTime(dictionary[setting]), null);
							break;
						default:
							throw new Exception(String.Format("Settings loader not coded to convert values of type {0}.", property.PropertyType.FullName));
					}
				}
			}
			_settings = settings;
			_lastLoad = DateTime.UtcNow;
		}

		public void SaveCurrent(Dictionary<string, object> dictionary)
		{
			LoadSettings();
			foreach (var item in dictionary)
			{
				var property = _settings.GetType().GetProperty(item.Key);
				if (property == null)
					continue;
					//throw new Exception(String.Format("Tried to save a Settings property called \"{0}\", but it doesn't exist.", item.Key));
				var stringValue = Convert.ToString(item.Value);
				switch (property.PropertyType.FullName)
				{
					case "System.Boolean":
						var state = stringValue.Contains("true"); // hack to handle double values in MVC checkbox controls
						property.SetValue(_settings, Convert.ToBoolean(state), null);
						break;
					case "System.String":
						property.SetValue(_settings, stringValue, null);
						break;
					case "System.Int32":
						property.SetValue(_settings, Convert.ToInt32(stringValue), null);
						break;
					case "System.Double":
						property.SetValue(_settings, Convert.ToDouble(stringValue), null);
						break;
					case "System.DateTime":
						property.SetValue(_settings, Convert.ToDateTime(stringValue), null);
						break;
					default:
						throw new Exception(String.Format("Settings save not coded to convert values of type {0}.", property.PropertyType.FullName));
				}
			}
			SaveCurrent();
		}

		public void SaveCurrent()
		{
			var dictionary = new Dictionary<string, object>();
			lock (SyncRoot)
			{
				var properties = Current.GetType().GetProperties();
				foreach (var property in properties)
				{
					dictionary.Add(property.Name, property.GetValue(Current, null));
				}
				_settingsRepository.Save(dictionary);
			}
		}

		public void FlushCurrent()
		{
			_settings = null;
		}
	}
}
