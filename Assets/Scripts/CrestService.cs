using UnityEngine;
using System.Collections;
using SimpleJSON;

public class CrestService : MonoBehaviour {

    public string url = "https://public-crest.eveonline.com";
    public WWW www;
	//public Drone drone;

    // Use this for initialization
    // Check if CREST Online
    IEnumerator Start(){
        www = new WWW(url);
        yield return www;

		if (www.error == null){ 
            Debug.Log("Is OK" + www.text);
        }
        else {
            Debug.Log("is NOT OK" + www.error);
        }

       // Renderer renderer = GetComponent<Renderer>();
       // renderer.material.mainTexture = www.texture;
    }

    // Get Drone Specs
    IEnumerator getDroneSpecs(string id) {
		Debug.Log ("In getDroneSpecs");
		www = new WWW("https://public-crest.eveonline.com" + "/types/" + id+"/");
        yield return www;
		Drone drone = new Drone ();
		JSONNode response = JSON.Parse(www.text);

		for (int i = 0 ; i < response["dogma"]["attributes"].Count ; i++){
			switch ( response["dogma"]["attributes"][i]["attribute"]["name"]) {
			case "hp": 
				Debug.Log("HP detected" + response["dogma"]["attributes"][i]["value"].AsFloat );
				drone.hp =  (int)(response["dogma"]["attributes"][i]["value"].AsFloat);	
				break;
			case "signatureRadius":
				Debug.Log ("signature redius detected" + response ["dogma"] ["attributes"] [i] ["value"]);
				drone.signatureRadius = (int)(response["dogma"]["attributes"][i]["value"].AsFloat);
				break;
			}
		}
		Debug.Log ("Drone HP is " + drone.hp);
		Debug.Log (response);
    }
		
	public void DroneTest () {
		StartCoroutine(getDroneSpecs("28288"));		
	}
}


