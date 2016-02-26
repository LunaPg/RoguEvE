using UnityEngine;
using System.Collections;
using SimpleJSON;

public class CrestService : MonoBehaviour {

    public string url = "https://public-crest.eveonline.com";
    public WWW www;
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
		www = new WWW(url + "/types/" + id+"/");
        yield return www;
		Drone drone = new Drone ();
		JSONNode response = JSON.Parse(www.text);
		drone.name = response["name"].ToString();
		for (int i = 0 ; i < response["dogma"]["attributes"].Count ; i++){			
			switch ( response["dogma"]["attributes"][i]["attribute"]["name"]) {
			case "hp": 
				drone.hp =  (int)(response["dogma"]["attributes"][i]["value"].AsFloat);	
				break;
			case "maxVelocity":
				drone.maxVelocity = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "speed":
				drone.speed = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "maxRange":
				drone.maxRange = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "trackingSpeed":
				drone.trackingSpeed = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;

			case "entityAttackRange":
				drone.entityAttackRange = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "entityFlyRange":
				drone.entityFlyRange = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "rechargeRate":
				drone.rechargeRate = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "agility":
				drone.agility = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "scanSpeed":
				drone.scanSpeed = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "kineticDamageResonance":
				drone.kineticDamageResonance = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "thermalDamageResonance":
				drone.thermalDamageResonance = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "explosiveDamageResonance":
				drone.explosiveDamageResonance = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "emDamageResonance":
				drone.emDamageResonance = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "emDamage":
				drone.emDamage = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "explosiveDamage":
				drone.explosiveDamage = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "kineticDamage":
				drone.kineticDamage = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "thermalDamage":
				drone.thermalDamage = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;

			case "shieldCapacity":
				drone.shieldCapacity  = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "armorHP":
				drone.armorHp  = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "armorEmDamageResonance":
				drone.armorEmDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "armorExplosiveDamageResonance":
				drone.armorExplosiveDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "armorKineticDamageResonance":
				drone.armorKineticDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "armorThermalDamageResonance":
				drone.armorThermalDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "shieldEmDamageResonance":
				drone.shieldEmDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "shieldExplosiveDamageResonance":
				drone.shieldExplosiveDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "shieldKineticDamageResonance":
				drone.shieldKineticDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "shieldThermalDamageResonance":
				drone.shieldThermalDamageResonance  = response ["dogma"] ["attributes"] [i] ["value"].AsFloat;
			break;
			case "shieldRechargeRate":
				drone.shieldRechargeRate  = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			case "signatureRadius":
				drone.signatureRadius = (int)(response["dogma"]["attributes"][i]["value"].AsFloat);
			break;
			case "droneBandwidthUsed":
				drone.droneBandwidthUsed  = (int)(response ["dogma"] ["attributes"] [i] ["value"].AsFloat);
			break;
			}
		}
		Debug.Log ("Drone HP is " + drone.hp + "Name"+ drone.name);
		Debug.Log (response);
    }
		
	public void DroneTest () {
		StartCoroutine(getDroneSpecs("28288"));		
	}
}


