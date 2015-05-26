using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {
	
	public GameObject target;
	
	public int rs,
			   us,
			   damage,
	           TTL = 6;
	
	Rigidbody2D rb;
	
	Vector3 lookat;
	float angle;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
		lookat = -transform.position + target.transform.position;
		angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);	
	}
	
	// Update is called once per frame
	void Update () {
		lookat = -transform.position + target.transform.position;
		angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);			
	}
	
	void FixedUpdate () {
		rb.AddForce (transform.right * rs);
		rb.AddForce (transform.up * us);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "enemy") {
			other.SendMessageUpwards ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
		if (other.tag == "Player") {
			Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		}
	}
}
