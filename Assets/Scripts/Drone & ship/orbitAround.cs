using UnityEngine;
using System.Collections;

public class orbitAround : MonoBehaviour {
	Drone origin;
	GameObject target;
	bool isOrbiting = false;
	bool isApproaching = false;
	public Vector3 axis = Vector3.forward;
	public Vector3 desiredPosition;
	public float radius = 5.0f;
	public float radiusSpeed = 30.0f;
	public float rotationSpeed = 50.0f;

	// Use this for initialization
	void Start () {
		origin = gameObject.GetComponent <Drone>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if ( !isOrbiting && !isApproaching )
			return;
		var center = target.transform;

		if (isApproaching) {
			Vector3 offset = new Vector3 (-origin.transform.position.x + radius, 0, 0);

			if (Vector3.Distance(transform.position, target.transform.position) <= radius ) {
				isApproaching = false;
				isOrbiting = true;
			}
			transform.position = Vector3.MoveTowards (origin.transform.position, offset+target.transform.position, Time.deltaTime * /*ship's speed */ 2 );
			//transform.position = (transform.position - center.position).normalized * radius + center.position;
		}
		if (isOrbiting) {
			transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
			desiredPosition = (transform.position - center.position).normalized * radius + center.position;
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
		}
	}

	public void orbit (GameObject target) {
		isApproaching = true;
		this.target = target;
	}

	public void stopOrbiting () {
		isOrbiting = false;
	}
}
