using System.Linq;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    List<float> samples;
    public KeyCode listenTo; // = KeyCode.Space;   // TODO make configurable
    IEnumerable<double> windowed;

    public GameObject wavePrefab;

    void Start()
    {
        samples = new List<float>();

        InvokeRepeating("CreateWave", GameBalance.Instance.createWaveEveryXSec, GameBalance.Instance.createWaveEveryXSec);
    }

    void Update()
    {
        UpdateArray(Input.GetKeyDown(listenTo));
    }

    void CreateWave()
    {
        GameBalance.FreqColor color = GetCurrentWave();
        Debug.Log("Creating wave - " + color.ToString());
        GameObject wave = Instantiate(wavePrefab, this.transform.position, Quaternion.identity);
        wave.GetComponent<WaveBehavior>().waveColor = color;
    }

    private void UpdateArray(bool isClick)
    {
        if (isClick) {
            samples.Add(Time.time);
        }
        int index = samples.FindIndex(time => time < (Time.time - GameBalance.Instance.windowSeconds));
        if (index > -1) {
            samples.RemoveRange(0, index+1);
        }
        windowed = samples.Select(time => GameBalance.Instance.WindowFn(Time.time - time));
    }

    public float GetCurrentFrequency()
    {
        float freq = (float)windowed.Sum() / (float)GameBalance.Instance.windowSeconds;
        Debug.Log("Frequency = " + freq);
        return freq;
    }

    public GameBalance.FreqColor GetCurrentWave()
    {
        return GameBalance.Instance.GetColor(GetCurrentFrequency());
        /*
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
        */
    }
    // animate siren sprite
}
