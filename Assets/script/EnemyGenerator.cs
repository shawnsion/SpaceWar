using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public float spawnInterval;
	public GameObject prefab;
	float counter;
	bool showStage;
	GUIStyle textStyle = new GUIStyle ();
	// Use this for initialization
	void Start () {
		counter = 0;

		textStyle.fontSize = 42;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
		textStyle.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
		spawnInterval = 2.0f - PlayerInfo.timeLevel * 0.2f;
		counter += Time.deltaTime;
		if (!PlayerInfo.takeBreak) {
			if (counter > spawnInterval) {
				Vector2 position2d = new Vector2 (Random.Range (0, Screen.width), Random.Range (0, Screen.height));
				int direction = Random.Range (1, 4);
				if (direction == 1)
					position2d.x = 0;
				if (direction == 2)
					position2d.x = Screen.width;
				if (direction == 3)
					position2d.y = 0;
				if (direction == 4)
					position2d.y = Screen.height;
				Vector3 position = Camera.main.ScreenToWorldPoint (position2d);
				position.z = -1;
				Quaternion prefabRotation = Quaternion.identity;
				prefabRotation.eulerAngles = new Vector3 (-90, 0, 0);
				GameObject obj = Instantiate (prefab, position, prefabRotation) as GameObject;
				obj.GetComponent<BugController> ().setLevel (Random.Range (Mathf.Max (1, PlayerInfo.timeLevel - 2), PlayerInfo.timeLevel + 1));
				counter = 0;
			}
		}
		else{
			if(counter > 5 && counter < 9.5){
				showStage = true;
			}
			else
				showStage = false;
			if(counter > 10){
				PlayerInfo.takeBreak = false;
				counter = 0;
			}
		}
	}

	void OnGUI(){
		if(showStage)
			GUI.Label (new Rect (Screen.width/2 - 150, Screen.height/2 - 30, 300, 60), "STAGE " + PlayerInfo.timeLevel, textStyle);
	}
}
