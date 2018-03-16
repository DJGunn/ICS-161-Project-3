using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanon : MonoBehaviour {
	public GameObject player;
	public int speed= 3;

	public float coolDown;
	public float waiter = 0.3f;
	public Rigidbody2D bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localPosition = player.transform.position - transform.position;
		localPosition = localPosition.normalized; 
		//rotate to point at player
		float angle = Mathf.Atan2(localPosition.y, localPosition.x) * Mathf.Rad2Deg-90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
		if (speed == 1) {
			if (Time.time >= coolDown) {
				Rigidbody2D bulletInstance;
				bulletInstance = Instantiate (bullet, transform.position, Quaternion.identity) as Rigidbody2D;
				bulletInstance.AddForce (transform.up * 500f);
				coolDown = Time.time +waiter;
			}
		}
	}
}
