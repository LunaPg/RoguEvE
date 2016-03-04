using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneMain : MonoBehaviour {
	public Team team;

	public void loadScene() {
		team.SendMessage ("save");
		SceneManager.LoadScene ("main");
	}
}
