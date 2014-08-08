using UnityEngine;
using System.Collections;

public class HpBar : MonoBehaviour {
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(180,25);
	public GameObject popupMessage;
	public Texture2D icon;
	public Texture2D repairIcon;
	public AudioClip sound;
	AudioSource audioSource;
	Texture2D emptyTex;
	Texture2D fullTex;
	float barDisplay;
	int repairPay;
	GUIStyle textStyle = new GUIStyle();
	GUIStyle boxStyle = new GUIStyle();
	// Use this for initialization
	void Start () {
		pos.x = Screen.width - size.x;
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
			fillColorArray[i] = new Color(1,i/1001.0f,i/1001.0f);
		}
		fullTex.SetPixels(fillColorArray);
		fullTex.Apply ();

		textStyle.fontSize = 14;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.red;
		textStyle.normal.background = emptyTex;
		textStyle.alignment = TextAnchor.MiddleCenter;

		repairPay = 1000;
		audioSource = GameObject.Find ("Main Camera").GetComponent<PlayerInfo> ().audio;
	}
	
	// Update is called once per frame
	void Update () {
		barDisplay = PlayerInfo.hp / PlayerInfo.maxHp;
	}

	public void fix(){
		PlayerInfo.hp = PlayerInfo.maxHp;
		audioSource.PlayOneShot(sound);
		GameObject obj = Instantiate (popupMessage, transform.position, Quaternion.identity) as GameObject;
		PopupMessage popup = obj.GetComponent<PopupMessage> ();
		popup.position2d = new Vector2(pos.x,pos.y - 2 * size.y);
		popup.message = "-" + repairPay;
		PlayerInfo.money -= repairPay;
		repairPay *= 2;
	}

	void OnGUI() {
		textStyle.normal.textColor = Color.red;
		textStyle.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (pos.x, pos.y - 20, 80, 20),"REPAIR")) {
			if(PlayerInfo.money > repairPay && PlayerInfo.hp < PlayerInfo.maxHp){
				fix();
			}
		}
		textStyle.normal.textColor = Color.yellow;
		textStyle.alignment = TextAnchor.MiddleRight;
		GUI.Label (new Rect (Screen.width - 100, pos.y - 20, 100, 20), "cost " + repairPay, textStyle);
		GUI.DrawTexture (new Rect (pos.x - 25, pos.y, 25, 25), icon);
		GUI.DrawTexture (new Rect (pos.x - 25, pos.y - 25, 25, 25), repairIcon);

		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		boxStyle.normal.background = emptyTex;
		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		boxStyle.normal.background = fullTex;
		GUI.Box(new Rect(0,0, size.x, size.y),"",boxStyle);
		GUI.EndGroup();
		GUI.EndGroup();
	}
}
