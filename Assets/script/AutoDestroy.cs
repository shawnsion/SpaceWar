using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	public float lifeTime = 0.0f;
	float time;
	// Use this for initialization
	void Start () {
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > lifeTime)
			Destroy (transform.gameObject);
	}
}
