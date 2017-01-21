using UnityEngine;
using System.Collections;

public class PlayerHead : MonoBehaviour
{
    public string enemy;
    public GameObject mask;
    public GameObject tentacle;
    Vector2 initPos;
    public float resetWait = 2;
    GameObject gameController;
    GameInfo infoScript;

    float countdown = 5.0f;

	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.Find("GameController");
        infoScript = gameController.GetComponent<GameInfo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (countdown < 5.0f)
        {
            countdown += Time.deltaTime;
        }
        else if (countdown > 5.0f)
        {
            infoScript.ResetLevels();
        }

	}

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.tag == enemy)
        {

            Lose ();

            if (this.name == "Player1")
            {
                infoScript.player1Wins();
            }

            if (this.name == "Player2")
            {
                infoScript.player2Wins();
            }

            countdown = 0.0f;

        }

    }

    void Lose ()
    {

        Destroy (GetComponent<PlayerMovement> ());
        Destroy (tentacle.GetComponent<TentacleMovement> ());

        if (mask != null)
            mask.GetComponent<MaskSpin>().CreateMask ();

    }
}
