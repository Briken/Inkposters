using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlayerControlsScreenAir : MonoBehaviour {

    GameObject[] players;


	// Use this for initialization
	void Start ()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            //players[controllerID] = players controllerID
        }
        AirConsole.instance.onMessage += OnMessage;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMessage(int from, JToken data)
    {
        //player controllerid is passed in as from

        players[from].GetComponent<PlayerMovement>().//<CALL movement function here, using some form of the Jtoken "data" as the propulsion>

    }
}

//string action = (string)data["action"];
//int amount = (int)data["info"]["amount"];
//float torque = (float)data["info"]["torque"];

