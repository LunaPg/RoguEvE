using UnityEngine;
using System.Collections;

public class DroneSquadSlot : MonoBehaviour {
	public Drone drone;
	public bool selected = false;

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
