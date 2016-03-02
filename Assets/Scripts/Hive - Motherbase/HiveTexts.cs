using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiveTexts : MonoBehaviour {
	public GameObject Texts;
	public GameObject okButton;
	string instruc1;
	string instruc2;
	string ennemyDetected;
	bool hasSeenInstructions;

	// Use this for initialization
	void Start () {
		hasSeenInstructions = false;

//		instruc1 = Texts.GetComponent<Texts> ().get ("HIVE_INSTRUCTIONS_1");
//
//		GetComponent<Text> ().text = instruc1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
	}

	public void nextDialog () {
		if (!hasSeenInstructions) {
			instruc2 = Texts.GetComponent<Texts> ().get ("HIVE_INSTRUCTIONS_2");
			GetComponent<Text> ().text = instruc2;
			hasSeenInstructions = true;
			okButton.SetActive (false);
		}
	}
}
