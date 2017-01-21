using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public string[] controls = new string[2];
    /*
     * 0 = PlayerHorizontal
     * 1 = PlayerVertical
     */

    Rigidbody2D rb2D;

    bool outOfWater = false;

	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();    
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.y > 3.4)
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
            rb2D.gravityScale = 0;
            rb2D.drag = 1;
        }

	    if (Input.GetAxis(controls[0]) > 0)
        {

            transform.localEulerAngles -= new Vector3(0.0f, 0.0f, 4.0f);

        }
        else if (Input.GetAxis(controls[0]) < 0)
        {

            transform.localEulerAngles += new Vector3(0.0f, 0.0f, 4.0f);

        }


        float angle = (transform.eulerAngles.z + 90)* Mathf.Deg2Rad;
        if (Input.GetAxis(controls[1]) < 0 && rb2D.velocity.magnitude < 20 && !outOfWater)
        {

            rb2D.AddForce (transform.up * 10);

        }

    }

}
