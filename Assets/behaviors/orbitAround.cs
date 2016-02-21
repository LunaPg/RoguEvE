using UnityEngine;
using System.Collections;

public class orbitAround : MonoBehaviour {
	GameObject ship;
	Drone drone;
	public Transform center;
	public Vector3 axis = Vector3.forward;
	public Vector3 desiredPosition;
	public float radius = 20.0f;
	public float radiusSpeed = 50.0f;
	public float rotationSpeed = 120.0f;

	// Use this for initialization
	void Start () {
		drone = (Drone)gameObject.GetComponent ("Drone");
		ship = GameObject.FindWithTag ("ship");
		center = ship.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 3.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( drone.isOrbiting == false )
			return;
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
	
	}
}
