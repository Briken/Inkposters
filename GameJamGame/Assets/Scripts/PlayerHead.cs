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

	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.Find("GameController");
        infoScript = gameController.GetComponent<GameInfo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameController == null)
        {
            gameController = GameObject.Find("GameController");
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.tag == enemy && mask != null)
        {

            Lose ();

            infoScript.ResetLevels(this.name);
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
