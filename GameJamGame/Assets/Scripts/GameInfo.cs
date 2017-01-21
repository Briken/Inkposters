using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameInfo : MonoBehaviour {

    int roundCount;
    int p1Wins;
    int p2Wins;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetLevels()
    {
        roundCount++;
        SceneManager.LoadScene("TestScene");
    }

    public void player1Wins()
    {
        p1Wins++;
    }

    public void player2Wins()
    {
        p2Wins++;
    }
}
