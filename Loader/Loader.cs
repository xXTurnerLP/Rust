using UnityEngine;

namespace Cheats_Class {
	public class Loader {
		public static void InitCheats() {
			GameObject hackObj = new GameObject();
			hackObj.AddComponent<HackManager>();
			Object.DontDestroyOnLoad(hackObj);
		}
	}
}