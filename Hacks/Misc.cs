using UnityEngine;

namespace Hacks {
	class Misc {
		public static BaseProjectile[] projectiles;
		public static PlayerWalkMovement movement;

		public static void Crosshair() {
			Render.Crosshair(Screen.width / 2f, Screen.height / 2f, 11f, Color.red);
		}

		public static void DebugCamera() {
			if (LocalPlayer.Entity == null)
				return;

			if (SingletonComponent<CameraMan>.Instance == null)
				GameManager.client.CreatePrefab("assets/bundled/prefabs/system/debug/debug_camera.prefab", new Vector3(), new Quaternion(), true);
			else
				SingletonComponent<CameraMan>.Instance.enabled = !SingletonComponent<CameraMan>.Instance.enabled;

			LocalPlayer.Entity.OnViewModeChanged();
		}

		public static void ProjectileHacks() {
			foreach (BaseProjectile projectile in projectiles) {
				if (projectile == null)
					continue;

				if (Settings.toggleAutomatic)
					projectile.automatic = true;

				if (Settings.toggleNoSpread)
					projectile.recoil.ADSScale = 0f;

				if (Settings.toggleNoRecoil) {
					projectile.recoil.recoilYawMin = 0f;
					projectile.recoil.recoilYawMax = 0f;
					projectile.recoil.recoilPitchMin = 0f;
					projectile.recoil.recoilPitchMax = 0f;
					projectile.recoil.timeToTakeMin = 0f;
					projectile.recoil.timeToTakeMax = 0f;
				}

				if (Settings.toggleNoSway) {
					projectile.aimSway = 0f;
					projectile.aimSwaySpeed = 0f;
					projectile.aimCone = 0f;
					projectile.hipAimCone = 0f;
				}

			}
		}

		public static void SuperJump() {
			if (movement != null)
				movement.gravityMultiplier = Settings.gravityMultiplier;
		}

		public static void SpeedHack() =>
			Time.timeScale = Settings.speedScale;

		public static void NoGrass() =>
			GrassSpawn.RemoveAll(false);

		public static void LightHack() =>
			TOD_Sky.Instance.Cycle.Hour = 12f;

	}
}