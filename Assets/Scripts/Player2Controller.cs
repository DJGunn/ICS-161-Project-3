using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour {

	[Range(1, 10)]
	public float jumpVelocity;

	public float speed;
	public bool winGame;
	public bool isPlayer2;

	private Text scoreText, finalScoreText;
	private GameObject backgroundLose, backgroundWin;
	private Rigidbody2D myRB;

	private int score;
	private float fallMultiplier, lowJumpMultiplier;
	private bool isGamePaused, isGameOver;

	// Use this for initialization
	void Start () {
		score = 0;

		isGameOver = isGamePaused = false; //game is not over or paused by default

		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		backgroundLose = GameObject.Find("BackgroundLose");
		backgroundWin = GameObject.Find("BackgroundWin");

		updateGameText();

		backgroundLose.SetActive(false);
		backgroundWin.SetActive(false);

		winGame = false;

		fallMultiplier = 2.5f;
		lowJumpMultiplier = 3.0f;

		myRB = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

	}

	//occurs every frame
	void Update()
	{
		if (Input.GetButtonDown("pauseButton"))
			isGamePaused = togglePause();

		if (!isGameOver && !isGamePaused) //only update the game logic if the game isn't over or isn't paused
		{

			updateGameText();

			if (Input.GetButtonDown("Jump_P2") &&  Mathf.Abs( myRB.velocity.y ) <= .5f ) { myRB.velocity += Vector2.up * jumpVelocity; }

			if (Input.GetAxisRaw("Horizontal_P2") > 0) { myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up) + Vector2.right * speed * Time.deltaTime; }
			else if (Input.GetAxisRaw("Horizontal_P2") < 0) { myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up) + Vector2.left * speed * Time.deltaTime; }
			else myRB.velocity = Vector2.Scale(myRB.velocity, Vector2.up);

			if (myRB.velocity.y < 0) { myRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }
			else if (myRB.velocity.y > 0 && !Input.GetButton("Jump_P2")) { myRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; }

		} //code below this line will still run when the game is paused or over
	}

	bool togglePause()
	{
		if (!isGameOver)
		{
			if (Time.timeScale == 0f)
			{
				//backgroundScreen.SetActive(false);
				Time.timeScale = 1f;
				return (false);
			}
			else
			{
				//backgroundScreen.SetActive(true);
				Time.timeScale = 0f;
				return (true);
			}
		}
		else return false;
	}

	void updateGameText()
	{
		scoreText.text = "Score: " + score;
	}

	//occurs based on set time, independent of frame
	void FixedUpdate()
	{
		if (!isGameOver && !isGamePaused) //only update the game logic if the game isn't over or isn't paused
		{

		} //anything below this will still run when the game is paused or over


	}

	public void setGameOver()
	{
		isGameOver = true;
		myRB.velocity = Vector2.zero;

		if (!winGame) backgroundLose.SetActive(true);
		else
		{
			backgroundWin.SetActive(true);
		}

		finalScoreText = GameObject.Find("FinalScoreText").GetComponent<Text>();
		finalScoreText.text = "Final Score: " + score;
	}
}
