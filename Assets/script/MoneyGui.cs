using UnityEngine;
using System.Collections;

public class MoneyGui : MonoBehaviour {
	public Vector2 size = new Vector2(250,25);
	public Texture2D icon;
	Vector2 pos = new Vector2(20,40);
	GUIStyle textStyle = new GUIStyle();
	GUIStyle boxStyle = new GUIStyle();
	Texture2D emptyTex;
	string labelText;
	// Use this for initialization
	void Start () {
		pos.x = Screen.width - size.x;
		pos.y = size.y;

		textStyle.fontSize = 20;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.yellow;
		textStyle.alignment = TextAnchor.MiddleRight;

		emptyTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
		emptyTex.SetPixel(0, 0, new Color(0.2f,0.2f,0.2f,0.8f));
		emptyTex.Apply();
	}
	
	// Update is called once per frame
	void Update () {
		labelText = "" + PlayerInfo.money;
	}

	void OnGUI() {
		boxStyle.normal.background = emptyTex;
		GUI.Box(new Rect(pos.x - 25,0, size.x + 25, size.y),"",boxStyle);
		GUI.DrawTexture (new Rect (pos.x - 25, 0, 25, 25), icon);
		GUI.Label (new Rect (pos.x, pos.y - size.y, size.x, size.y), labelText, textStyle);
	}
}
