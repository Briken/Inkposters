using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameInfo : MonoBehaviour {

    int roundCount;
    int p1Wins;
    int p2Wins;

	public Image greenScore;
	public Image pinkScore;
    public GameObject scoreScreen;

	public Sprite[] greenSprites;
	public Sprite[] pinkSprites;

    float countdown = 5.0f;

	public GameObject greenWin;
	public GameObject pinkWin;

	bool endGame = false;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
		greenWin = GameObject.FindGameObjectWithTag("GreenWin");
		greenWin.SetActive (false);

		pinkWin = GameObject.FindGameObjectWithTag("PinkWin");
		pinkWin.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (countdown < 5.0f)
        {
            countdown += Time.deltaTime;
            scoreScreen.SetActive (true);
        }
        if (countdown > 5.0f)
		{
			if (!endGame)
            	Restart ();
			else
				EndGame ();
            countdown = 5.0f;
        }
        	

	}

    public void ResetLevels(string winner)
    {
        if (countdown == 5.0f)
        {
            if (winner == "Player1")
                p2Wins++;
            else
                p1Wins++;

			if (p1Wins == 5)
			{
				greenWin.SetActive (true);
				endGame = true;
			}

			if (p2Wins == 5)
			{
				pinkWin.SetActive (true);
				endGame = true;
			}

			greenScore.sprite = greenSprites[p1Wins];
			pinkScore.sprite = pinkSprites[p2Wins];

            countdown = 0.0f;
        }
    }

    void Restart ()
    {
        scoreScreen.SetActive (false);
        roundCount++;
        SceneManager.LoadScene("TestScene");
    }

	void EndGame ()
	{
		SceneManager.LoadScene("MainMenu");
		Destroy (gameObject);
	}

	void OnLevelWasLoaded ()
	{
			greenWin = GameObject.FindGameObjectWithTag("GreenWin");
			greenWin.SetActive (false);

			pinkWin = GameObject.FindGameObjectWithTag("PinkWin");
			pinkWin.SetActive (false);
	}

}
