using UnityEngine;
using System.Collections;

public class CommandTarget : MonoBehaviour {
	CommandMenu menu;
	bool hovered;

	// Use this for initialization
	void Start () {
		GameObject menuObject = GameObject.FindGameObjectWithTag ("CommandMenu");
		menu = menuObject.GetComponent<CommandMenu> ();
	}

	void OnMouseUp () {
		if (!hovered)
			return;
		
		menu.SetTarget (gameObject);
		menu.openMenu ();
	}

	void OnMouseOver () {
		hovered = true;
	}

}
