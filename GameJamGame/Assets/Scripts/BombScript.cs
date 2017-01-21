using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public float explosionRad = 10.0f;
    public float bombForce = 2.0f;

    Rigidbody2D rb2D;
    Vector2 targetPos;
    Vector2 position;

	// Use this for initialization
	void Start () {
        position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D squid)
    {

        Debug.Log("Collision happened");
        if (squid.collider.tag == "Player")
        {
            Debug.Log("player collision");
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(position, explosionRad);
            int i = 0;
            Debug.Log("hit colliders" + hitColliders.Length.ToString());
            foreach (Collider2D coll2D in hitColliders)
            {
                targetPos = coll2D.transform.position;
                rb2D = coll2D.gameObject.GetComponent<Rigidbody2D>();
                if (rb2D != null)
                {   
                    rb2D.AddForce((targetPos - position) * bombForce);
                }
            }
            Destroy(this.gameObject);
        }
    }
}
