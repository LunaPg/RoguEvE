using UnityEngine;
using System.Collections;

public class DroneSquadSlot : MonoBehaviour {
	Drone drone;
	bool selected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assign (Drone drone) {
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
