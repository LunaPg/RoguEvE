using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SimpleJSON;

public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	public List<GameObject> team = new List<GameObject>();
	public List<GameObject> thumbnails = new List<GameObject>();
	public List<string> teamRaw = new List<string>();
	public bool loadDronesOnStart = false;
	public GameObject DronePrefab;
	string fileUrl;

	void Start () {
		fileUrl = Application.persistentDataPath + "/team.dat";

		foreach (GameObject drone in GameObject.FindGameObjectsWithTag("drone") ) {
			addDrone (drone);
		}

		foreach (GameObject thumbnail in GameObject.FindGameObjectsWithTag("thumbnail-drone")) {
			thumbnails.Add (thumbnail);
		}

		if (loadDronesOnStart)
			load ();
			Debug.Log (team);
	}

	public void addDrone(GameObject drone){
		team.Add(drone);
	}

	public void getDronesGameObjects(){
		Debug.Log ("DronesGameObject"+team.Count);
		int i = 1;
		foreach (GameObject droneObject in team) {
			Drone drone = droneObject.GetComponent<Drone> ();
			string imageName = "Drone" + i.ToString ();
			string spriteName = drone.eveId.ToString ();
			GameObject droneClone = (GameObject)Instantiate (DronePrefab, transform.position, transform.rotation);
			droneClone.transform.position = new Vector3(droneClone.transform.position.x + 10 *i, droneClone.transform.position.y, droneClone.transform.position.z);
			//droneClone.BroadcastMessage ("set", drone.raw);
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
		//addDrone (drone);
	}

	public void save () {
		for (int i = 0; i < team.Count; i++) {
			Drone drone = team [i].GetComponent<Drone> ();
			PlayerPrefs.SetString ("team-" + i, drone.raw);
		}
	}

	public void load () {
		for (int i = 0; i < 5; i++) {
			string jsonString = PlayerPrefs.GetString ("team-" + i, "");

			if (jsonString != "") {
				Drone drone = team[i].GetComponent<Drone> ();
				drone.eveId = drone.id;
				drone.set (JSON.Parse(jsonString));
				setThumbnail (i, team[i]);
				team [i].transform.position = drone.transform.position + Vector3.right * 10;
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
//		//foreach (string json in teamRaw) {
//		for ( int i = 0; i < teamRaw.Count; i++ ) {
//			Drone drone = team [i].GetComponent<Drone> ();		
//			drone.set (JSON.Parse(teamRaw[i]));
//		}
		Debug.Log ("done, found " + team.Count + " drones");
	}

	public void setThumbnail (int i, GameObject droneObject) {
		Drone drone = droneObject.GetComponent<Drone> ();
		string imageName = "Drone" + i.ToString ();
		string spriteName = drone.id.ToString ();

		Sprite droneImg = (Sprite)Resources.Load("sprites/drones/"+spriteName, typeof(Sprite));
		GameObject thumbnail = thumbnails [i];
		thumbnail.GetComponent<Image> ().overrideSprite = droneImg;
	}

}
