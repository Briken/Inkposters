using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{

	public GameObject pauseMenuObj;

	public GameObject resumeButton;
	public GameObject settingsButton;
	public GameObject quitButton;

	public GameObject settingsMenu;

	bool paused;

	bool settings;

	bool music;
	bool sfx;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("player1A"))
		{
			if (!paused)
				Pause ();
			else
				Resume ();
		}
	}

	void Pause ()
	{
		paused = true;
		pauseMenuObj.SetActive (true);
		Time.timeScale = 0.0f;
	}

	public void Resume ()
	{
		pauseMenuObj.SetActive (false);
		paused = false;
		Time.timeScale = 1.0f;
	}

	public void Settings ()
	{
		
		if (!settings)
		{
			resumeButton.SetActive = false;
			settingsButton.SetActive = false;
			quitButton.SetActive = false;

			settings = true;
		}

	}

	public void Quit ()
	{

	}

	public void MusicToggle ()
	{

	}

	public void SoundToggle ()
	{

	}

}
