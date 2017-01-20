using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputReceiverScript : MonoBehaviour {
    public GameObject leftPlayer;
    public GameObject rightPlayer;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftPlayer.GetComponent<DummyWaveGeneratorScript>().ReceiveInput();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            rightPlayer.GetComponent<DummyWaveGeneratorScript>().ReceiveInput();
        }
    }
}
