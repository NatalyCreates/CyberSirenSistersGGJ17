using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetShipsSunk : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Ships Sunk Got: " + GameObject.FindGameObjectWithTag("data").GetComponent<ScoreData>().GetShips().ToString());
        gameObject.GetComponent<Text>().text = GameObject.FindGameObjectWithTag("data").GetComponent<ScoreData>().GetShips().ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
