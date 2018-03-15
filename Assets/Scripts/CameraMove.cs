using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject player;    
	public float floor;
	public float ceiling;

	private Vector3 offset;        

	// Use this for initialization
	void Start () 
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;
		/*if (transform.position.y < floor) {
			transform.position = new Vector2 (transform.position.x, floor);
		}
		if (transform.position.y > ceiling) {
			transform.position = new Vector2 (transform.position.x, ceiling);
		}*/
	}
}
