using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {
	
	public void StartGame(){
		SceneManager.LoadScene ("MotherBase");
	}

	public void QuitGame(){
		Application.Quit ();
	}	

}