using UnityEngine;

public class Render {
	private static Color textureColor;
	private static Texture2D texture = new Texture2D(1, 1);
	private static GUIStyle style = new GUIStyle(GUI.skin.label) { fontSize = 12 };

	public static void RectFilled(float x, float y, float width, float height, Color color) {
		if (color != textureColor) {
			textureColor = color;
			texture.SetPixel(0, 0, color);
			texture.Apply();
		}

		GUI.DrawTexture(new Rect(x, y, width, height), texture);
	}

	public static void RectOutlined(float x, float y, float width, float height, Color color, float thickness = 1f) {
		RectFilled(x, y, thickness, height, color);
		RectFilled(x + width - thickness, y, thickness, height, color);
		RectFilled(x + thickness, y, width - thickness * 2f, thickness, color);
		RectFilled(x + thickness, y + height - thickness, width - thickness * 2f, thickness, color);
	}

	public static void String(float x, float y, string text, Color color, bool outline = true, bool center = true) {
		GUIContent content = new GUIContent(text);

		if (center)
			x -= style.CalcSize(content).x / 2f;

		if (outline) {
			style.normal.textColor = Settings.outlineColor;

			GUI.Label(new Rect(x - 1f, y, 300f, 25f), content, style);
			GUI.Label(new Rect(x + 1f, y, 300f, 25f), content, style);
			GUI.Label(new Rect(x, y + 1f, 300f, 25f), content, style);
			GUI.Label(new Rect(x, y - 1f, 300f, 25f), content, style);
		}

		style.normal.textColor = color;

		GUI.Label(new Rect(x, y, 300f, 25f), content, style);
	}

	public static void Crosshair(float x, float y, float size, Color color, float thickness = 1f) {
		RectFilled(x - thickness / 2f, y - size / 2f, thickness, size, color);
		RectFilled(x - size / 2f, y - thickness / 2f, size, thickness, color);
	}

	public static void Health(float x, float y, float health, float maxHealth = 100f, float width = 50f, float height = 5f, float thickness = 1f) {
		float healthWidth = ((width - thickness * 2f) * health) / maxHealth;

		if (healthWidth < 1f)
			healthWidth = 1f;

		Color color = Color.green;

		if (health < maxHealth * .6f)
			color = Color.yellow;
		if (health < maxHealth * .3f)
			color = Color.red;

		RectFilled(x - width / 2f, y - height, width, height, Color.black);

		RectFilled(x - width / 2f + thickness, y - height + thickness, healthWidth, height - thickness * 2f, color);
	}

	public static void Box(float x, float y, float width, float height, Color color, float thickness = 1f) {
		RectOutlined(x - width / 2f, y - height, width, height, color, thickness);
	}
}