using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public float explosionRad = 10.0f;
    public float bombForce = 2.0f;
    public float stunDur = 3.0f;


    Rigidbody2D rb2D;
    Vector2 targetPos;
    Vector2 position;

    PlayerMovement moveScript;

    public GameObject explosion;
    public AudioClip explosionNoise;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        position = this.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D squid)
    {

        if (squid.collider.tag == "Player1" || squid.collider.tag == "Player2" || squid.collider.tag == "Hand1" || squid.collider.tag == "Hand2")
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, explosionRad);
            foreach (Collider2D coll2D in hitColliders)
            {
                targetPos = coll2D.transform.position;
                rb2D = coll2D.gameObject.GetComponent<Rigidbody2D>();
                if (rb2D != null && coll2D.tag == "Player1" || coll2D.tag == "Player2")
                {
                    moveScript = coll2D.gameObject.GetComponent<PlayerMovement>();
                    rb2D.AddForce((targetPos - position) * bombForce);
                    moveScript.stunned = true;

                }

            }

            StartCoroutine(PlayDestroy());

        }

    }

    private IEnumerator PlayDestroy ()
    {
        audioSource.PlayOneShot(explosionNoise);

        Instantiate(explosion, transform.position, Quaternion.identity);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(explosionNoise.length);
        Destroy(this.gameObject);

    }


}
