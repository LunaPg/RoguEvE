using UnityEngine;
using System.Collections;

public class OnDroneListItemClick : MonoBehaviour {
	public void onClick () {
		SendMessageUpwards ("selected", GetComponent<Drone> ());
	}
}
