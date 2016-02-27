using UnityEngine;
using System.Collections;

public class CommandMenu : MonoBehaviour {
	public GameObject origin;
	public GameObject target;
	GameObject menu;
	public bool dragging = false;
	bool isOpen = false;

	// Use this for initialization
	void Start () {
		menu = gameObject;
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	public void SetTarget (GameObject target) {
		this.target = target;
		origin.GetComponentInChildren<targetLineController> ().target = target;
	}
	void OnMouseUp () {
		if (origin && dragging) {
			dragging = false;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				target = hit.transform.gameObject;
				GameObject menu = GameObject.FindGameObjectWithTag ("CommandMenu");
				menu.GetComponent<CommandMenu> ().openMenu (origin, target);
			}

		}
	}

	public void cmdOrbit() {
		origin.SendMessage ("orbit", target);
	}

	public void cmdFire () {
		origin.SendMessage ("attack", target);
	}

	public void openMenu () {
		isOpen = true;
		menu.GetComponent<CanvasGroup> ().alpha = 1;
	}

	public void openMenu (GameObject origin, GameObject target) {
		this.origin = origin;
		this.target = target;
		isOpen = true;
		menu.GetComponent<CanvasGroup> ().alpha = 1;
	}

	public void closeMenu () {
		isOpen = false;
		dragging = false;
		origin = null;
		target = null;
		menu.GetComponent<CanvasGroup> ().alpha = 0;
	}
}
