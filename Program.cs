using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlScriptDevice;
using GhostKeyboard;

namespace EliteBindings {
	class Binding {
		public StatusFlag Flag;
		public string Device;
		public string Button;
		public string Key;
	}

	class Program {
		static void Main(string[] args) {
			var j = new Journal();
			var k = new Keyboard();

			var bindings = new List<Binding> {
				new Binding {
					Flag = StatusFlag.LandingGear,
					Device = "DSD Race King",
					Button = "Buttons4",
					Key = "Insert",
				},
				new Binding {
					Flag = StatusFlag.Hardpoints,
					Device = "DSD Race King",
					Button = "Buttons5",
					Key = "U",
				},
				new Binding {
					Flag = StatusFlag.ShipLights,
					Device = "DSD Race King",
					Button = "Buttons6",
					Key = "L",
				},
			};

			var device = new Input("DSD Race King");
			device.ButtonChanged += (e2, a) => {
				var binding = bindings.Find(e => e.Button == a.Button);
				if (binding != null) {
					if (((j.Status & (int)binding.Flag) != 0) != (a.Value != 0)) {
						k.PressKey(binding.Key);
						k.ReleaseKey(binding.Key);
					}
				}
			};

			Application.Run(new EliteBindingsContext());
		}
	}
}
