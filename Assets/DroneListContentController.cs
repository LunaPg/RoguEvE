using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DroneListContentController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addListItem (GameObject DroneListItem ) {
		RectTransform pos = DroneListItem.GetComponent<RectTransform> ();
		//pos.transform.localPosition;
		Image image = DroneListItem.GetComponentInChildren<Image> ();
		image.overrideSprite = Resources.Load<Sprite> ("sprites/drones/" + DroneListItem.GetComponent<Drone>().eveId);

		DroneListItem.transform.SetParent (gameObject.transform, false);
	}
}
