using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesCreate : MonoBehaviour {

    public GameObject wavesGenerator;
    public GameObject wave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DummyWaveGeneratorScript.WaveColor wavecolor = wavesGenerator.GetComponent<DummyWaveGeneratorScript>().GetWave();
        if(wavecolor != DummyWaveGeneratorScript.WaveColor.None)
        {
            Debug.Log("Creating wave");
            wave.transform.position = new Vector3(0, 0, 0);
            wave.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 1);
        }
	}
}
