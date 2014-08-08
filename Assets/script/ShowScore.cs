using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {
	GUIStyle textStyle = new GUIStyle();
	int bestScore;
	int bestLevel;
	string bestName;
	// Use this for initialization
	void Start () {
		GUIText gui = GetComponent<GUIText> ();
		gui.pixelOffset = new Vector2 (Screen.width / 2, Screen.height);
		
		textStyle.fontSize = 48;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
		textStyle.alignment = TextAnchor.MiddleCenter;

		bestScore = PlayerPrefs.GetInt("BestScore");
		bestLevel= PlayerPrefs.GetInt("BestLevel");
		bestName = PlayerPrefs.GetString("BestPlayer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = 24;
		buttonStyle.fontStyle = FontStyle.Bold;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50), "Score:" + bestScore + "(LEVEL" + bestLevel + ")" , textStyle);
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 30, 200, 50), bestName , textStyle);
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 120, 200, 50),"BACK",buttonStyle)) {
			audio.Play();
			AutoFade.LoadLevel("Menu",1,1,Color.black);
		}
	}
}
