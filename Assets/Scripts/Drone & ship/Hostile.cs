using UnityEngine;
using System.Collections;

public class Hostile : MonoBehaviour {
	public GameObject CombatTexts;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Explode () {
		Debug.Log ("Hostile explodes...");
		//Destroy (gameObject);
		CombatTexts.SendMessage("winCombat");
	}
}
