using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	public ArrayList team = new ArrayList();
	public GameObject DronePrefab;

	public void addDrone(Drone drone){
		team.Add(drone);
	}

	public void getDronesGameObjects(){
		Debug.Log ("DronesGameObject"+team.Count);
		int i = 1;
		foreach (Drone drone in team) {
			string imageName = "Drone" + i.ToString ();
			string spriteName = drone.eveId.ToString ();
			GameObject droneClone = (GameObject)Instantiate (DronePrefab, transform.position, transform.rotation);
			droneClone.BroadcastMessage ("set", drone.raw);
			Sprite droneImg = (Sprite)Resources.Load("sprites/drones/"+spriteName, typeof(Sprite));
			GameObject image = GameObject.Find (imageName);
			image.GetComponent<Image> ().overrideSprite= droneImg;
			i = i + 1;
		}
	}
}
