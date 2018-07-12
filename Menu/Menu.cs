using UnityEngine;

class Menu {
	private static Rect ESPWindowPos = new Rect(50f, 100f, 245f, 180f);
	private static Rect MiscWindowPos = new Rect(310f, 100f, 150f, 205f);
	private static Rect AimbotWindowPos = new Rect(475f, 100f, 150f, 180f);

	public static void Render() {
		ESPWindowPos = GUI.Window(0, ESPWindowPos, new GUI.WindowFunction(WindowESP), "ESP");
		MiscWindowPos = GUI.Window(1, MiscWindowPos, new GUI.WindowFunction(WindowMisc), "Misc");
		AimbotWindowPos = GUI.Window(2, AimbotWindowPos, new GUI.WindowFunction(WindowAimbot), "Aimbot");
	}

	private static void WindowESP(int id) {
		Settings.togglePlayers = GUI.Toggle(new Rect(10f, 25f, 120f, 20f), Settings.togglePlayers, $" Players: {Settings.playersDistance}");
		Settings.playersDistance = (int)GUI.HorizontalSlider(new Rect(135f, 29f, 100f, 12f), Settings.playersDistance, 0f, 1000f);
		Settings.toggleHealth = GUI.Toggle(new Rect(10f, 150f, 130f, 20f), Settings.toggleHealth, " Health Bar");

		Settings.toggleSleepers = GUI.Toggle(new Rect(10f, 50f, 120f, 20f), Settings.toggleSleepers, $" Sleepers: {Settings.sleepersDistance}");
		Settings.sleepersDistance = (int)GUI.HorizontalSlider(new Rect(135f, 54f, 100f, 12f), Settings.sleepersDistance, 0f, 1000f);

		Settings.toggleResources = GUI.Toggle(new Rect(10f, 75f, 120f, 20f), Settings.toggleResources, $" Resources: {Settings.resourcesDistance}");
		Settings.resourcesDistance = (int)GUI.HorizontalSlider(new Rect(135f, 79f, 100f, 12f), Settings.resourcesDistance, 0f, 1000f);

		Settings.toggleAnimals = GUI.Toggle(new Rect(10f, 100f, 120f, 20f), Settings.toggleAnimals, $" Animals: {Settings.animalsDistance}");
		Settings.animalsDistance = (int)GUI.HorizontalSlider(new Rect(135f, 104f, 100f, 12f), Settings.animalsDistance, 0f, 1000f);

		Settings.toggleLoot = GUI.Toggle(new Rect(10f, 125f, 120f, 20f), Settings.toggleLoot, $" Loot: {Settings.lootDistance}");
		Settings.lootDistance = (int)GUI.HorizontalSlider(new Rect(135f, 129f, 100f, 12f), Settings.lootDistance, 0f, 1000f);

		GUI.DragWindow();
	}

	private static void WindowMisc(int id) {
		Settings.toggleCrosshair = GUI.Toggle(new Rect(10f, 25f, 130f, 20f), Settings.toggleCrosshair, " Crosshair");
		Settings.toggleLight = GUI.Toggle(new Rect(10f, 50f, 130f, 20f), Settings.toggleLight, " Light");
		Settings.toggleNoRecoil = GUI.Toggle(new Rect(10f, 75f, 130f, 20f), Settings.toggleNoRecoil, " No Recoil");
		Settings.toggleNoSway = GUI.Toggle(new Rect(10f, 100f, 130f, 20f), Settings.toggleNoSway, " No Sway");
		Settings.toggleNoSpread = GUI.Toggle(new Rect(10f, 125f, 130f, 20f), Settings.toggleNoSpread, " No Spread");
		Settings.toggleAutomatic = GUI.Toggle(new Rect(10f, 150f, 130f, 20f), Settings.toggleAutomatic, " Automatic");
		Settings.toggleNoGrass = GUI.Toggle(new Rect(10f, 175f, 130f, 20f), Settings.toggleNoGrass, " No Grass");

		GUI.DragWindow();
	}

	private static void WindowAimbot(int id) {
		GUI.Label(new Rect(10f, 25f, 130f, 20f), "SuperJump");
		Settings.gravityMultiplier = GUI.HorizontalSlider(new Rect(10f, 54f, 130f, 12f), Settings.gravityMultiplier, 2.5f, 0.2f);

		GUI.Label(new Rect(10f, 75f, 130f, 20f), "SpeedHack");
		Settings.speedScale = GUI.HorizontalSlider(new Rect(10f, 104f, 130f, 12f), Settings.speedScale, 1.002804f, 1.8f);

		Settings.toggleAimbot = GUI.Toggle(new Rect(10f, 125f, 130f, 20f), Settings.toggleAimbot, " Aimbot(X)");

		Settings.toggleVisibleCheck = GUI.Toggle(new Rect(10f, 150f, 130f, 20f), Settings.toggleVisibleCheck, " Visible Check");

		GUI.DragWindow();
	}
}