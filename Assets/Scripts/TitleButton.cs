using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {

	void OnGUI(){
		if (GUILayout.Button ("Start")) {
			StartGame ();
		} else if (GUILayout.Button ("Quit")) {
			QuitGame ();
		}

	}
	
	public void StartGame(){
		SceneManager.LoadScene ("MotherBase");
	}

	public void QuitGame(){
		Application.Quit ();
	}	

}