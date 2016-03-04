using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class attackDrone : MonoBehaviour
{
	public List<GameObject> attackers = new List<GameObject>();
	public float tmpDamage = 5;
	public string tmpDamageType = "em";
	public float tmpAttackSpeed = 2.0f;
	public float timer;
	// Use this for initialization
	void Start ()
	{
		tmpDamage = 4.0f;
		tmpDamageType = "explosive";
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (attackers.Count == 0)
			return;

		GameObject attacker = attackers [0];

		if (attacker.GetComponent<Health> ().isDead)
			attackers.Remove (attacker);

		if ( canAttack() )
			attack(attackers [0]);
	}

	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= tmpAttackSpeed) {
			timer = 0.0f;
		}
	}

	public void attackedBy (GameObject drone) {
		if (!attackers.Contains (drone))
			attackers.Add (drone);
	}

	public bool canAttack() {
		return attackers.Count > 0 && timer == 0.0f;
	}

	public void attack(GameObject drone) {
		if (!drone)
			return;
		Health droneLife = drone.GetComponent<Health> ();

		Hostile rifter = gameObject.GetComponent<Hostile> ();
		droneLife.takeDamage (tmpDamage, tmpDamageType);
	}


}

