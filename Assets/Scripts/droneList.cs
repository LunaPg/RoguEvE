using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class droneList : MonoBehaviour {
	
	public ArrayList drones = new ArrayList();


	// Use this for initialization
	void Start () {
		CrestService crest = GetComponent<CrestService> ();
		crest.SendMessage("DroneTest");	
	}
		
	// Update is called once per frame
	void Update () {
		CrestService crest = GetComponent<CrestService> ();
		if (crest.dronesOk == true) {
			foreach (Drone dronedata in crest.drones) {
				GameObject display = Instantiate (GameObject.FindGameObjectWithTag ("droneDetail"));
				Text texts = display.GetComponentInChildren<Text>();
				//foreach (Text text in texts) {
			//		Debug.Log (text.text);
			//	}

				Debug.Log ("GET DA DRONES !" + dronedata.eveId);
				crest.dronesOk = false;
			}
		}

	}
}
