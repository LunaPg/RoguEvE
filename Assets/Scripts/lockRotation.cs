using UnityEngine;
using System.Collections;

public class lockRotation : MonoBehaviour {
	Quaternion lockedRotation;
	// Use this for initialization
	void Start () {
		lockedRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = lockedRotation;
	}
}
