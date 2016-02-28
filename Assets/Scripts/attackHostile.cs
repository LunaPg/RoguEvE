using UnityEngine;
using System.Collections;

public class attackHostile : MonoBehaviour {
	public float attackSpeed;
	public float damage;
	public string type;
	float timer;
	public GameObject target;

	// Use this for initialization
	void Start () {
		damage = 4.0f;
		type = "kinetic";
	}
	
	// Update is called once per frame
	void Update () {
		if (canAttack ())
			dealDamage (target, damage, type);
	}

	void FixedUpdate () {
		timer += Time.deltaTime;
		if ( timer >= attackSpeed ) {
			timer = 0.0f;

		}
	}

	public void attack (GameObject target) {
		this.target = target;
	}

	bool canAttack () {
		return (target != null) && (timer == 0.0f);
	}

	void dealDamage (GameObject target, float damage, string type) {
		target.GetComponent<Health>().takeDamage (damage, type);
		
	}
}
