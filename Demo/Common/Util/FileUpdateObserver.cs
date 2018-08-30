using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading;

namespace Cp.Common.Util
{
	public class FileUpdateObserver
	{
		static readonly FileUpdateObserver m_instance = new FileUpdateObserver();

		readonly Dictionary<string, ActionInfo> m_actionInfos = new Dictionary<string, ActionInfo>();
		readonly object m_lockObject = new object();

		private FileUpdateObserver()
		{
		}

		public static FileUpdateObserver GetInstance()
		{
			return m_instance;
		}

		public bool Contains(string dirPath, string filePattern)
		{
			var key = CreateKey(dirPath, filePattern);
			lock (m_lockObject)
			{
				return m_actionInfos.ContainsKey(key);
			}
		}

		private string CreateKey(string dirPath, string filePattern)
		{
			return dirPath + filePattern;
		}

		public void AddObservation(string dirPath, string filePattern, params Action[] actions)
		{
			AddObservation(dirPath, filePattern, false, actions);
		}

		public void AddObservationWithSubDir(string dirPath, string filePattern, params Action[] actions)
		{
			AddObservation(dirPath, filePattern, true, actions);
		}

		private void AddObservation(string dirPath, string filePattern, bool includeSubdir, params Action[] actions)
		{
			var key = CreateKey(dirPath, filePattern);
			lock (m_lockObject)
			{
				if (m_actionInfos.ContainsKey(key) == false)
				{
					var fswWatcher = new FileSystemWatcher
					{
						Path = dirPath,
						Filter = filePattern,
						IncludeSubdirectories = includeSubdir,
						NotifyFilter = System.IO.NotifyFilters.LastWrite
					};
					fswWatcher.Changed += ExecMethods;

					m_actionInfos.Add(
						key,
						new ActionInfo(actions, DateTime.MinValue, fswWatcher));

					fswWatcher.EnableRaisingEvents = true;
				}
				else
				{
					foreach (var method in actions.Where(m => (m_actionInfos[key].Actions.Contains(m) == false)))
					{
						m_actionInfos[key].Actions.Add(method);
					}
				}
			}
		}

		private void ExecMethods(object sender, EventArgs e)
		{
			var watcher = ((FileSystemWatcher)sender);
			var key  = watcher.Path + watcher.Filter;

			Thread.Sleep(500);

			lock (m_lockObject)
			{
				if (DateTime.Now > m_actionInfos[key].LastRaised)
				{
					m_actionInfos[key].LastRaised = DateTime.Now;
					foreach (var mMethod in m_actionInfos[key].Actions)
					{
						mMethod.Invoke();
					}
				}
			}
		}

		#region ActionInfo
		private class ActionInfo
		{
			public ActionInfo(IEnumerable<Action> actions, DateTime lastRaised, FileSystemWatcher watcher)
			{
				this.Actions = actions.ToList();
				this.LastRaised = lastRaised;
				this.Watcher = watcher;
			}

			public List<Action> Actions { get; set; }
			public DateTime LastRaised { get; set; }
			private FileSystemWatcher Watcher { get; set; }
		}
		#endregion
	}
}
