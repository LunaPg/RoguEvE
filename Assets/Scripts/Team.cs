using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using SimpleJSON;

public class Team : MonoBehaviour {
	
	//public List<Drone> team = new List<Drone>();
	List<GameObject> team = new List<GameObject>();
	public GameObject drone1;
	public GameObject drone2;
	public GameObject drone3;
	public GameObject drone4;
	public GameObject drone5;

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

		team.Add (drone1);
		team.Add (drone2);
		team.Add (drone3);
		team.Add (drone4);
		team.Add (drone5);

		thumbnails.Add (thumbnail1);
		thumbnails.Add (thumbnail2);
		thumbnails.Add (thumbnail3);
		thumbnails.Add (thumbnail4);
		thumbnails.Add (thumbnail5);


		if (loadDronesOnStart)
			load ();
	}

	public void save () {
		var i = 0;
		foreach (Drone drone in GetComponentsInChildren<Drone>()) {
			Debug.Log ("saving drone" + i + " as " + drone.name);
			PlayerPrefs.SetString ("team-" + i, drone.raw.ToString());
			i++;
			Debug.Log (drone.raw);
		}

//		for (int i = 0; i < 5; i++) {
//			Drone drone = team [i].GetComponent<Drone> ();
//			PlayerPrefs.SetString ("team-" + i, drone.raw);
//		}
	}

	public void load () {
		for (int i = 0; i < 5; i++) {
			string jsonString = PlayerPrefs.GetString ("team-" + i, "not-found");

			if (jsonString != "") {
				Drone drone = team [i].GetComponent<Drone> ();
				drone.set (JSON.Parse (jsonString));
				Debug.Log ("Found drone " + drone.name + " at index " + i);
				setThumbnail (i, team [i]);
				team [i].transform.position += Vector3.right * 10;
			} else
				Debug.Log ("MEH" + jsonString + ":(");
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
		thumbnails [selectedIndex].GetComponent<Drone> ().set (drone.GetComponent<Drone>().raw);
	}

}
