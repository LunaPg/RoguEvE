using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
	public bool isOrbiting;
	// Use this for initialization
	void Start ()
	{
		isOrbiting = false;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void startOrbiting () {
		isOrbiting = true;
	}
}

