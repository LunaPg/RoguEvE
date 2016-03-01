using UnityEngine;
using System.Collections;

public class DroneSquadSlot : MonoBehaviour {
	public Drone drone;
	public bool selected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assignDrone (Drone drone) {
		if (!selected)
			return;
		this.drone = drone;
	}

	public void select() {
		selected = true;
	}

	public void deselect () {
		selected = false;
	}

	public bool hasDrone () {
		return drone != null;
	}
}
