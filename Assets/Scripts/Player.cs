﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    List<float> samples;
    KeyCode listenTo = KeyCode.LeftShift;   // TODO make configurable

    public GameObject wavePrefab;

    void Start()
    {
        samples = new List<float>();

        InvokeRepeating("CreateWave", 1, 1);//GameBalance.Instance.createWaveEveryXSec, GameBalance.Instance.createWaveEveryXSec);
    }

    void Update()
    {
        UpdateArray(Input.GetKeyDown(listenTo));
    }

    void CreateWave()
    {
        //Debug.Log("Creating wave - " + GetCurrentWave().ToString());
        Debug.Log("Creating wave");
        GameObject wave = Instantiate(wavePrefab, this.transform.position, Quaternion.identity);
        wave.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 1);
    }

    private void UpdateArray(bool isClick)
    {
        if (isClick) {
            samples.Add(Time.time);
        }
        int index = samples.FindIndex(time => time < (Time.time - GameBalance.Instance.windowSeconds));
        if (index > -1) {
            samples.RemoveRange(0, index);
        }
    }

    public float GetCurrentFrequency()
    {
        return samples.Count / GameBalance.Instance.windowSeconds;
    }

    public GameBalance.FreqColor GetCurrentWave()
    {
//        return GameBalance.
        GameBalance.Instance.ColorThresholds[0] = 1.0f;
        float freq = GetCurrentFrequency();
        for(int i=0; i<GameBalance.Instance.ColorThresholds.Length && i<GameBalance.Instance.freqColors.Length; i++)
        {
            // Find the frequency 
            if(freq < GameBalance.Instance.ColorThresholds[i])
            {
                return GameBalance.Instance.freqColors[i];
            }
        }
        // Return the last color
        return GameBalance.Instance.freqColors[GameBalance.Instance.freqColors.Length - 1];
    }
    // animate siren sprite
}
