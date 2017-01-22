using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameInfo : MonoBehaviour {

    int roundCount;
    int p1Wins;
    int p2Wins;

    public Text greenScore;
    public Text pinkScore;
    public GameObject scoreScreen;

    float countdown = 5.0f;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
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
            Restart ();
            countdown = 5.0f;
        }
        	

	}

    public void ResetLevels(string winner)
    {
        if (countdown == 5.0f)
        {
            if (winner == "Player1")
                p1Wins++;
            else
                p2Wins++;

            greenScore.text = p1Wins.ToString();
            pinkScore.text = p2Wins.ToString();

            countdown = 0.0f;
        }
    }

    void Restart ()
    {
        scoreScreen.SetActive (false);
        roundCount++;
        SceneManager.LoadScene("TestScene");
    }
}
