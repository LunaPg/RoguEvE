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

	public void SetOrigin (GameObject origin) {
		this.origin = origin;
	}

	public void SetTarget (GameObject target) {
		if (!origin)
			return;
		this.target = target;
		origin.GetComponent<targetLineController> ().target = target;
	}

	public void cmdOrbit() {
		origin.SendMessage ("orbit", target);
	}

	public void cmdFire () {
		origin.SendMessage ("attack", target);
	}

	public void openMenu () {
		if (!origin || !target)
			return;
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
