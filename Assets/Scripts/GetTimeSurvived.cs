using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimeSurvived : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int t = GameObject.FindGameObjectWithTag("data").GetComponent<ScoreData>().GetTime();
        gameObject.GetComponent<Text>().text = (t / 60).ToString("00") + ":" + (t % 60).ToString("00");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
