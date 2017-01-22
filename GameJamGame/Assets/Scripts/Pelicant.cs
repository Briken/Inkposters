using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelicant : MonoBehaviour {

    public GameObject target;
    public float flightSpeed = 1.0f;
    public Vector2 startPoint;

    public float fracJourney;

    public bool goingLeft = true;
    public bool goingRight = false;


    float startTime;
    float journey1Length;
    float journey2Length;

	// Use this for initialization
	void Start ()
    {
        startPoint = this.transform.position;
        journey1Length = Vector2.Distance(startPoint, target.transform.position);
        journey2Length = Vector2.Distance(target.transform.position, startPoint);
	}

    void Update()
    {
        GoLeft();

        if (fracJourney > 1)
        {
            Destroy(this.gameObject);
        }
        //if (transform.position == target.transform.position)
        //{
        //    goingLeft = false;
        //    goingRight = true;
        //    startTime = Time.time;
        //}

        //if (goingRight)
        //{
        //    GoRight();
        //}
    }


    void GoLeft()
    {
        float distCovered = (Time.time - startTime) * flightSpeed;
        fracJourney = distCovered / journey1Length;
        transform.position = Vector2.Lerp(startPoint, target.transform.position, fracJourney);
    }
    
    void OnCollisionEnter2D(Collision2D squid)
    {
        Debug.Log("collided");
        if (squid.gameObject.tag == "Player1" || squid.gameObject.tag == "Player2" || squid.gameObject.tag == "Hand1" || squid.gameObject.tag == "Hand2")
        {
            Destroy(this.gameObject);
        }
    }

}
