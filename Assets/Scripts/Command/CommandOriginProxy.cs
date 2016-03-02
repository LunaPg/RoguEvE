using UnityEngine;
using System.Collections;

public class CommandOriginProxy : MonoBehaviour {
	public GameObject drone;
	public GameObject commander;

	public void setOrigin() {
		commander.GetComponent<Commander>().setOrigin(gameObject, drone);
	}
}
