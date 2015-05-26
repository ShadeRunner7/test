using UnityEngine;
using System.Collections;

public class androidBeam : MonoBehaviour {

	public float AS = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "enemy") {
			Vector3 lookat = -transform.position + other.transform.position;
			float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);	

			shoot ();
		}
	}
	float timer = 0;
	void shoot(){
		if (timer < Time.time) {
			GameObject tmp = Instantiate (Resources.Load ("beam"), transform.position, transform.rotation) as GameObject;
			beam tmp2 = tmp.GetComponent<beam>();
			tmp2.damage = 1;
			tmp2.transform.localScale = new Vector3 (.5f,.5f,1);
			timer = Time.time + AS;
		}
	}
}
