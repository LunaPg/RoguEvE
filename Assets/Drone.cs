using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Drone : MonoBehaviour
{
	public bool isOrbiting;
	// Use this for initialization
	void Start ()
	{
		isOrbiting = false;
		//ry JSON parsing tests
		string jsonString = "{\"A\": 1}";
		var json = JSON.Parse(jsonString);
		Debug.Log(json);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void startOrbiting () {
		isOrbiting = true;
	}
}

