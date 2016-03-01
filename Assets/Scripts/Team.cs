using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	public ArrayList team = new ArrayList();
	public GameObject DronePrefab;

	public void addDrone(Drone drone){
		team.Add(drone);
	}

	public void getDronesGameObjects(){
		Debug.Log ("DronesGameObject"+team.Count);
		
		foreach (Drone drone in team) {
			GameObject droneClone = (GameObject)Instantiate (DronePrefab, transform.position, transform.rotation);
			droneClone.BroadcastMessage ("set", drone.raw);

		}
	}
}
