using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicantSeek : MonoBehaviour {

    public float maxSpeed = 400.0f;
    public float maxSteering = 50.0f;
    public float currentSpeed = 50.0f;
    Vector2 currentVelocity;

    public GameObject target;

    protected Rigidbody2D rigidBody2D;

    // Use this for initialization
    void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        currentVelocity = rigidBody2D.velocity;
        currentVelocity += Seek(currentVelocity, target.transform.position);
    }

    protected void SetDirection()
    {
        // Don't set the direction if no direction
        if (rigidBody2D.velocity.sqrMagnitude > 0.0f)
        {
            transform.up = new Vector3(rigidBody2D.velocity.x, rigidBody2D.velocity.y, 0.0f);
        }
    }


    protected Vector2 LimitSteering(Vector2 steeringVelocity)
    {
        // This limits the steering velocity to maxSteering. sqrMagnitude is used rather than magnitude as in magnitude a square root must be computed which is a slow operation.
        // By using sqrMagnitude and comparing with maxSteering squared we can around using the expensive square root operation.
        if (steeringVelocity.sqrMagnitude > maxSteering * maxSteering)
        {
            steeringVelocity.Normalize();
            steeringVelocity *= maxSteering;
        }
        return steeringVelocity;
    }

    protected Vector2 LimitVelocity(Vector2 velocity)
    {
        // This limits the velocity to max speed. sqrMagnitude is used rather than magnitude as in magnitude a square root must be computed which is a slow operation.
        // By using sqrMagnitude and comparing with maxSpeed squared we can around using the expensive square root operation.
        if (velocity.sqrMagnitude > currentSpeed * currentSpeed)
        {
            velocity.Normalize();
            velocity *= currentSpeed;
        }
        return velocity;
    }

    protected Vector2 Seek(Vector2 currentVelocity, Vector2 targetPosition)
    {
        // These 3 lines are equivalent to: desiredVelocity = Normalise(targetPosition - currentPoisition) * MaxSpeed
        Vector2 desiredVelocity = targetPosition - new Vector2(transform.position.x, transform.position.y);
        desiredVelocity.Normalize();
        desiredVelocity *= currentSpeed;

        // Calculate steering velocity
        Vector2 steeringVelocity = desiredVelocity - currentVelocity;

        // A way to control steering speed. This one is based on the mass of an agent (Can't devide a vector so thats why its 1/mass and then multiplied)
        // Could do this in many different ways: limited by degrees per second, propotionionally limited to current speed, or simply don't limit it and see what happens
        steeringVelocity *= (1.0f / rigidBody2D.mass);
        steeringVelocity = LimitSteering(steeringVelocity);

        // Useful for showing directions in scene view to visualise what the AI is doing
        Debug.DrawRay(transform.position, desiredVelocity, Color.red);
        Debug.DrawRay(transform.position, currentVelocity);

        return steeringVelocity;
    }
}
