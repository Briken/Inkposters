using UnityEngine;
using System.Collections;

public class MaskSpin : MonoBehaviour
{

    Rigidbody2D rb2D;
    public GameObject maskObject;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void CreateMask ()
    {

        GameObject mask = Instantiate (maskObject, transform.position, Quaternion.identity) as GameObject;

        mask.GetComponent<MaskSpin>().ShootMask();

        Destroy(this.gameObject);

    }

    public void ShootMask ()
    {

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce (transform.up * 6.0f, ForceMode2D.Impulse);

    }

}
