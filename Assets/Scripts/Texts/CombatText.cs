using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {
	public GameObject scoopButton;
	public string AI_FIGHT_START_1;
	public string AI_FIGHT_START_2;
	public string AI_FIGHT_WIN_1;
	public string AI_FIGHT_WIN_2;
	public string AI_FIGHT_WIN_3;
	public string AI_FIGHT_LOOSE;
	// Use this for initialization
	void Start () {
		set(AI_FIGHT_START_1);
		append ('\n' + AI_FIGHT_START_2);
	}

	public void set (string text) {
		GetComponent<Text> ().text = text;
	}
	
	public void append (string text) {
		GetComponent<Text> ().text += text;
	}

	public void winCombat () {
		int index = Random.Range (1, 3);

		if (index == 1)
			set (AI_FIGHT_WIN_1);
		if (index == 2)
			set (AI_FIGHT_WIN_2);
		if (index == 3)
			set (AI_FIGHT_WIN_3);

		scoopButton.SetActive (true);
	}
}
