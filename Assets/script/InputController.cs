using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	static public Bullet currentBullet;
	// Use this for initialization
	void Start () {
		currentBullet = PlayerInfo.machineGun;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ChangeMachineGun")) {
			BulletGui gui = GameObject.Find ("MachineGui").GetComponent<BulletGui> ();
			gui.setMaster ();
		}
		if (Input.GetButtonDown("ChangeBomb")){
			BulletGui gui = GameObject.Find("BombGui").GetComponent<BulletGui>();
			gui.setMaster();
		}
		if (Input.GetButtonDown("MachineGunUpgrade")){
			if (PlayerInfo.machineGun.level < 9 && PlayerInfo.money >= PlayerInfo.machineGun.cost()) {
				BulletGui gui = GameObject.Find("MachineGui").GetComponent<BulletGui>();
				gui.masterUpgrade();
			}
		}
		if (Input.GetButtonDown("BombUpgrade")) {
			if (PlayerInfo.bomb.level < 9 && PlayerInfo.money >= PlayerInfo.bomb.cost ()) {
					BulletGui gui = GameObject.Find ("BombGui").GetComponent<BulletGui> ();
					gui.masterUpgrade ();
			}
		}
		if (Input.GetButtonDown("Fix")){
			if (PlayerInfo.bomb.level < 9 && PlayerInfo.money >= PlayerInfo.bomb.cost()) {
				HpBar gui = GameObject.Find("HpGui").GetComponent<HpBar>();
				gui.fix();
			}
		}
	}

	public void fire(){
		Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		position.z = -1;
		currentBullet.fire(position);
	}

	void OnMouseDown(){
		fire ();
	}

	void OnMouseDrag(){
		fire ();
	}
}
