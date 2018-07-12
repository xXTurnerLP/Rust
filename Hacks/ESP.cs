using UnityEngine;

namespace Hacks {
	class ESP {
		public static BaseNpc[] animals;
		public static BaseResource[] resources;
		public static StorageContainer[] loot;

		public static void Players() {
			foreach (BasePlayer player in BasePlayer.VisiblePlayerList) {
				if (player == null || player.IsLocalPlayer() || player.health <= 0)
					continue;

				if (player.IsSleeping() && !Settings.toggleSleepers)
					continue;

				int distance = GetDistance(player.transform.position);
				if ((!player.IsSleeping() && distance > Settings.playersDistance) || (player.IsSleeping() && distance > Settings.sleepersDistance))
					continue;

				Vector3 pos = GetScreenPos(player.transform.position);
				if (pos.z <= 0f)
					continue;

				Color color = Settings.sleepersColor;

				if (!player.IsSleeping()) {
					color = Settings.playersColor;

					Vector3 head = GetPositionBone(player.GetModel(), "headCenter");
					if (head == Vector3.zero)
						continue;

					if (Settings.toggleVisibleCheck && IsVisible(head))
						color = Settings.playersVisibleColor;

					Vector3 headPos = GetScreenPos(head + new Vector3(0f, .3f, 0f));

					float height = Mathf.Abs((pos.y - headPos.y));
					Render.Box(pos.x, Screen.height - pos.y, height / 2f, height, color);

					if (Settings.toggleHealth)
						Render.Health(headPos.x, Screen.height - headPos.y - 4f, player.health);
				}

				Render.String(pos.x, Screen.height - pos.y, $"{player.displayName}[{distance}m] HP: {(int)player.health}", color);
			}
		}

		public static void Animals() {
			if (animals == null)
				return;

			foreach (BaseNpc animal in animals) {
				if (animal == null)
					continue;

				int distance = GetDistance(animal.transform.position);
				if (distance > Settings.animalsDistance)
					continue;

				Vector3 pos = GetScreenPos(animal.transform.position);
				if (pos.z <= 0f)
					continue;

				Render.String(pos.x + 3f, Screen.height - (pos.y + 1f), $"{animal.ShortPrefabName}[{distance}m]", Settings.animalsColor);
			}
		}

		public static void Resources() {
			if (resources == null)
				return;

			foreach (BaseResource resource in resources) {
				if (resource == null)
					continue;

				int distance = GetDistance(resource.transform.position);
				if (distance > Settings.resourcesDistance)
					continue;

				Vector3 pos = GetScreenPos(resource.transform.position);
				if (pos.z <= 0f)
					continue;

				Render.String(pos.x + 3f, Screen.height - (pos.y + 1f), $"{resource.ShortPrefabName}[{distance}m]", Settings.resourcesColor);
			}
		}

		public static void Loot() {
			if (loot == null)
				return;

			foreach (StorageContainer _loot in loot) {
				if (_loot == null)
					continue;

				int distance = GetDistance(_loot.transform.position);
				if (distance > Settings.lootDistance)
					continue;

				Vector3 pos = GetScreenPos(_loot.transform.position);
				if (pos.z <= 0f)
					continue;

				Render.String(pos.x + 3f, Screen.height - (pos.y + 1f), $"{_loot.ShortPrefabName.Replace("_deployed", "")}[{distance}m]", Settings.lootColor);
			}
		}

		public static Vector3 GetPositionBone(Model model, string name) {
			Vector3 position = Vector3.zero;

			if (model != null) {
				if (name == "headCenter")
					position = new Vector3(model.headBone.position.x, model.eyeBone.position.y, model.headBone.position.z);
				else
					position = model.FindBone(name).position;
			}

			return position;
		}

		public static bool IsVisible(Vector3 position) =>
			LocalPlayer.Entity.IsVisible(position, MainCamera.mainCamera.transform.position);

		public static Vector3 GetScreenPos(Vector3 position) =>
			MainCamera.mainCamera.WorldToScreenPoint(position);

		private static int GetDistance(Vector3 position) =>
			(int)Vector3.Distance(LocalPlayer.Entity.transform.position, position);

	}
}