﻿using UnityEngine;
using System.Collections;

public class OnDroneListItemClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClick () {
		SendMessageUpwards ("selected", GetComponent<Drone> ());
	}
}
