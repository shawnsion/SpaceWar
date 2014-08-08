using UnityEngine;
using System.Collections;

public class BombSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BulletGui bulletGui = GetComponent<BulletGui> ();
		bulletGui.master = PlayerInfo.bomb;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
