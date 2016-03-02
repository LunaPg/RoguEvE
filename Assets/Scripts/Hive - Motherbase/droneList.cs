using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class droneList : MonoBehaviour {
	CrestService crest;
	public ArrayList drones = new ArrayList();
	bool initialized = false;
	public GameObject droneListContent;
	public GameObject droneListItemPrefab;
	public GameObject DroneSquad;
	// Use this for initialization
	void Start () {
		crest = GameObject.FindGameObjectWithTag ("CREST").GetComponent<CrestService> ();
		crest.SendMessage("GetLightScoutDronesT1");	
	}
		
	// Update is called once per frame
	void Update () {
		if (!initialized && crest.gotLightScoutDronesT1 == true) {
			initialized = true;

			foreach (Drone lightScoutDroneT1 in crest.lightScoutDronesT1) { // store string in crest, create instances of prefab, then call "set(string droneData)"

				GameObject DroneListItem = Instantiate (droneListItemPrefab);
				DroneListItem.GetComponent<Drone>().set(lightScoutDroneT1.raw);
				BroadcastMessage ("addListItem", DroneListItem);

			//	Text texts = display.GetComponentInChildren<Text>();
				//foreach 			(Text text in texts) {
			//		Debug.Log (text.text);
			//	}

			//	Debug.Log ("GET DA DRONES !" + dronedata.eveId);

			}
		}
	}

	public void selected (Drone drone) {
		DroneSquad.BroadcastMessage ("selectSquadSlot", drone);
	}
}
