using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void Play () {
		PushButton(GameObject.Find("PlayButton"));
        SceneManager.LoadScene("integration_scene");
    }

    public void ShowHelp () {
		PushButton(GameObject.Find("HelpButton"));
        SceneManager.LoadScene("Help");
    }

    public void Exit () {
#if UNITY_WEBGL
        // do nothing
#else
        PushButton(GameObject.Find("ExitButton"));
        Application.Quit();
#endif
    }

	void PushButton(GameObject button) {
		button.transform.Translate(- Vector3.up * 4);
	}
}
