using System.Linq;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    List<float> samples;
    IEnumerable<double> windowed;

    public GameObject wavePrefab;

    KeyCode[] activeKeys;

    void Start()
    {
        samples = new List<float>();

        InvokeRepeating("CreateWave", GameBalance.Instance.createWaveEveryXSec, GameBalance.Instance.createWaveEveryXSec);

        activeKeys = (this.name == "SirenLeft" ? GameBalance.Instance.leftPlayerKeys : GameBalance.Instance.rightPlayerKeys);

        UpdateArray(IsKeyDown());
    }

    void Update()
    {
        UpdateArray(IsKeyDown());
    }

    bool IsKeyDown()
    {
        foreach(KeyCode k in activeKeys)
        {
            if (Input.GetKeyDown(k)) return true;
        }
        return false;
    }

    void CreateWave()
    {
        GameBalance.FreqColor color = GetCurrentWave();
        Vector3 start = this.name == "SirenLeft" ? new Vector3(150, 150, 0) : new Vector3(-150, 150, 0);
        GameObject wave = Instantiate(wavePrefab, start, Quaternion.identity);
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
        return freq;
    }

    public GameBalance.FreqColor GetCurrentWave()
    {
        return GameBalance.Instance.GetColor(GetCurrentFrequency());
    }
    // animate siren sprite
}
