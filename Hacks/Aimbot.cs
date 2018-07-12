using UnityEngine;

namespace Hacks {
	class Aimbot {
		public static void Aim() {
			Vector3 pos = GetPosTargetPlayer();
			if (pos == Vector3.zero)
				return;

			Quaternion lookRotation = Quaternion.LookRotation(pos - MainCamera.mainCamera.transform.position, Vector3.right);

			float rotationX = lookRotation.eulerAngles.x;

			rotationX = (MainCamera.mainCamera.transform.position.y < pos.y) ? (-360 + rotationX) : rotationX;
			rotationX = Mathf.Clamp(rotationX, -89f, 89f);

			LocalPlayer.Entity.input.SetViewVars(new Vector3(rotationX, lookRotation.eulerAngles.y, 0));
		}

		private static Vector3 GetPosTargetPlayer() {
			Vector3 targetPlayerPosition = Vector3.zero;
			Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
			float minDist = 999f;

			foreach (BasePlayer player in BasePlayer.VisiblePlayerList) {
				if (player == null || player.IsLocalPlayer() || player.IsSleeping() || player.health <= 0)
					continue;

				Vector3 headPos = ESP.GetPositionBone(player.GetModel(), "headCenter");
				if (headPos == Vector3.zero)
					continue;

				bool isVisible = true;
				if (Settings.toggleVisibleCheck)
					isVisible = ESP.IsVisible(headPos);

				if (!isVisible)
					continue;

				Vector3 pos = ESP.GetScreenPos(headPos);
				if (pos.z <= 0f)
					continue;

				Vector2 screenPos = new Vector2(pos.x, Screen.height - pos.y);

				float distance = Mathf.Abs(Vector2.Distance(centerScreen, screenPos));
				if (distance > Settings.aimbotFov || distance > minDist)
					continue;

				targetPlayerPosition = headPos;
				minDist = distance;

			}

			return targetPlayerPosition;
		}
	}
}