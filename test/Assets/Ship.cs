using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public Rigidbody2D rb;
	
	Transform gunLeft,
			  gunRight;

	bool up = false,
	     down = false,
		 right = false,
		 left = false,
		 shootside = false;

	public int speed,
			   hp = 100;

	float timer = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gunLeft = transform.Find ("gunLeft");
		gunRight = transform.Find ("gunRight");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) 
			up = true;
		else up = false;
		if (Input.GetKey (KeyCode.S)) 
			down = true;
		else down = false;
		if (Input.GetKey (KeyCode.A)) 
			left = true;
		else left = false;
		if (Input.GetKey (KeyCode.D)) 
			right = true;
		else right = false;

		if (Input.GetMouseButton (0))
			shoot ();

		if (Input.GetKey (KeyCode.Space))
			spawn ();

		if (hp <= 0)
			Destroy (gameObject);
	}

	float angle;

	// Update when physics are involved
	void FixedUpdate () {

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

		if (up) 
			rb.AddForce(transform.up * speed);
		if (down) 
			rb.AddForce(-transform.up * speed);
		if (left) 
			rb.AddForce(-transform.right * speed);
		if (right) 
			rb.AddForce(transform.right * speed);
	}

	void shoot() {
		if (timer < Time.time) {
			if (shootside) {
				GameObject tmp = Instantiate (Resources.Load ("beam"), gunLeft.position, gunLeft.rotation) as GameObject;
				beam tmp2 = tmp.GetComponent<beam>();
				tmp2.taga = transform.tag;
				tmp2.damage = 10;
				shootside = false;
				timer = Time.time + 0.4f;
			} else {
				GameObject tmp = Instantiate (Resources.Load ("beam"), gunRight.position, gunRight.rotation) as GameObject;
				beam tmp2 = tmp.GetComponent<beam>();
				tmp2.taga = transform.tag;
				tmp2.damage = 10;
				shootside = true;
				timer = Time.time + 0.4f;
			}
		}
	}
	
	public float delay = 1f;
	float time = 0;

	void spawn() {
		if (time < Time.time) {
			GameObject tmp = Instantiate (Resources.Load ("kamikaze"), transform.position, transform.rotation) as GameObject;
			kamikaze tmp2 = tmp.GetComponent<kamikaze> ();
			tmp2.damage = 50;
			tmp2.rs = Random.Range(20,50);
			tmp2.us = Random.Range (60,200);
			tmp2.target = GameObject.FindGameObjectWithTag ("Player");
			time = Time.time + delay;
		}
	}

	void takeDamage(int d){
		Debug.Log (hp);
		hp -= d;
	}
}
