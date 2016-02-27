using UnityEngine;
using System.Collections;

public class targetLineController : MonoBehaviour {
	public GameObject origin;
	public GameObject target;
	LineRenderer targetLine;
	//public Vector3 offset;// do not draw target-vector if absolute distance between drone and target minus padding on both side is below zero

	// Use this for initialization
	void Start () {
		targetLine = gameObject.GetComponentInChildren<LineRenderer> ();
		//offset = new Vector3 (1.5f, 1.5f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (origin){
			DrawLine ();
			Debug.Log (origin.transform.position);
		}	
	}

	void orbit (GameObject origin, GameObject target) {
		this.origin = origin;
		this.target = target;
	}

	void attack (GameObject origin, GameObject target) {
		this.origin = origin;
		this.target = target;
	}

	void DrawLine () {
		targetLine.SetWidth (0.3f, 0);  
		targetLine.SetPosition (0, origin.transform.position);
		if ( target ) {
			targetLine.SetPosition (1, target.transform.position);
		} else {
			targetLine.SetPosition (1, getMousePos());
		}
	}

	Vector3 getMousePos () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 40;
		return Camera.main.ScreenToWorldPoint (mousePos);
	}
		
}
