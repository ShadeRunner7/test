using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {

	Rigidbody2D rb;

	int angle;
	public int hp = 50;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		angle = Random.Range (0, 360);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		rb.AddForce (transform.up);	
		if (hp <= 0)
			Destroy (gameObject);
	}

	void takeDamage(int d){
		Debug.Log (hp);
		hp -= d;
	}
}
