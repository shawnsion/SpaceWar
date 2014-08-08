using UnityEngine;
using System.Collections;

public class MachineGunSetting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BulletGui bulletGui = GetComponent<BulletGui> ();
		bulletGui.master = PlayerInfo.machineGun;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
