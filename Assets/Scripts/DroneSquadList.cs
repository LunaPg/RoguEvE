using UnityEngine;
using System.Collections;

public class DroneSquadList : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void deselectAll() {
		BroadcastMessage ("deselect");
	}

	public void selectSquadSlot (Drone drone) {
		BroadcastMessage ("assignDrone", drone);
	}
}
