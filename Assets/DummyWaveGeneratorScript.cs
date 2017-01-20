using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWaveGeneratorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveInput()
    {
        Debug.Log("Received input - " + this.name);
    }
}
