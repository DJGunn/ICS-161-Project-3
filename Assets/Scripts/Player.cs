﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
	[Range(1, 10)]
	public float jumpVelocity;

	public float speed;
	static public int score;
	private Rigidbody2D myRB;
	private float fallMultiplier, lowJumpMultiplier;


	// Use this for initialization
	void Start () {
		fallMultiplier = 10f;
		lowJumpMultiplier = 15.0f;

		myRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector2 (transform.position.x, transform.position.y);
		/*if (Input.GetKeyDown(KeyCode.W)&&ground) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,40), ForceMode2D.Impulse);
			ground = false;
			//transform.Translate (Vector2.up * Time.deltaTime * velocity);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector2.left * Time.deltaTime * velocity);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * Time.deltaTime * velocity);
		}
		if (transform.position.y < floor) {
			transform.position = new Vector2 (transform.position.x, floor);
		}
		if (transform.position.y > ceiling) {
			transform.position = new Vector2 (transform.position.x, ceiling);
		}*/
		if (Input.GetButtonDown("Jump_P1") &&  Mathf.Abs( myRB.velocity.y ) <= .5f ) { myRB.velocity += Vector2.up * jumpVelocity; }

		if (Input.GetAxisRaw("Horizontal_P1") > 0) { 
			myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up) + Vector2.right * speed * Time.deltaTime; }
		else if (Input.GetAxisRaw("Horizontal_P1") < 0) { 
			myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up) + Vector2.left * speed * Time.deltaTime; }
		else myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up);

		if (myRB.velocity.y < 0) { myRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }
		else if (myRB.velocity.y > 0 && !Input.GetButton("Jump_P1")) { myRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; }

	}
	void OnTriggerEnter2D(Collider2D other){


		if (other.gameObject.CompareTag ("spike")) {
			transform.position = new Vector2 (-7f, 0f);

		}
		if (other.gameObject.CompareTag ("spring")) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,50), ForceMode2D.Impulse);
		}
		if (other.gameObject.CompareTag ("Finish")) {
			Time.timeScale = 0.0f;
			score++;
			if (score >= 2 && SceneManager.GetActiveScene ().buildIndex == 3) {
				SceneManager.LoadScene (4);
			} 
			else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}


		}


	}
}
