using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWaveGeneratorScript : MonoBehaviour {
    public enum WaveColor { None, Red, Blue, Yellow, Purple };
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ReceiveInput()
    {
        Debug.Log("Received input - " + this.name);
    }

    public WaveColor GetWave()
    {
        if (Random.value < 0.1)
            return WaveColor.Red;
        else
            return WaveColor.None;
    }
}
