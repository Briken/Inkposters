using UnityEngine;
using System.Collections;

public class PlayerHead : MonoBehaviour
{
    public string enemy;
    public GameObject mask;
    public GameObject tentacle;
    Vector2 initPos;
    public float resetWait = 2;

	// Use this for initialization
	void Start ()
    {
        initPos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.tag == enemy)
        {

            Lose ();
            ResetTime(resetWait);
        }

    }

    void Lose ()
    {

        Destroy (GetComponent<PlayerMovement> ());
        Destroy (tentacle.GetComponent<TentacleMovement> ());

        mask.GetComponent<MaskSpin>().CreateMask ();

    }

    IEnumerator ResetTime(float reset)
    {
        yield return new WaitForSeconds(reset);
        this.transform.position = initPos;
    }
}
