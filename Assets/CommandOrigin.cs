using UnityEngine;
using System.Collections;

public class CommandOrigin : MonoBehaviour {
	CommandMenu menu;
	LineRenderer targetLine;
	bool hovered = false;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("CommandMenu").GetComponent<CommandMenu> ();
		targetLine = gameObject.GetComponentInChildren<LineRenderer> ();
	}

	void OnMouseDown () {
		if (!hovered)
			return;
		menu.origin = gameObject;
		menu.dragging = true;
	}

	void OnMouseOver () {
		hovered = true;
	}

	void OnMouseExit () {
		hovered = false;
	}

}
