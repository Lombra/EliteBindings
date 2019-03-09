using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteBindings {
	public class EliteBindingsContext : ApplicationContext {
		NotifyIcon notifyIcon = new NotifyIcon();

		public EliteBindingsContext() {
			MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

			notifyIcon.Text = "ControlScript";
			notifyIcon.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
			notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { exitMenuItem });
			notifyIcon.Visible = true;
		}

		void Exit(object sender, EventArgs e) {
			// We must manually tidy up and remove the icon before we exit.
			// Otherwise it will be left behind until the user mouses over.
			notifyIcon.Visible = false;

			Application.Exit();
		}
	}
}
