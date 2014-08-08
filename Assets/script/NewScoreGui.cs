using UnityEngine;
using System.Collections;

public class NewScoreGui : MonoBehaviour {
	GUIStyle textStyle = new GUIStyle();
	Texture2D emptyTex;
	string input;
	int score;
	int level;
	// Use this for initialization
	void Start () {
		GUIText gui = GetComponent<GUIText> ();
		gui.pixelOffset = new Vector2 (Screen.width / 2, Screen.height);

		emptyTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
		emptyTex.SetPixel(0, 0, new Color(0.2f,0.2f,0.2f,0.8f));
		emptyTex.Apply();

		textStyle.fontSize = 48;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
		textStyle.normal.background = emptyTex;
		textStyle.alignment = TextAnchor.MiddleCenter;

		score = PlayerPrefs.GetInt("UserScore");
		level = PlayerPrefs.GetInt("UserLevel");
		input = "";
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		textStyle.normal.background = null;
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 20, 200, 50), "Enter Your Name", textStyle);
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 40, 200, 50), "Your Score:" + score + "(LEVEL" + level + ")", textStyle);
		textStyle.normal.background = emptyTex;
		input = GUI.TextArea (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 80, 300, 50), input, 8,textStyle);
		if (Event.current.keyCode == KeyCode.Return || Input.GetKey (KeyCode.KeypadEnter)) {
			PlayerPrefs.SetInt("BestScore",score);
			PlayerPrefs.SetInt("BestLevel",level);
			PlayerPrefs.SetString("BestPlayer",input);
			AutoFade.LoadLevel ("Menu", 1, 1, Color.black);
		}
	}
}
