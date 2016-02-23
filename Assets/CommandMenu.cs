using UnityEngine;
using System.Collections;

public class CommandMenu : MonoBehaviour {
	public Drone drone;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			drone = (Drone)gameObject.GetComponent("Drone");
		}
	}

	void OnMouseUp () {
	}

	void cmdOrbit() {
		//drone.orbit();
	}

	void cmdFire () {
		//drone.fire ();
	}
}
