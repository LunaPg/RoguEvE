using UnityEngine;
using System.Collections;

public class CombatText : MonoBehaviour {
	public GameObject Texts;

	// Use this for initialization
	void Start () {
		string text1 = Texts.GetComponent<Texts> ().get ("AI_FIGHT_START_1");
		set(text1);
		string text2 = Texts.GetComponent<Texts> ().get ("AI_FIGHT_START_2");
		append ('\n' + text2);

	}

	public void set (string text) {
		GetComponent<TextMesh> ().text = text;
	}
	
	public void append (string text) {
		GetComponent<TextMesh> ().text += text;
	}

	public void winCombat () {
		int index = Random.Range (1, 3);
		string text = Texts.GetComponent<Texts> ().get ("AI_FIGHT_WIN_" + index);
		set (text);
	}
}
