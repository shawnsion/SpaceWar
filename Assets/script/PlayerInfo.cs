using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	public GameObject machineGunPrefab;
	public AudioClip machineGunSound;
	public GameObject bombPrefab;
	public AudioClip bombSound;
	static public Bullet machineGun = new Bullet();
	static public Bullet bomb = new Bullet();
	static public float maxHp;
	static public float hp;
	static public int money;
	static public int timeLevel;
	static public float nextStage;
	static public bool takeBreak;
	float time;
	// Use this for initialization
	void Start () {
		audio.volume = 0.5f;

		machineGun.particle		= machineGunPrefab;
		machineGun.sound 		= machineGunSound;
		machineGun.audioSource 	= audio;
		machineGun.cooldown		= 0.5f;
		machineGun.reload 		= 0.6f;
		machineGun.maxBullet 	= 20;
		machineGun.bullet 		= 0;
		machineGun.level 		= 1;
		//machineGun.setLevel (9);

		bomb.particle		= bombPrefab;
		bomb.sound 			= bombSound;
		bomb.audioSource 	= audio;
		bomb.cooldown		= 4;
		bomb.reload 		= 10;
		bomb.maxBullet 		= 2;
		bomb.bullet 		= 0;
		bomb.level 			= 1;
		//bomb.setLevel (9);

		maxHp = 100;
		hp = maxHp;
		timeLevel = 1;
		nextStage = timeLevel * 20 + 10;
		takeBreak = true;

		money = 0;

		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > nextStage) {
			nextStage = timeLevel * 20 + 10;
			takeBreak = true;
			timeLevel++;
			time = 0;
		}
		machineGun.Update ();
		bomb.Update();
		money += timeLevel;
		if (hp <= 0) {
			int bestScore = PlayerPrefs.GetInt("BestScore");
			int bestLevel = PlayerPrefs.GetInt("BestLevel");
			if(timeLevel > bestLevel){
				PlayerPrefs.SetInt("UserScore",money);
				PlayerPrefs.SetInt("UserLevel",timeLevel);
				AutoFade.LoadLevel ("NewScore", 1, 1, Color.black);
			}
			else{
				if(money > bestScore){
					PlayerPrefs.SetInt("UserScore",money);
					PlayerPrefs.SetInt("UserLevel",timeLevel);
					AutoFade.LoadLevel ("NewScore", 1, 1, Color.black);
				}
				else
					AutoFade.LoadLevel ("GameOver", 1, 1, Color.black);
			}
		}
	}
}
