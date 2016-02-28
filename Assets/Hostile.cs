using UnityEngine;
using System.Collections;

public class Hostile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Health> ().maxHealth = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Explode () {
		Debug.Log ("Hostile explodes...");
		Destroy (gameObject);
	}
}
