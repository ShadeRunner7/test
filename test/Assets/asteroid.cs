using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {

	Rigidbody2D rb;

	int angle;

	public float size = 1.0f,
				 speed = 1.0f,
				 hp = 1,
				 damage = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		angle = Random.Range (0, 360);
		Destroy (gameObject, 60);
		rb.mass = size * 10;
		damage = rb.mass;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (size, size, size);
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		rb.AddForce (transform.up * speed);	
		if (hp <= 0)
			Destroy (gameObject);
	}

	void takeDamage(int d){
		hp -= d;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.SendMessageUpwards ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			takeDamage (5);
		}
	}

}
