using UnityEngine;
using System.Collections;

public class GameOverGui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GUIText gui = GetComponent<GUIText> ();
		gui.pixelOffset = new Vector2 (Screen.width / 2, Screen.height / 2);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
			AutoFade.LoadLevel("Menu",1,1,Color.black);
	}
	
}
