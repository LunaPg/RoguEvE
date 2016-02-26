using UnityEngine;
using System.Collections;

public class orbitAround : MonoBehaviour {
	Drone origin;
	GameObject target;
	bool isOrbiting = false;
	public Vector3 axis = Vector3.forward;
	public Vector3 desiredPosition;
	public float radius = 20.0f;
	public float radiusSpeed = 50.0f;
	public float rotationSpeed = 120.0f;

	// Use this for initialization
	void Start () {
		origin = (Drone)gameObject.GetComponent ("Drone");


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( isOrbiting == false )
			return;
		var center = target.transform;

		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 3.0f;

		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	}

	public void orbit (GameObject target) {
		Debug.Log("JOR BITE");
		Debug.Log (target);
		isOrbiting = true;
		this.target = target;
	}
}
