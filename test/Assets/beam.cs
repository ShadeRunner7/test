using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {

	Rigidbody2D rb;

	public int speed = 20,
			   damage,
			   TTL = 6;

	public string taga;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, TTL);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "enemy") {
			other.SendMessageUpwards ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		rb.velocity = transform.up * speed;
	}
}
