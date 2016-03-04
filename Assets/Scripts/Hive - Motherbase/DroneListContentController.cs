using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DroneListContentController : MonoBehaviour {
	public GameObject loadingText;

	void addListItem (GameObject DroneListItem ) {
		Image image = DroneListItem.GetComponentInChildren<Image> ();
		image.sprite = Resources.Load<Sprite> ("sprites/drones/" + DroneListItem.GetComponent<Drone>().eveId);

		DroneListItem.transform.SetParent (transform, false);
		hideLoadingText ();
	}

	public void hideLoadingText () {
		loadingText.SetActive (false);
	}
}
