using UnityEngine;
using System.Collections;

public class BulletGui : MonoBehaviour {
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(80,20);
	public Texture2D icon;
	public Bullet master;
	public GameObject popupMessage;
	public AudioClip cockSound;
	public AudioClip upgradeSound;
	AudioSource audioSource;
	Texture2D emptyTex;
	Texture2D fullTex;
	GUIStyle textStyle = new GUIStyle();
	GUIStyle boxStyle = new GUIStyle();
	float barDisplay;
	string labelText;
	// Use this for initialization
	void Start () {
		pos.x = 0 + pos.x;
		pos.y = Screen.height - size.y;

		emptyTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
		Color[] fillColorArray =  emptyTex.GetPixels();
		for(int i = 0; i < fillColorArray.Length; ++i)
		{
			fillColorArray[i] = new Color(0.2f,0.2f,0.2f,0.8f);
		}
		emptyTex.SetPixels(fillColorArray);
		emptyTex.Apply();

		fullTex = new Texture2D(1000, 1, TextureFormat.ARGB32, false);
		fillColorArray =  fullTex.GetPixels();
		for(int i = 0; i < fillColorArray.Length; ++i)
		{
			fillColorArray[i] = new Color(i/1001.0f,0,(1001-i)/1001.0f);
		}
		fullTex.SetPixels(fillColorArray);
		fullTex.Apply ();

		textStyle.fontSize = 20;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
		textStyle.normal.background = emptyTex;
		textStyle.alignment = TextAnchor.MiddleRight;

		boxStyle.fontSize = 20;
		boxStyle.fontStyle = FontStyle.Bold;
		boxStyle.normal.textColor = Color.white;
		boxStyle.alignment = TextAnchor.MiddleCenter;

		audioSource = GameObject.Find ("Main Camera").GetComponent<PlayerInfo> ().audio;
	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = master.reloadTime / master.reload;
		labelText = master.bullet + " / " + master.maxBullet;
	}
	public void masterUpgrade(){
		GameObject obj = Instantiate (popupMessage, transform.position, Quaternion.identity) as GameObject;
		PopupMessage popup = obj.GetComponent<PopupMessage> ();
		popup.position2d = new Vector2 (pos.x + size.x / 2, pos.y - 6 * size.y);
		popup.message = "-" + master.cost();
		PlayerInfo.money -= master.cost ();
		master.upgrade();
		audioSource.PlayOneShot(upgradeSound);
	}
	public void setMaster(){
		audioSource.PlayOneShot(cockSound);
		InputController.currentBullet = master;
	}
	void OnGUI() {
		GUI.DrawTexture (new Rect (pos.x, pos.y - 4 * size.y, size.x, 3 * size.y), icon);
		GUI.Label (new Rect (pos.x, pos.y - size.y, size.x, size.y), labelText,textStyle);
		if(master.particle != InputController.currentBullet.particle)
		if (GUI.Button (new Rect (pos.x, pos.y - 4 * size.y, size.x, 4 * size.y), "")) {
			setMaster();
		}
		if (master.level < 9) {
			if (GUI.Button (new Rect (pos.x, pos.y - 6 * size.y, size.x, size.y * 2), "Level " + (master.level + 1) + "\n" + master.cost())) {
				if(PlayerInfo.money >= master.cost ()){
					masterUpgrade();
				}
			}
		}
		else
			GUI.Button (new Rect (pos.x, pos.y - 6 * size.y, size.x, size.y * 2), "Level \nMAX");

		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		boxStyle.normal.background = emptyTex;
		if(master.bullet == master.maxBullet)
			GUI.Box(new Rect(0,0, size.x, size.y),"MAX",boxStyle);
		else
			GUI.Box(new Rect(0,0, size.x, size.y),"",boxStyle);
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		boxStyle.normal.background = fullTex;
		GUI.Box(new Rect(0,0, size.x, size.y),"",boxStyle);
		GUI.EndGroup();
		GUI.EndGroup();
	}
}
