using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DroneSquadSlot : MonoBehaviour {

	public void assignDrone (GameObject droneListItem) {
		GetComponent<Drone> ().set (droneListItem.GetComponent<Drone>().raw);
	}


}
