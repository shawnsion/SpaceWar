using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject particle;
	public AudioSource audioSource;
	public AudioClip sound;
	public float cooldown;
	public float reload;
	public int maxBullet;
	public int bullet;
	public float reloadTime;
	public int level;
	float cooldownTime;
	bool ready;

	// Use this for initialization
	void Start () {
		cooldownTime	= 0;
		reloadTime 	= 0;
		ready = false;
	}
	
	// Update is called once per frame
	public void Update () {
		float deltaTime = Time.deltaTime;
		if (bullet != maxBullet){
			reloadTime += deltaTime;
			if (reloadTime >= reload) {
				bullet += 1;
				reloadTime = 0;
			}
		}
		if (ready) {
			cooldownTime = 0;
			ready = true;
		}
		else {
			cooldownTime += deltaTime;
			if (cooldownTime >= cooldown) {
				ready = true;
				cooldownTime = 0;
			}
		}
	}

	public void fire(Vector3 position){
		if (ready && bullet > 0) {
			ready = false;
			bullet -= 1;
			Instantiate (particle, position, Quaternion.identity);
			audioSource.PlayOneShot (sound);
		}
	}

	public void upgrade(){
		cooldown	= Mathf.Round(cooldown * 8) / 10;
		reload		= Mathf.Round(reload * 9) / 10;
		if(level % 3 == 0)
			maxBullet	= Mathf.FloorToInt(maxBullet * 1.5f);
		level += 1;
	}

	public void setLevel(int lv){
		int times = lv - level;
		for (int i = 0; i < times; i++)
			upgrade ();
	}

	public int cost(){
		return level * (level + 1) * 200;
	}
	
}
