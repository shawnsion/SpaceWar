using UnityEngine;
using System.Collections;

public class BackgroundAutoResize : MonoBehaviour {
	// Use this for initialization
	void Start () {
		SpriteRenderer	background 	=	GetComponent<SpriteRenderer> ();

		float worldScreenHeight		=	Camera.main.orthographicSize*2f;
		float worldScreenWidth		=	worldScreenHeight/Screen.height*Screen.width;

		float width 				=	background.bounds.size.x;
		float height				=	background.bounds.size.y;

		float scale					=	Mathf.Max (worldScreenWidth / width, worldScreenHeight / height);
		transform.localScale		=	new Vector3(scale, scale,1);

		GameObject.Find("ControlPane").transform.localScale = new Vector3(scale, scale,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
