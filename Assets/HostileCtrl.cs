using UnityEngine;
using System.Collections;

public class HostileCtrl : MonoBehaviour {
	GameObject hostileObject;
	public bool initialized = false;
	CrestService crest;

	// Use this for initialization
	void Start () {
		crest = GameObject.FindGameObjectWithTag ("CREST").GetComponent<CrestService> ();
		crest.GetRifter ();
		hostileObject = transform.FindChild ("Rifter").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (!initialized && crest.gotRifter) {
			initialized = true;

			Hostile hostile = hostileObject.GetComponent<Hostile> ();
			hostile.set (crest.rifter);
		}
	}
}
