using UnityEngine;
using System.Collections;

public class CommandOriginProxy : MonoBehaviour {
	public GameObject drone;
	public bool hovered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnMouseOver () {
		hovered = true;
	}

	void OnMouseExit () {
		hovered = false;
	}

	void OnMouseDown() {
		if (hovered) {
			drone.GetComponent<CommandOrigin>().hovered = true;
			drone.GetComponent<CommandOrigin>().startExecutingCommand ();
		}
	}

	void assignDrone (GameObject drone) {
		drone = drone;
	}
}
