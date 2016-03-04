using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommandButton : MonoBehaviour {

	void Start () {
	}

	public void enableButtons () {
		gameObject.GetComponent<Button> ().interactable = true;
	}

	public void disableButtons () {
		gameObject.GetComponent<Button> ().interactable = false;
	}
}
