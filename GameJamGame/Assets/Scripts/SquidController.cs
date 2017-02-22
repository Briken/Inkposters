using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class SquidController : MonoBehaviour 
{

	public PlayerMovement squidOne;
	public PlayerMovement squidTwo;
	public TentacleMovement armOne;
	public TentacleMovement armTwo;

	public Text uiText;


	void Awake () 
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;
	}

	void OnConnect (int device_id) {
		if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) 
		{
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2) 
			{
				StartGame ();
			} else 
			{
				uiText.text = "NEED MORE PLAYERS";
			}

		}

	}

	void OnDisconnect (int device_id) 
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);
		if (active_player != -1) 
		{
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2) 
			{
				StartGame ();
			} else 
			{
				AirConsole.instance.SetActivePlayers (0);
				uiText.text = "PLAYER LEFT - NEED MORE PLAYERS";
			}

		}

	}

	void OnMessage (int device_id, JToken data) 
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);
		if (active_player != -1) 
		{
			if (active_player == 0) 
			{
				int rot  = (int) data["Rotate"];
				squidOne.Rotate (rot);
			}
			if (active_player == 1) 
			{
				
			}

		}

	}
		
	void StartGame ()
	{
		AirConsole.instance.SetActivePlayers (2);
	}

	void OnDestroy () 
	{

		// unregister airconsole events on scene change
		if (AirConsole.instance != null) 
		{
			AirConsole.instance.onMessage -= OnMessage;
		}

	}

}
