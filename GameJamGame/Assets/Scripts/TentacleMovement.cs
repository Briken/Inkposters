using UnityEngine;
using System.Collections;

public class TentacleMovement : MonoBehaviour
{
    public bool stunned = false;
    float stunDur = 3.0f;
    public string[] controls = new string[2];
    /*
     * 0 = Horizontal
     * 1 = Vertical
     */

    Rigidbody2D rb2D;

    public Transform playerBody;

    bool outOfWater;

	public AudioClip fisting;
	AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        rb2D = GetComponent <Rigidbody2D> ();
		audioSource = GetComponent <AudioSource> ();
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
    }

    void FixedUpdate()
    {
        if (!stunned && !outOfWater)
        {
            float xValue = Input.GetAxis(controls[0]);
            float yValue = Input.GetAxis(controls[1]);

            Vector2 forwardVector = new Vector2(xValue, yValue) + new Vector2(transform.position.x, transform.position.y);
            float dist = Vector2.Distance(forwardVector, playerBody.position);

            if (rb2D.velocity.magnitude < 20 && dist < 4.5f)
            {
                rb2D.AddForce(new Vector2(xValue, yValue) * 17, ForceMode2D.Force);
            }

            if (dist > 4)
            {

                rb2D.drag = 7;

            }
            else
            {

                rb2D.drag = 1;

            }

        }
        if (stunned)
        {

            StartCoroutine(Stun());

        }

    }
    IEnumerator Stun()
    {

        yield return new WaitForSeconds(stunDur);
        stunned = false;

    }

	void OnCollisionEnter2D (Collision2D other)
	{
		audioSource.PlayOneShot (fisting);
	}

}
