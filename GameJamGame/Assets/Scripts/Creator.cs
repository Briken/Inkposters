using UnityEngine;
using System.Collections;

public class Creator : MonoBehaviour
{

    public GameObject gameController;

	// Use this for initialization
	void Start ()
    {

        GameObject gameCont = GameObject.Find ("GameController");
        if (gameCont == null)
        {
            gameCont = Instantiate(gameController, transform.position, Quaternion.identity) as GameObject;
            gameCont.name = "GameController";

            print ("hello");
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

}
