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

	public int speed;

	double timer = 0;

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
	}

	// Update when physics are involved
	void FixedUpdate () {

		Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 lookat = transform.position - mouse;
		float angle = Mathf.Atan2 (lookat.y, lookat.x) * Mathf.Rad2Deg + 90;
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
				shootside = false;
				timer = Time.time + 0.4;
			} else {
				GameObject tmp = Instantiate (Resources.Load ("beam"), gunRight.position, gunRight.rotation) as GameObject;
				beam tmp2 = tmp.GetComponent<beam>();
				tmp2.taga = transform.tag;
				shootside = true;
				timer = Time.time + 0.4;
			}
		}
	}
}
