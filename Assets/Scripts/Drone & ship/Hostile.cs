using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Hostile : MonoBehaviour {
	public GameObject CombatTexts;

	public int eveId;
	public int id;
	public string name;
	public string raw;

	//structure
	public int hp;
	//resistances
	public float kineticDamageResonance;
	public float thermalDamageResonance;
	public float explosiveDamageResonance;
	public float emDamageResonance;
	//shield
	public int shieldCapacity;
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

	public void set (JSONNode data) {
		raw = data;
		this.name = data["name"].ToString();
		this.id = (int)data ["id"].AsFloat;
		for (int i = 0 ; i < data["dogma"]["attributes"].Count ; i++){			
			switch ( data["dogma"]["attributes"][i]["attribute"]["name"]) {
			case "hp": 
				this.hp =  (int)(data["dogma"]["attributes"][i]["value"].AsFloat);	
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
			}
		}
	}

	void Explode () {
		Debug.Log ("Hostile explodes...");
		CombatTexts.SendMessage("winCombat");
		transform.FindChild ("ShipSprite").gameObject.SetActive (false);
		transform.FindChild ("CapsuleSprite").gameObject.SetActive (true);
	}
}
