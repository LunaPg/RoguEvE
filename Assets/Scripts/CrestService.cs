using UnityEngine;
using System.Collections;

public class CrestService : MonoBehaviour {

    public string url = "https://public-crest.eveonline.com";
    public WWW www;

    // Use this for initialization
    // Check if CREST Online
    IEnumerator Start(){
        www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            Debug.Log("Is OK" + www.text);
        }
        else {
            Debug.Log("is NOT OK" + www.error);

        }
       // Renderer renderer = GetComponent<Renderer>();
       // renderer.material.mainTexture = www.texture;
    }

    // Get Drone Specs
    IEnumerator getDroneSpecs(string id) {
        www = new WWW(url + "/types/" + id);
        yield return www;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
