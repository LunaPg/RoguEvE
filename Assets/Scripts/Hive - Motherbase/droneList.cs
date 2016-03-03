﻿using UnityEngine;
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
			float column = 1;
			GameObject parent = GameObject.Find("Content");

			foreach (Drone lightScoutDroneT1 in crest.lightScoutDronesT1) { // store string in crest, create instances of prefab, then call "set(string droneData)"

				GameObject DroneListItem = Instantiate (droneListItemPrefab);
				DroneListItem.GetComponent<Drone>().set(lightScoutDroneT1.raw);
				setDroneText (DroneListItem.GetComponent<Drone>(), DroneListItem);

				Sprite droneImg = (Sprite)Resources.Load("sprites/drones/"+lightScoutDroneT1.eveId.ToString(), typeof(Sprite));
				DroneListItem.transform.Find ("Image").GetComponentInChildren<Image> ().overrideSprite= droneImg;

				RectTransform ContentRect = (RectTransform)DroneListItem.transform;
				float y;
				if (column == 1) {
					y = DroneListItem.transform.position.y;
				}
				else {
					y =  - DroneListItem.transform.position.y - ContentRect.rect.height * column;

				}
				Vector3 newPostion =  new Vector3 (DroneListItem.transform.position.x, y, DroneListItem.transform.position.z);
				DroneListItem.transform.position = newPostion;
				BroadcastMessage ("addListItem", DroneListItem);
				column = column +1;
			}
		}
	}

	void setDroneText(Drone drone, GameObject prefab){
		prefab.transform.Find ("hp").GetComponent<Text>().text = "hp :"+drone.hp.ToString() ;
		prefab.transform.Find ("Name").GetComponent<Text>().text = drone.name ; 
		prefab.transform.Find ("kineticDmgResonnance").GetComponent<Text>().text = drone.kineticDamageResonance.ToString() ;
		prefab.transform.Find ("thermalDmgResonnance").GetComponent<Text>().text = drone.thermalDamageResonance.ToString() ;
		prefab.transform.Find ("explosiveDmgResonnance").GetComponent<Text>().text = drone.explosiveDamageResonance.ToString() ;
		prefab.transform.Find ("emDmgResonnance").GetComponent<Text>().text = drone.emDamageResonance.ToString() ;
		prefab.transform.Find ("Shield").GetComponent<Text>().text = drone.shieldCapacity.ToString() ;
		prefab.transform.Find ("emShield").GetComponent<Text>().text = drone.shieldEmDamageResonance.ToString() ;
		prefab.transform.Find ("explosiveShield").GetComponent<Text>().text = drone.shieldExplosiveDamageResonance.ToString() ;
		prefab.transform.Find ("kineticShield").GetComponent<Text>().text = drone.shieldKineticDamageResonance.ToString() ;
		prefab.transform.Find ("thermalShield").GetComponent<Text>().text = drone.shieldThermalDamageResonance.ToString() ;
		prefab.transform.Find ("Armor").GetComponent<Text>().text = drone.armorHp.ToString() ;
		prefab.transform.Find ("emArmor").GetComponent<Text>().text = drone.armorEmDamageResonance.ToString() ;
		prefab.transform.Find ("explosiveArmor").GetComponent<Text>().text = drone.armorExplosiveDamageResonance.ToString() ;
		prefab.transform.Find ("kineticArmor").GetComponent<Text>().text = drone.armorKineticDamageResonance.ToString() ;
		prefab.transform.Find ("thermalArmor").GetComponent<Text>().text = drone.armorThermalDamageResonance.ToString() ;
		prefab.transform.Find ("emDmg").GetComponent<Text>().text = drone.emDamage.ToString() ;
		prefab.transform.Find ("explosiveDmg").GetComponent<Text>().text = drone.explosiveDamage.ToString() ;
		prefab.transform.Find ("kineticDmg").GetComponent<Text>().text = drone.kineticDamage.ToString() ;
		prefab.transform.Find ("thermalDmg").GetComponent<Text>().text = drone.thermalDamage.ToString() ;
	}

	public void selected (GameObject drone) {
		DroneSquad.SendMessage("selectDrone", drone);
	}
}
