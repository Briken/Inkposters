﻿using UnityEngine;
using System.Collections;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlayerMovement : MonoBehaviour
{

    public bool stunned = false;
    public float stunDur = 3;
    public float moveSpeed = 10;

    public float speedDur = 5;
    public float speedMultiplier = 2;

    public float rotationSpeed = 4.0f;

    public bool isSped = false;

    public string[] controls = new string[2];
    /*
     * 0 = PlayerHorizontal
     * 1 = PlayerVertical
     */

    Rigidbody2D rb2D;

    bool outOfWater;

    public GameObject stunnedIcon;

    GameObject stunObject;

    AudioSource audioSource;
    public AudioClip splat;

	int canRotate;

	// Use this for initialization
	void Start ()
    {

        rb2D = GetComponent<Rigidbody2D> ();
        stunned = true;
        StartCoroutine(Stun());
        audioSource = GetComponent<AudioSource> ();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y > 2.3f)
            outOfWater = true;
        else
            outOfWater = false;

        if (outOfWater)
        {

            rb2D.gravityScale = 0.5f;
            rb2D.drag = -0.5f;

        }
        else
        {

            rb2D.gravityScale = 0.0f;
            rb2D.drag = 1;

        }

        if (!stunned)
        {
			transform.localEulerAngles -= new Vector3(0.0f, 0.0f, rotationSpeed) * canRotate;

            float angle = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;
            if (!isSped)
            {
                if (Input.GetAxis(controls[1]) < 0 && rb2D.velocity.magnitude < 20 && !outOfWater)
                {

                    //transform.position += new Vector3(Mathf.Cos(angle) * 0.1f, Mathf.Sin(angle) * 0.1f, 0.0f);
                    rb2D.AddForce(transform.up * moveSpeed);

                }
            }
            if (isSped)
            {
                if (Input.GetAxis(controls[1]) < 0 && rb2D.velocity.magnitude < 20 && !outOfWater)
                {

                    //transform.position += new Vector3(Mathf.Cos(angle) * 0.1f, Mathf.Sin(angle) * 0.1f, 0.0f);
                    rb2D.AddForce(transform.up * (moveSpeed * speedMultiplier));
                    StartCoroutine(SlowDown());
                }
            }
        }
        //if (stunned)
        //{
        //    StartCoroutine(Stun());
        //}
    }
    public void StunTrigger()
    {
        StartCoroutine(Stun());
    }
    public IEnumerator Stun()
    {
        stunned = true;
        if (stunObject == null)
        {
            stunObject = Instantiate(stunnedIcon, transform.position, Quaternion.identity) as GameObject;
            stunObject.transform.parent = this.transform;
        }

        yield return new WaitForSeconds(stunDur);
        stunned = false;
        Destroy (stunObject);
        stunObject = null;

    }

    void OnCollisionEnter2D (Collision2D other)
    {

		if (!audioSource.isPlaying)
       		audioSource.PlayOneShot (splat);

    }
    IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(speedDur);
        isSped = false;
    }

	public void Rotate (int rot)
	{
		canRotate = rot;

	}

}
