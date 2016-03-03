using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SimpleJSON;

public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	public List<GameObject> team = new List<GameObject>(new GameObject[5]);
	List<GameObject> thumbnails = new List<GameObject>();
	public GameObject thumbnail1;
	public GameObject thumbnail2;
	public GameObject thumbnail3;
	public GameObject thumbnail4;
	public GameObject thumbnail5;

	public List<string> teamRaw = new List<string>();
	public bool loadDronesOnStart = false;
	public GameObject DronePrefab;
	string fileUrl;

	int selectedIndex;

	void Start () {
		fileUrl = Application.persistentDataPath + "/team.dat";

		foreach (GameObject drone in GameObject.FindGameObjectsWithTag("drone") ) {
			addDrone (drone);
		}

		thumbnails.Add (thumbnail1);
		thumbnails.Add (thumbnail2);
		thumbnails.Add (thumbnail3);
		thumbnails.Add (thumbnail4);
		thumbnails.Add (thumbnail5);


		if (loadDronesOnStart)
			load ();
	}

	public void addDrone(GameObject drone){
		team.Add(drone);
	}

	public void save () {
		var i = 0;
		foreach (Drone drone in GetComponentsInChildren<Drone>()) {
			Debug.Log ("saving drone" + i + " as " + drone.name);
			PlayerPrefs.SetString ("team-" + i++, drone.raw);
		}

//		for (int i = 0; i < 5; i++) {
//			Drone drone = team [i].GetComponent<Drone> ();
//			PlayerPrefs.SetString ("team-" + i, drone.raw);
//		}
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
			
		BroadcastMessage ("setSliders");

		Debug.Log ("done, found " + team.Count + " drones");
	}

	public void setThumbnail (int i, GameObject droneObject) {
		Drone drone = droneObject.GetComponent<Drone> ();
		string spriteName = drone.eveId.ToString ();

		Sprite droneImg = (Sprite)Resources.Load("sprites/drones/"+spriteName, typeof(Sprite));
		GameObject thumbnail = thumbnails [i];
		thumbnail.GetComponent<Image> ().sprite = droneImg;
	}


	public void selectSlot (int index) {
		selectedIndex = index;
	}

	public void selectDrone (GameObject drone) {
		setThumbnail (selectedIndex, drone);
	}

}
