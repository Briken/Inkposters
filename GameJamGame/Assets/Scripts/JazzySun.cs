using UnityEngine;
using System.Collections;

public class JazzySun : MonoBehaviour {

    float countdown;
    public float maxCountdown;

	// Use this for initialization
	void Start ()
    {
        countdown = maxCountdown;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;

        if (countdown <= 0)
        {

            if (transform.eulerAngles.z == 0)
                transform.eulerAngles = new Vector3 (0, 0, -17);
            else
                transform.eulerAngles = new Vector3 (0, 0, 0);

            countdown = maxCountdown;
        }

	}

}
