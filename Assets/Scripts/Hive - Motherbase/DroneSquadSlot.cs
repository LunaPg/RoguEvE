using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneSquadSlot : MonoBehaviour {
	public Drone drone;
	public bool selected = false;
	public int index; 
	public GameObject team;

	public void assignDrone (GameObject droneListItem) {
		if (!selected)
			return;
		
		
		 drone = droneListItem.GetComponent < Drone> ();
		team.GetComponent<Team> ().setThumbnail(index, droneListItem);
		//this.drone = drone;
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
