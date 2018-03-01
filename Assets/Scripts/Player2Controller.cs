using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour {
	public float velocity = 10f;
	public bool ground;
	public float floor = -4.3f;
	public float ceiling = 4.3f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x, transform.position.y);
		if (Input.GetKeyDown(KeyCode.UpArrow)&&ground) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,35), ForceMode2D.Impulse);
			ground = false;
			//transform.Translate (Vector2.up * Time.deltaTime * velocity);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.left * Time.deltaTime * velocity);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * Time.deltaTime * velocity);
		}
		if (transform.position.y < floor) {
			transform.position = new Vector2 (transform.position.x, floor);
		}
		if (transform.position.y > ceiling) {
			transform.position = new Vector2 (transform.position.x, ceiling);
		}
	}
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.CompareTag ("ground")) {
			ground = true;
			//print("I remember touch...");
		}
		if (other.gameObject.CompareTag ("Finish")) {
			SceneManager.LoadScene(3);
		}

	}
}
