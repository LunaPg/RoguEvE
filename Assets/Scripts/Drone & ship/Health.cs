using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {
	public float shield;
	float shieldRegenerationTimer;
	public float armor;
	public float hull;

	public Slider shieldSlider;
	public Slider armorSlider;
	public Slider hullSlider;

	bool isDead;
	bool isDamaged;
	// Use this for initialization
	void Start () {
		isDead = false;
		isDamaged = false;

		shieldSlider.maxValue = shield;
		shieldSlider.value = shield;
		armorSlider.maxValue = armor;
		armorSlider.value = armor;
		hullSlider.maxValue = hull;
		hullSlider.value = hull;

		//setSliders ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDamaged) {
			isDamaged = false;
		}
	}

	void FixedUpdate () {
		regenerateShield ();
	}

	public void setSliders() {
		Drone drone = GetComponent<Drone> ();


	//	if (drone != null) {

			shieldSlider.maxValue = drone.shieldCapacity;
			shieldSlider.value = drone.shieldCapacity;

			armorSlider.maxValue = drone.armorHp;
			armorSlider.value = drone.armorHp;

			hullSlider.maxValue = drone.hp;
			hullSlider.value = drone.hp;
	//	}
	}

	public void setSlidersHostile() {
		Hostile hostile = GetComponent<Hostile> ();

		Debug.Log ("Hostile HP" + hostile.hp);

		shieldSlider.maxValue = hostile.shieldCapacity;
		shieldSlider.value = hostile.shieldCapacity;
		shield = hostile.shieldCapacity;

		armorSlider.maxValue = hostile.armorHp;
		armorSlider.value = hostile.armorHp;
		armor = hostile.armorHp;

		hullSlider.maxValue = hostile.hp;
		hullSlider.value = hostile.hp;
		hull = hostile.hp;
	}

	public void takeDamage (float amount, string type) {
		isDamaged = true;
		float leftOver = takeShieldDamage (amount, type);
		if ( leftOver > 0.0f ) {
			leftOver = takeArmorDamage (amount, type);
			if (leftOver > 0.0f)
				takeHullDamage (amount, type);
		}

		if (hull <= 0.0f && !isDead) {
			Die ();
		}
	}

	float takeShieldDamage (float amount, string type) {
		if (shield == 0)
			return amount;
		float leftOver = shield - amount; 
		shield -= amount; // resistances as percentage diminution
		if ( shield < 0 )
			shield = 0;
		shieldSlider.value = shield;
		if ( leftOver < 0 ) 
			return -leftOver;
		return 0;
	}

	float takeArmorDamage (float amount, string type) {
		if (armor == 0)
			return amount;
		float leftOver = armor - amount;
		armor -= amount;
		if (armor < 0)
			armor = 0;
		armorSlider.value = armor;
		if (leftOver < 0)
			return -leftOver;
		return 0;
		
	}

	void takeHullDamage (float amount, string type) {
		hull -= amount;
		if (hull < 0)
			hull = 0;
		hullSlider.value = hull;
	}

	void regenerateShield () {
		//shieldRegenerationTimer += Time.fixedTime;
		//if ( shieldRegenerationTimer >= ship.shieldRechargeRate ) {
		//	shield += ship.shieldRechargeValue;
		//}
	}

	void Die () {
		isDead = true;
		SendMessage ("Explode");
	}
}
