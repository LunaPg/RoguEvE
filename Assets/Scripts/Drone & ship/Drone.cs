using UnityEngine;
using System.Collections;
using SimpleJSON;
using System;

public class Drone : MonoBehaviour
{
	public string name;
	public int eveId;
	[SerializeField]
	public JSONNode raw;

	//stats
	public int id;
	public int signatureRadius;
	public int maxVelocity;
	public int speed;
	public int maxRange;
	public float trackingSpeed;
	public float entityAttackRange;
	public float entityFlyRange;
	public int rechargeRate;
	public float damageMultiplier;
	public int agility;
	public int scanSpeed;
	public float techLevel;
	public int droneBandwidthUsed;
	//structure
	public int hp;
	//resistances
	public float kineticDamageResonance;
	public float thermalDamageResonance;
	public float explosiveDamageResonance;
	public float emDamageResonance;
	//shield
	public int shieldCapacity;
	public int shieldRechargeRate;
	public float shieldEmDamageResonance;
	public float shieldExplosiveDamageResonance;
	public float shieldKineticDamageResonance;
	public float shieldThermalDamageResonance;
	//armor
	public int armorHp;
	public float armorEmDamageResonance;
	public float armorExplosiveDamageResonance;
	public float armorKineticDamageResonance;
	public float armorThermalDamageResonance;
	//damage
	public int emDamage;
	public int explosiveDamage;
	public int kineticDamage;
	public int thermalDamage;

	public void set (GameObject droneObject) {
		set (droneObject.GetComponent<Drone> ().raw);
	}

	public void set (JSONNode data) {
		raw = data;
		this.name = data["name"].ToString();
		this.eveId = (int)data ["id"].AsFloat;
		for (int i = 0 ; i < data["dogma"]["attributes"].Count ; i++){			
			switch ( data["dogma"]["attributes"][i]["attribute"]["name"]) {
			case "hp": 
				this.hp =  (int)(data["dogma"]["attributes"][i]["value"].AsFloat);	
				break;
			case "maxVelocity":
				this.maxVelocity = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "speed":
				this.speed = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "maxRange":
				this.maxRange = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "trackingSpeed":
				this.trackingSpeed = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;

			case "entityAttackRange":
				this.entityAttackRange = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "entityFlyRange":
				this.entityFlyRange = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "rechargeRate":
				this.rechargeRate = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "agility":
				this.agility = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "scanSpeed":
				this.scanSpeed = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "kineticDamageResonance":
				this.kineticDamageResonance = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "thermalDamageResonance":
				this.thermalDamageResonance = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "explosiveDamageResonance":
				this.explosiveDamageResonance = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "emDamageResonance":
				this.emDamageResonance = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "emDamage":
				this.emDamage = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "explosiveDamage":
				this.explosiveDamage = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "kineticDamage":
				this.kineticDamage = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "thermalDamage":
				this.thermalDamage = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;

			case "shieldCapacity":
				this.shieldCapacity  = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "armorHP":
				this.armorHp  = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "armorEmDamageResonance":
				this.armorEmDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "armorExplosiveDamageResonance":
				this.armorExplosiveDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "armorKineticDamageResonance":
				this.armorKineticDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "armorThermalDamageResonance":
				this.armorThermalDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "shieldEmDamageResonance":
				this.shieldEmDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "shieldExplosiveDamageResonance":
				this.shieldExplosiveDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "shieldKineticDamageResonance":
				this.shieldKineticDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "shieldThermalDamageResonance":
				this.shieldThermalDamageResonance  = data ["dogma"] ["attributes"] [i] ["value"].AsFloat;
				break;
			case "shieldRechargeRate":
				this.shieldRechargeRate  = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			case "signatureRadius":
				this.signatureRadius = (int)(data["dogma"]["attributes"][i]["value"].AsFloat);
				break;
			case "droneBandwidthUsed":
				this.droneBandwidthUsed  = (int)(data ["dogma"] ["attributes"] [i] ["value"].AsFloat);
				break;
			}
		}
	}
}

