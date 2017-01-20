using UnityEngine;
using System.Collections;

public class TentacleMovement : MonoBehaviour
{

    public string[] controls = new string[2];
    /*
     * 0 = Horizontal
     * 1 = PlayerVertical
     */

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetAxis(controls[0]) > 0)
        {

            transform.position += new Vector3 (0.1f, 0.0f, 0.0f);

        }
        else if (Input.GetAxis(controls[0]) < 0)
        {

            transform.position -= new Vector3 (0.1f, 0.0f, 0.0f);

        }

        if (Input.GetAxis(controls[1]) > 0)
        {

            transform.position += new Vector3(0.0f, 0.1f, 0.0f);

        }
        else if (Input.GetAxis(controls[1]) < 0)
        {

            transform.position -= new Vector3(0.0f, 0.1f, 0.0f);

        }

    }

}
