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
		transform.position = new Vector3 (24.69f, 4.81f, 0.0f);

		print (transform.position);

        startPoint = this.transform.position;
        journey1Length = Vector2.Distance(startPoint, target.transform.position);
        journey2Length = Vector2.Distance(target.transform.position, startPoint);
	}

    void Update()
    {

        
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, 0.01f);
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


    //void GoLeft()
    //{
    //    float distCovered = (Time.time - startTime) * flightSpeed;
    //    fracJourney = distCovered / journey1Length;
    //    transform.position = Vector2.Lerp(startPoint, target.transform.position, fracJourney);
    //}

}
