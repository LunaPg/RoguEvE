using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DroneListContentController : MonoBehaviour {
	public GameObject loadingText;
	public GameObject brokenScrollView;

	void addListItem (GameObject DroneListItem ) {
		Image image = DroneListItem.GetComponentInChildren<Image> ();
		image.sprite = Resources.Load<Sprite> ("sprites/drones/" + DroneListItem.GetComponent<Drone>().eveId);

		DroneListItem.transform.SetParent (transform, false);
		hideLoadingText ();
		resizeDroneList ();
	}

	public void hideLoadingText () {
		loadingText.SetActive (false);
	}

	public void resizeDroneList () {
		brokenScrollView.GetComponent<RectTransform> ().sizeDelta = new Vector2 (527, 528);
	}
}
