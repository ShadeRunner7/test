using UnityEngine;
using System.Collections;

public class cBehaviour : MonoBehaviour {
	
	GameObject target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z);
	}
}
