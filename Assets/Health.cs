using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {
	public float maxHealth;
	public float health;
	public Slider healthSlider;
	public float flashSpeed = 5f;
	public Color flashColour = new Color (1f, 0f, 0f, 0.1f);

	bool isDead;
	bool isDamaged;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		isDead = false;
		isDamaged = false;
		healthSlider = GetComponentInChildren<Slider> ();
		healthSlider.maxValue = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDamaged) {
			isDamaged = false;
		}
	}

	void FixedUpdate () {
	}

	public void takeDamage (float amount, string type) {
		isDamaged = true;
		health -= amount;
		healthSlider.value = health;
		if (health <= 0 && !isDead) {
			Die ();
		}
	}

	void Die () {
		isDead = true;
		SendMessage ("Explode");
	}
}
