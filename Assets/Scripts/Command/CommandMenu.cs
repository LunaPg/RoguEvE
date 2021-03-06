﻿using UnityEngine;
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
		if (this.origin ) {
			if (!origin.GetComponent<CommandOrigin> ().hasOrder) {
				targetLineController line = origin.GetComponent<targetLineController> ();
				line.origin = null;
				line.hide ();
			}
		}
		this.origin = origin;
	}

	public void SetTarget (GameObject target) {
		if (!origin)
			return;
		this.target = target;
		origin.GetComponent<targetLineController> ().target = target;
	}

	public void openMenu () {
		if (!origin || !target)
			return;
		isOpen = true;
		menu.BroadcastMessage ("enableButtons");
	}

	public void openMenu (GameObject origin, GameObject target) {
		this.origin = origin;
		this.target = target;
		isOpen = true;
		menu.BroadcastMessage ("enableButtons");
	}

	public void closeMenu () {
		isOpen = false;
		dragging = false;
		if (origin && target) {
			if (!origin.GetComponent<CommandOrigin> ().hasOrder) {
				origin.GetComponent<targetLineController> ().hide ();
			}
		}
	
		origin = null;
		target = null;
		menu.BroadcastMessage ("disableButtons");
	}

}
