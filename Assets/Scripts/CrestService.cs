using UnityEngine;
using System;
using System.Collections;
using SimpleJSON;
using UnityEngine.UI;

public class CrestService : MonoBehaviour {
	public GameObject DronePrefab;
	public GameObject RifterPrefab;

    public string url = "https://public-crest.eveonline.com";
    public WWW www;
	public static CrestService Instance;
	public ArrayList lightScoutDronesT1 = new ArrayList();
	public Boolean gotLightScoutDronesT1 = false;
	public ArrayList lightScoutDroneT1Ids = new ArrayList{"2203","2464","2454","2486"};

	public Boolean gotRifter = false;
	public JSONNode rifter;
	public string rifterId = "587";


	//public Drone drone;
	
	/**
		Drone Id : 
		Acolyte : 2203, 
		Hornet : 2464, 
		Hobgoblin  : 2454
		Warrior : 2486

		Ship : 
		Rifter 587

	*/

    // Use this for initialization
    // Check if CREST Online
    void Start(){
		//Instance = this;
        //www = new WWW(url);
        //yield return www;

//		if (www.error == null){ 
//            Debug.Log("EVE CREST API IS ONLINE" + www.text);
//			DroneTest();
//        }
//        else {
//            Debug.LogError("EVE CREST API IS OFFLINE" + www.error);
//        }

       // Renderer renderer = GetComponent<Renderer>();
       // renderer.material.mainTexture = www.texture;
    }

    // Get Drone Specs
	IEnumerator getDroneSpecs(ArrayList dronesIds, ArrayList saveTo, Action onComplete) {
		foreach (string  droneId in dronesIds) {
			string droneUrl = url + "/types/" + droneId + "/";
			www = new WWW(droneUrl);
			Debug.Log (droneUrl);
	        yield return www;

			JSONNode response = JSON.Parse(www.text);
			GameObject prefab = Instantiate (DronePrefab);
			Drone drone = prefab.GetComponent<Drone> ();
			drone.set (response);
			saveTo.Add (drone);
			Debug.Log ("Drone HP is " + drone.hp + "Name"+ drone.name);
		}
		onComplete ();
    }

	IEnumerator getRifterSpecs(string rifterId, Action onComplete) {
		string rifterUrl = url + "/types/" + rifterId + "/";
		Debug.Log (rifterUrl);
		www = new WWW (rifterUrl);
		yield return www;

		JSONNode response = JSON.Parse (www.text);
		GameObject prefab = Instantiate (RifterPrefab);
		Hostile rifter = prefab.GetComponent<Hostile> ();
		Destroy (prefab);
		rifter.eveId = int.Parse (rifterId);
		//rifter.set (response);
		this.rifter = response;
		Debug.Log (rifter.name + " hp: " + rifter.hp);

		onComplete ();
	}
		
	public void GetLightScoutDronesT1 () {
		StartCoroutine (getDroneSpecs (lightScoutDroneT1Ids, lightScoutDronesT1, () => {
			Debug.Log("Finished !"+ lightScoutDronesT1.Count);
			gotLightScoutDronesT1 = true;
		})
		);		
	}

	public void GetRifter () {
		StartCoroutine (getRifterSpecs (rifterId, () => {
			Debug.Log ("got Rifter");
			Debug.Log (rifter);
			gotRifter = true;
		})
		);
	}

	public void GetLoot () {
	}
}


