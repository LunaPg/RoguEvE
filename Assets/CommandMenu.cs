using UnityEngine;
using System.Collections;

public class CommandMenu : MonoBehaviour {
	public GameObject origin;
	public GameObject target;
	GameObject menu;
	public bool dragging = false;
	bool isOpen = false;
	public int TargetVectorPadding = 30; // do not draw target-vector if absolute distance between drone and target minus padding on both side is below zero

	// Use this for initialization
	void Start () {
		menu = gameObject;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (origin && dragging) {
			DrawTargetVector ();
		}
		if (origin && target && !isOpen) {
			openMenu (origin, target);
			DrawTargetVector ();
		}

		if (origin && target && isOpen) {
			DrawTargetVector ();
		}
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
		Debug.Log ("orbiting");
		Debug.Log (origin);
		Debug.Log (target);
		origin.SendMessage ("orbit", target);
	}

	public void cmdFire () {
		Debug.Log ("FIRE");
		Debug.Log (origin);
		Debug.Log(target);
		//origin.fire (target);
	}
		
	void DrawTargetVector () {
		LineRenderer targetLine = origin.GetComponentInChildren<LineRenderer> ();
		targetLine.SetWidth (0.5f, 0);  
		targetLine.SetPosition (0, origin.transform.position);
		if ( target ) {
			targetLine.SetPosition (1, target.transform.position);
		} else {
			targetLine.SetPosition (1, getMousePos());
		}
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

	Vector3 getMousePos () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 40;
		return Camera.main.ScreenToWorldPoint (mousePos);
	}
}
