using UnityEngine;
using System.Collections;

public class targetLineController : MonoBehaviour {

	LineRenderer targetLine;
	// Use this for initialization
	void Start () {
		targetLine = gameObject.GetComponentInChildren<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
