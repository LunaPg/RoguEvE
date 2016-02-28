using UnityEngine;
using System.Collections;

public class CommandOriginProxy : MonoBehaviour {
	public GameObject drone;
	CommandOrigin cmd;
	public bool hovered = false;

	// Use this for initialization
	void Start () {
		cmd = drone.GetComponent<CommandOrigin> ();
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
}
