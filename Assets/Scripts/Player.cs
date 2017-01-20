using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    List<float> samples;

	void Start () {
        samples = new List<float>();
    }

	void Update () {
	    // check input from keyboard or gamepad
        // calculate frequency (with moving window)

	}

    public float GetCurrentFrequency()
    {
        return 1f;
    }

    // animate siren sprite
}
