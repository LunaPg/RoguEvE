using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SimpleJSON;

public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	public List<Drone> team = new List<Drone>();
	List<string> teamRaw = new List<string> ();
	public bool loadDronesOnStart = false;
	public GameObject DronePrefab;
	string fileUrl;

	void Start () {
		fileUrl = Application.persistentDataPath + "/team.dat";

		if (loadDronesOnStart)
			load ();
			Debug.Log (team);
	}

	public void addDrone(Drone drone){
		team.Add(drone);
		teamRaw.Add (drone.raw.ToString());
	}

	public void getDronesGameObjects(){
		Debug.Log ("DronesGameObject"+team.Count);
		int i = 1;
		foreach (Drone drone in team) {
			string imageName = "Drone" + i.ToString ();
			string spriteName = drone.eveId.ToString ();
			GameObject droneClone = (GameObject)Instantiate (DronePrefab, transform.position, transform.rotation);
			droneClone.transform.position = new Vector3(droneClone.transform.position.x + 10 *i, droneClone.transform.position.y, droneClone.transform.position.z);
			droneClone.BroadcastMessage ("set", drone.raw);
			Sprite droneImg = (Sprite)Resources.Load("sprites/drones/"+spriteName, typeof(Sprite));
			GameObject image = GameObject.Find (imageName);
			image.GetComponent<Image> ().overrideSprite= droneImg;
			i = i + 1;
		}
	}

	public void deselectAll() {
		BroadcastMessage ("deselect");
	}

	public void selectSquadSlot (Drone drone) {
		BroadcastMessage ("assignDrone", drone);
		addDrone (drone);
	}

	public void save () {
		for (int i = 0; i < team.Count; i++) {
			PlayerPrefs.SetString ("team-" + i, teamRaw[i]);
		}
//		Debug.Log ("Saving team to file: " + fileUrl);
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Open (fileUrl, FileMode.OpenOrCreate);
//
//		bf.Serialize (file, teamRaw);
//		file.Close ();
//		Debug.Log ("done");
	}

	public void load () {
		for (int i = 0; i < 5; i++) {
			string jsonString = PlayerPrefs.GetString ("team-" + i, "");

			if (jsonString != "") {
				Drone drone = new Drone ();
				drone.set (JSON.Parse (jsonString));
				addDrone (drone);
			}
		}


//		if (!File.Exists (fileUrl))
//			return;
//		Debug.Log ("Loading team from file: " + fileUrl);
//		BinaryFormatter bf = new BinaryFormatter ();
//		FileStream file = File.Open (fileUrl, FileMode.Open);
//
//		teamRaw = (List<string>)bf.Deserialize (file);
//		file.Close ();
//
//		foreach (JSONNode json in teamRaw) {
//			Drone drone = new Drone ();
//			drone.set (JSON.Parse(json));
//			addDrone (drone);
//		}
		Debug.Log ("done, found " + team.Count + " drones");
	}

}
