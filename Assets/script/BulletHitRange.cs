using UnityEngine;
using System.Collections;

public class BulletHitRange : MonoBehaviour {
	int combo;
	// Use this for initialization
	void Start () {
		combo = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider col){
		GameObject collider = col.gameObject;
		if(collider.tag == "Enemy"){
			BugController controller = collider.GetComponent<BugController>();
			controller.hit(combo);
			combo *= 2;
		}
	}
}
