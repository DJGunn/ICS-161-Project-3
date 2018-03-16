using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletpath : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		/*transform.Translate (Vector2. * Time.deltaTime * speed);*/
		if (transform.position.x < -10||transform.position.x>10||transform.position.y<-5||transform.position.y>5) {
			Destroy (gameObject);
		}
	}
}
