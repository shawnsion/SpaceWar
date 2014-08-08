using UnityEngine;
using System.Collections;

public class PopupMessage : MonoBehaviour {
	public string message;
	public Vector2 position2d;
	GUIStyle textStyle = new GUIStyle ();
	float time;
	// Use this for initialization
	void Start () {
		textStyle.fontSize = 20;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.yellow;
		textStyle.alignment = TextAnchor.MiddleCenter;

		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		time += Time.deltaTime;
		GUI.Label (new Rect (position2d.x, Mathf.Lerp(position2d.y,position2d.y-20,time), 25, 25), message, textStyle);
	}
}
