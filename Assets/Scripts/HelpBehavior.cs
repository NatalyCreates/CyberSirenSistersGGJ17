using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpBehavior : MonoBehaviour {

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
	
	void PushButton(GameObject button) {
		button.transform.Translate(- Vector3.up * 4);
	}
}
