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
		if (Input.GetButtonDown ("Player1A"))
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
			resumeButton.SetActive (false);
			//settingsButton.SetActive (false);
			quitButton.SetActive (false);

			settings = true;

			settingsMenu.SetActive (true);
		}
		else
		{
			resumeButton.SetActive (true);
			//settingsButton.SetActive (true);
			quitButton.SetActive (true);

			settings = false;

			settingsMenu.SetActive (false);
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
