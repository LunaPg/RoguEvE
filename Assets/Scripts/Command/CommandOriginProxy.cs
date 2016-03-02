using UnityEngine;
using System.Collections;

public class CommandOriginProxy : MonoBehaviour {
	public GameObject drone;
	CommandOrigin cmd;
	public bool hovered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseOver () {
		hovered = true;
	}

	void OnMouseExit () {
		hovered = false;
	}

	void OnMouseDown() {
		if (hovered) {
			cmd.hovered = true;
			cmd.startExecutingCommand ();
		}
	}

	void assignDrone (Drone drone) {
		cmd = drone.GetComponent<CommandOrigin> ();
	}
}
