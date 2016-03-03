using UnityEngine;
using System.Collections;

public class OnDroneListItemClick : MonoBehaviour {
	public void onClick () {
		Drone drone = GetComponent<Drone> ();
		Debug.Log (drone.eveId);
		SendMessageUpwards ("selected", GetComponent<Drone> ());
	}
}
