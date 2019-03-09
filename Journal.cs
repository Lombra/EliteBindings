using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EliteBindings {
	class Status {
		public int Flags { set; get; }
	}
	class Journal {
		public int Status;
		string Path = @"D:\Saved games\Frontier Developments\Elite Dangerous\Status.json";

		public Journal() {
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = @"D:\Saved games\Frontier Developments\Elite Dangerous";
			watcher.Filter = "Status.json";
			watcher.NotifyFilter = NotifyFilters.LastWrite;
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.EnableRaisingEvents = true;

			UpdateStatus();
		}

		void OnChanged(object source, FileSystemEventArgs e) {
			UpdateStatus();
		}

		void UpdateStatus() {
			using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
				var sr = new StreamReader(fs);
				var line = sr.ReadToEnd();
				if (line == "") return;
				var j = JsonConvert.DeserializeObject<Status>(line);
				Status = j.Flags;
			}
			Console.WriteLine(Status);
		}
	}
}
