using UnityEngine;
using System.Collections;

public class MenuGui : MonoBehaviour {
	public Vector2 pos = new Vector2(0,0);
	public Vector2 size = new Vector2(190,50);
	// Use this for initialization
	void Start () {
		pos.x = Screen.width/2 - size.x / 2;
		pos.y = Screen.height/2 - size.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = 24;
		buttonStyle.fontStyle = FontStyle.Bold;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (pos.x, pos.y, size.x, size.y),new GUIContent("START","START"),buttonStyle)) {
			audio.Play();
			AutoFade.LoadLevel("MainGame",1,1,Color.black);
		}
		if (GUI.Button (new Rect (pos.x, pos.y + 1.5f * size.y, size.x, size.y),new GUIContent("RANKING","RANKING"),buttonStyle)) {
			audio.Play();
			AutoFade.LoadLevel("ShowScore",1,1,Color.black);
		}
		if (GUI.Button (new Rect (pos.x, pos.y + 3 * size.y, size.x, size.y),new GUIContent("EXIT","EXIT"),buttonStyle)) {
			audio.Play();
			Application.Quit();
		}
	}
}
