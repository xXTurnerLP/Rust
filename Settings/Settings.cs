using UnityEngine;

public class Settings {
	// Colors
	public static Color playersColor = Color.red;
	public static Color playersVisibleColor = Color.yellow;
	public static Color sleepersColor = new Color(.12f, .57f, .88f, 1f);
	public static Color resourcesColor = new Color(.98f, .7f, .13f, 1f);
	public static Color animalsColor = new Color(.13f, .9f, .55f, 1f);
	public static Color lootColor = new Color(.71f, .72f, .99f, 1f);
	public static Color outlineColor = new Color(0f, 0f, 0f, .4f);

	public static bool enableHack = true;
	public static bool showMenu = false;

	public static KeyCode enableHackKey = KeyCode.End;
	public static KeyCode showMenuKey = KeyCode.Delete;
	public static KeyCode aimbotKey = KeyCode.X;
	// ESP
	public static bool togglePlayers = false;
	public static bool toggleSleepers = false;
	public static bool toggleResources = false;
	public static bool toggleAnimals = false;
	public static bool toggleLoot = false;
	public static bool toggleHealth = false;
	public static int playersDistance = 300;
	public static int sleepersDistance = 300;
	public static int resourcesDistance = 300;
	public static int animalsDistance = 300;
	public static int lootDistance = 300;
	// Hacks
	public static bool toggleCrosshair = false;
	public static bool toggleLight = false;
	public static bool toggleNoRecoil = false;
	public static bool toggleNoSway = false;
	public static bool toggleNoSpread = false;
	public static bool toggleAutomatic = false;
	public static bool toggleNoGrass = false;
	// Other
	public static float gravityMultiplier = 2.5f;
	public static float speedScale = Time.timeScale;
	public static bool toggleAimbot = false;
	public static bool toggleVisibleCheck = false;
	public static float aimbotFov = 200f;
}