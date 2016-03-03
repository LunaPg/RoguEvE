using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DroneListContentController : MonoBehaviour {

	void addListItem (GameObject DroneListItem ) {
		Image image = DroneListItem.GetComponentInChildren<Image> ();
		image.sprite = Resources.Load<Sprite> ("sprites/drones/" + DroneListItem.GetComponent<Drone>().eveId);

		DroneListItem.transform.SetParent (gameObject.transform, false);
	}
}
