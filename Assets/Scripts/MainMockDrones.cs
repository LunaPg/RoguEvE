using UnityEngine;
using System.Collections;

public class MainMockDrones : MonoBehaviour {

	public bool init = false;
	CrestService crest;

	// Use this for initialization
	void Start () {
		crest = GameObject.FindGameObjectWithTag ("CREST").GetComponent<CrestService> ();
		crest.SendMessage("GetLightScoutDronesT1");	
	}
	
	// Update is called once per frame
	void Update () {

		if (init == false && crest.gotLightScoutDronesT1 == true ){
				Debug.Log ("GotlightScou >>" + crest.gotLightScoutDronesT1);

				Team team = GetComponent<Team> ();
				Debug.Log ("GotlightScou >>" + crest.gotLightScoutDronesT1);
				
				team.team = crest.lightScoutDronesT1;
				team.getDronesGameObjects ();
				
				//foreach (Drone dronedata in crest.lightScoutDronesT1) {
					//GameObject display = Instantiate (GameObject.FindGameObjectWithTag ("droneDetail"));
					//Text texts = display.GetComponentInChildren<Text>();
					//foreach (Text text in texts) {
					//		Debug.Log (text.text);
					//	}

					//Debug.Log ("GET DA DRONES !" + dronedata.eveId);
					//crest.gotLightScoutDronesT1 = false;
			init = true;
		}
	}
}
