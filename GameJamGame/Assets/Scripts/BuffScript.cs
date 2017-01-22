 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour {

    int buffID = 0;
    public float buffTime = 4.0f;
    public float speedMultiplier = 2;
    GameObject target;

	public AudioClip squawk;
	AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
		
       //buffID = (int)Random.Range(0,3);
		audioSource = GetComponent<AudioSource> ();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D squid)
    {

		audioSource.PlayOneShot (squawk);

        target = squid.transform.gameObject;

		if (target.tag == "Player1" || target.tag == "Player2") 
		{
			PlayerMovement moveScript = target.GetComponent<PlayerMovement> ();
			if (buffID == 0) 
			{
				moveScript.moveSpeed *= speedMultiplier;
				StartCoroutine (SpeedBuff (moveScript));
			}

			StartCoroutine (PlayAudio ());

		}

    }


    IEnumerator SpeedBuff(PlayerMovement move)
    {
        yield return new WaitForSeconds(buffTime);
        move.moveSpeed /= speedMultiplier;
    }

	IEnumerator PlayAudio ()
	{
		GetComponent <BoxCollider2D> ().enabled = false;
		GetComponent <SpriteRenderer> ().enabled = false;

		yield return new WaitForSeconds(squawk.length);
		Destroy (gameObject);
	}

}
