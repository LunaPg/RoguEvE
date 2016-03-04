using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiveTexts : MonoBehaviour {
	public GameObject okButton;
	public GameObject readyButton;
	public GameObject team;
	public string HIVE_INSTRUCTIONS_1;
	public string HIVE_INSTRUCTIONS_2;
	public string AI_HOSTILE_DETECETD;
	bool hasSeenInstructions;

	// Use this for initialization
	void Start () {
		readyButton.GetComponent<Button> ().interactable = false;
		hasSeenInstructions = false;
		set(HIVE_INSTRUCTIONS_1, true);
	}

	void set (string text) {
		GetComponent<Text> ().text = text;
	}

	void set (string text, bool activateButton) {
		GetComponent<Text> ().text = text;
		okButton.GetComponent<Button> ().interactable = activateButton;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTeamReady ()) {
			ennemyDetected ();
		}
	}

	public void nextDialog () {
		if (!hasSeenInstructions) {
			hasSeenInstructions = true;

			set(HIVE_INSTRUCTIONS_2, true);
			okButton.SetActive (false);
		}
	}

	public bool isTeamReady () {
		int nbAssigned = 0;
		foreach (Drone drone in team.GetComponentsInChildren<Drone>())
			nbAssigned += (drone.raw != null) ? 1 : 0;
		return nbAssigned == 5;
	}

	public void ennemyDetected() {
		set (AI_HOSTILE_DETECETD, false);
		readyButton.GetComponent<Button> ().interactable = true;
	}
}
