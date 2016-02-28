using UnityEngine;
using System.Collections;

public class lockPosition : MonoBehaviour {
	public GameObject reference;
	public Vector3 centerToCenter;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = reference.transform.position + centerToCenter;
	}
}
