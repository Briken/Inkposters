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

	// Use this for initialization
	void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();    
	}
	
	// Update is called once per frame
	void Update ()
    {

	    if (Input.GetAxis(controls[0]) > 0)
        {

            //transform.position += new Vector3 (0.1f, 0.0f, 0.0f);
            transform.localEulerAngles -= new Vector3(0.0f, 0.0f, 2.0f);

        }
        else if (Input.GetAxis(controls[0]) < 0)
        {

            //transform.position -= new Vector3 (0.1f, 0.0f, 0.0f);
            transform.localEulerAngles += new Vector3(0.0f, 0.0f, 2.0f);

        }


        float angle = (transform.eulerAngles.z + 90)* Mathf.Deg2Rad;
        if (Input.GetAxis(controls[1]) < 0 && rb2D.velocity.magnitude < 10)
        {

            print ("hello");

            //transform.position += new Vector3(Mathf.Cos(angle) * 0.1f, Mathf.Sin(angle) * 0.1f, 0.0f);
            rb2D.AddForce (transform.up * 5);

        }

    }

}
