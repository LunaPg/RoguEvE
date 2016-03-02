using UnityEngine;
using System.Collections;

public class CommandOrigin : MonoBehaviour {
	public Commander commander;

	CommandMenu menu;
	targetLineController targetLine;
	public bool hovered = false;
	public bool hasOrder = false;
	public GameObject thumnail;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("CommandMenu").GetComponent<CommandMenu> ();
		targetLine = GetComponentInParent<targetLineController> ();

	}

	void OnMouseDown () {
		commander.setOrigin (thumnail, gameObject);
	}

}
