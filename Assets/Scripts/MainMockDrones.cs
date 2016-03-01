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

			Team team = GetComponent<Team> ();
			team.team = crest.lightScoutDronesT1;
			team.getDronesGameObjects ();
			
			init = true;
		}
	}
}
