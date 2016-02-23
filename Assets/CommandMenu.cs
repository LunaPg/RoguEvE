using UnityEngine;
using System.Collections;

public class CommandMenu : MonoBehaviour {
	public GameObject drone;
	public GameObject target;
	bool dragging;
	public bool isOpen = false;
	public Vector3 lineStart;
	public Vector3 lineEnd;
	GameObject line;
	LineRenderer lr;
	public int TargetVectorPadding = 30; // do not draw target-vector if absolute distance between drone and target minus padding on both side is below zero


	// Use this for initialization
	void Start () {
		dragging = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (dragging == true || drone != null) {
			lineStart = drone.transform.position;
			if (target != null)
				lineEnd = target.transform.position;
			else
				lineEnd = getMousePos ();
			DrawTargetVector ();	
		}

	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			drone = gameObject;
			lineStart = drone.transform.position;
			dragging = true;
		}
	}

	void OnMouseDrag () {
		if (dragging == true) {
			lineEnd = getMousePos ();
		}
	}

	void OnMouseUp () {
		if (dragging == true) {
			dragging = false;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				target = hit.transform.gameObject;
				openMenu ();
			}

		}
	}

	void cmdOrbit() {
		//drone.orbit();
	}

	void cmdFire () {
		//drone.fire (target);
	}
		
	void DrawTargetVector () {
		if (line == null) {
			line = new GameObject ();
			lr = line.AddComponent<LineRenderer> ();
		}

		lr.SetWidth (.2f, .2f);
		Debug.Log ("orig:" + lineStart);
		Debug.Log ("dest:" + lineEnd);
		lr.SetPosition(0, lineStart);
		lr.SetPosition(1, lineEnd); 
	}

	void openMenu () {
		Debug.Log ("open menu around " + target.name);
		isOpen = true;
	}

	void closeMenu () {
		isOpen = false;
	}

	Vector3 getMousePos () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 40;
		return Camera.main.ScreenToWorldPoint (mousePos);
	}
}
