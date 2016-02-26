using UnityEngine;
using System.Collections;

public class CommandTarget : MonoBehaviour {
	public GameObject target;
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
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			target = hit.transform.gameObject;
			menu.target = target;
		}
	}

	void OnMouseOver () {
		hovered = true;
	}

	void OnCmdExecuted () {
		target = null;
	}
}
