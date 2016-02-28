using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Drone : MonoBehaviour
{
	public string name;
	public int eveId;

	//stats
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

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

