using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPause : MonoBehaviour {

	public void PauseGame()
	{
		Time.timeScale = 0.0f;
	}
	public void PlayGame()
	{
		Time.timeScale = 1;
	}
}
