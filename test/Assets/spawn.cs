using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

	public float delay = 1f;
	float time = 0;

	// Use this for initialization
	void Start () {
	
	}

	int bigOne = 0;
	// Update is called once per frame
	void Update () {
		if (time < Time.time) {
			GameObject tmp = Instantiate(Resources.Load("asteroid"),transform.position, transform.rotation) as GameObject;
			asteroid tmp2 = tmp.GetComponent<asteroid>();
			if (Random.Range (bigOne,100) == 100) {
				tmp2.size = 50;
				tmp2.speed = 5;
				tmp2.hp = 10000;
				time = Time.time + delay;
				bigOne = 0;
			} else {
				tmp2.size = Random.Range (1.0f,3.0f);	
				tmp2.speed = Random.Range (5,20);
				tmp2.hp = tmp2.size * 10;
				time = Time.time + delay;
				bigOne++;
			}
		}
	}
}
