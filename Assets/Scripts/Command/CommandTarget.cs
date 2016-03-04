using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CommandTarget : MonoBehaviour {
	CommandMenu menu;
	bool hovered;
	public Commander commander;
	public GameObject hostile;

	// Use this for initialization
	void Start () {
		GameObject menuObject = GameObject.FindGameObjectWithTag ("CommandMenu");
		menu = menuObject.GetComponent<CommandMenu> ();
	}

	public void setTarget() {
		commander.setTarget (gameObject, hostile);
	}

}
