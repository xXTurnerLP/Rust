using System.Collections;
using UnityEngine;
using Hacks;

public class HackManager : MonoBehaviour {
	private float deltaTime;

	private void Start() {
		StartCoroutine(_Update());
	}

	private void Update() {
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

		if (Input.GetKeyDown(Settings.enableHackKey))
			Settings.enableHack = !Settings.enableHack;

		if (Input.GetKeyDown(Settings.showMenuKey))
			Settings.showMenu = !Settings.showMenu;

		if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.P))
			Misc.DebugCamera();

		if (Settings.toggleLight && LocalPlayer.Entity != null)
			Misc.LightHack();

		ClearBinds();
	}

	private IEnumerator _Update() {
		while (true) {
			yield return new WaitForSeconds(5f);

			try {
				if (!Settings.enableHack || LocalPlayer.Entity == null)
					continue;

				if (Misc.movement == null)
					Misc.movement = FindObjectOfType<PlayerWalkMovement>();

				if (Settings.toggleResources)
					ESP.resources = FindObjectsOfType<BaseResource>();

				if (Settings.toggleAnimals)
					ESP.animals = FindObjectsOfType<BaseNpc>();

				if (Settings.toggleLoot)
					ESP.loot = FindObjectsOfType<StorageContainer>();

				if (Settings.toggleNoRecoil || Settings.toggleNoSway || Settings.toggleNoSpread || Settings.toggleAutomatic) {
					Misc.projectiles = FindObjectsOfType<BaseProjectile>();
					Misc.ProjectileHacks();
				}

				if (Settings.toggleNoGrass)
					Misc.NoGrass();

			} catch {
				Debug.LogError("Error_1");
			}
		}
	}

	private void OnGUI() {
		try {
			if (!Settings.enableHack)
				return;

			RenderDebug();

			if (Settings.showMenu)
				Menu.Render();

			if (LocalPlayer.Entity == null)
				return;

			Misc.SuperJump();

			Misc.SpeedHack();

			if (Settings.toggleAimbot && Input.GetKey(Settings.aimbotKey))
				Aimbot.Aim();

			if (Settings.togglePlayers || Settings.toggleSleepers)
				ESP.Players();

			if (Settings.toggleResources)
				ESP.Resources();

			if (Settings.toggleAnimals)
				ESP.Animals();

			if (Settings.toggleLoot)
				ESP.Loot();

			if (Settings.toggleCrosshair)
				Misc.Crosshair();

		} catch {
			Debug.LogError("Error_2");
		}
	}

	private void ClearBinds() {
		Facepunch.Input.SetBind(Settings.enableHackKey.ToString(), null);
		Facepunch.Input.SetBind(Settings.showMenuKey.ToString(), null);
		Facepunch.Input.SetBind(Settings.aimbotKey.ToString(), null);
	}

	private void RenderDebug() =>
		Render.String(5f, 0f, $"FPS: {(int)(1f / deltaTime)} / {(1000f / (1f / deltaTime)).ToString("0.0")} ms", Color.white, true, false);
}