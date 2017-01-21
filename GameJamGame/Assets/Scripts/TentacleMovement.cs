﻿using UnityEngine;
using System.Collections;

public class TentacleMovement : MonoBehaviour
{

    public string[] controls = new string[2];
    /*
     * 0 = Horizontal
     * 1 = Vertical
     */

    Rigidbody2D rb2D;

    public Transform playerBody;

    // Use this for initialization
    void Start ()
    {
        rb2D = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
    void FixedUpdate()
    {

        float xValue = Input.GetAxis(controls[0]);
        float yValue = Input.GetAxis(controls[1]);

        if (rb2D.velocity.magnitude < 20)
        {
            rb2D.AddForce(new Vector2(xValue, yValue) * 17, ForceMode2D.Force);
        }

    }

}
