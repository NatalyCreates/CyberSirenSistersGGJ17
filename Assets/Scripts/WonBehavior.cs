using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Back () {
		PushButton(GameObject.Find("Button"));
        SceneManager.LoadScene("Menu");
	}

	public void PlayAgain () {
		PushButton(GameObject.Find("PlayButton"));
		SceneManager.LoadScene("integration_scene");
	}
	
	void PushButton(GameObject button) {
		button.transform.Translate(- Vector3.up * 4);
	}
}
