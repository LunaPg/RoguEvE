using UnityEngine;
using System.Collections;

public class CommandOrigin : MonoBehaviour {
	CommandMenu menu;
	targetLineController targetLine;
	public bool hovered = false;
	public bool hasOrder = false;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("CommandMenu").GetComponent<CommandMenu> ();
		targetLine = GetComponentInParent<targetLineController> ();

	}

	void OnMouseDown () {
		startExecutingCommand ();
	}

	public void startExecutingCommand() {
		if (!hovered) {
			return;
		}
		menu.SetOrigin (gameObject);
		menu.dragging = true;
		targetLine.origin = gameObject;
	}

	void OnMouseOver () {
		hovered = true;
	}

	void OnMouseExit () {
		hovered = false;
	}

	public void executeCommand (string commandName) {
		Debug.Log (commandName);
		hasOrder = true;
	}

}
