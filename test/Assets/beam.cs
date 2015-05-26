using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {

	Rigidbody2D rb;

	public int speed = 20,
			   damage;

	public string taga;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 6);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("works");
		other.SendMessageUpwards ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		rb.velocity = transform.up * speed;
	}
}
