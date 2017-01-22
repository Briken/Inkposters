using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffScript : MonoBehaviour {

    int buffID = 0;
    public float buffTime = 4.0f;
    public float speedMultiplier = 2;
    GameObject target;

    // Use this for initialization
    void Start()
    {
        buffID = (int)Random.Range(0,3);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D squid)
    {
        target = squid.transform.gameObject;
        PlayerMovement moveScript = target.GetComponent<PlayerMovement>();
        if (buffID == 0)
        {
            moveScript.moveSpeed *= speedMultiplier;
            StartCoroutine(SpeedBuff(moveScript));
        }
    }


    IEnumerator SpeedBuff(PlayerMovement move)
    {
        yield return new WaitForSeconds(buffTime);
        move.moveSpeed /= speedMultiplier;
    }
}
