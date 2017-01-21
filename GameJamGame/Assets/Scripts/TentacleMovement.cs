using UnityEngine;
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

        //if (Input.GetAxis(controls[0]) > 0)
        //{

        //    transform.position += new Vector3 (0.1f, 0.0f, 0.0f);

        //}
        //else if (Input.GetAxis(controls[0]) < 0)
        //{

        //    transform.position -= new Vector3 (0.1f, 0.0f, 0.0f);

        //}

        //if (Input.GetAxis(controls[1]) > 0)
        //{

        //    transform.position += new Vector3(0.0f, 0.1f, 0.0f);

        //}
        //else if (Input.GetAxis(controls[1]) < 0)
        //{

        //    transform.position -= new Vector3(0.0f, 0.1f, 0.0f);

        //}

    }
    void FixedUpdate()
    {

        float dist = Vector2.Distance(transform.position, playerBody.position);

        float xValue = Input.GetAxis(controls[0]);
        float yValue = Input.GetAxis(controls[1]);
        if (rb2D.velocity.magnitude < 10 && dist < 1.8f)
        {
            rb2D.AddForce(new Vector2(xValue, yValue) * 5, ForceMode2D.Force);
        }

        if (dist > 1.4f)
        {

            rb2D.drag = 100.0f;

        }
        else
        {
            rb2D.drag = 1.0f;

        }

    }

    public void MoveTowards ()
    {
        
    }

}
