using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Commander : MonoBehaviour
{
	GameObject target;
	GameObject hostile;

	GameObject origin;
	GameObject drone;


	public GameObject commandMenu;

	void Start () {
	}

	public void setOrigin (GameObject origin, GameObject drone) {
		this.origin = origin; //thumbnail
		this.drone = drone; //drone in space
		if (this.target) enableMenu ();
	}

	public void setTarget (GameObject target, GameObject hostile) {
		this.target = target; // thumbnail
		this.hostile = hostile; // rifter
		if ( this.origin ) enableMenu ();
	}

	public void execute (string command) {
		Debug.Log ("now execute command:" + command);
		if ("orbit" == command)
			orbit();
		if ("fire" == command)
			fire ();
	}

	void orbit() {
		drone.SendMessage ("orbit", hostile);
	}

	void fire() {
		drone.SendMessage ("attack", hostile);
	}

	void enableMenu () {
		commandMenu.BroadcastMessage ("enableButtons");
	}

	public void disableMenu () {
		commandMenu.BroadcastMessage ("disableButtons");
	}

	public void commandExecuted () {
		drone = null;
		origin.GetComponent<Outline> ().enabled = false;
		origin = null;

//		hostile = null;
//		target.transform.FindChild ("border").gameObject.SetActive (false);
//		target = null;
//


	}
}

