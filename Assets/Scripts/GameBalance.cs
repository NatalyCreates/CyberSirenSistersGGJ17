using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBalance : MonoBehaviour {

    public static GameBalance Instance;

    public enum PlayerType { Left, Right };

    public enum ShipType { BlueBlue, BlueYellow, BlueRed, YellowBlue, YellowYellow, YellowRed, RedBlue, RedYellow, RedRed };

    public enum FreqColor { White, Blue, Yellow, Red };

    public float[] ColorThresholds;

    public FreqColor[] freqColors;

    public Dictionary<FreqColor, Color> actualColors;

    public List<float> possibleShipStartPosX;

    public float windowSeconds;

	public int Level_time;

    public float createWaveEveryXSec;

    public float shipRateMin, shipRateMax;
    public int shipMinXPos, shipMaxXPos;
    public float shipMinSpeed, shipMaxSpeed;

    public double raiseLambda;
    public double decayLambda;

    public struct FreqRange
    {
        public FreqRange(float startF, float endF)
        {
            start = startF;
            end = endF;
        }
        float start;
        float end;
    }

    public Dictionary<FreqColor, float> frequencyThresholdsByColor;

    void Awake () {
        Instance = this;

        createWaveEveryXSec = 0.5f;
        windowSeconds = 1f;
		Level_time = 31;
        raiseLambda = 8.0;
        decayLambda = 1.0f;

        shipRateMin = 1f;
        shipRateMax = 5f;

        shipMinXPos = -550;
        shipMaxXPos = 550;

        shipMinSpeed = 25;
        shipMaxSpeed = 75;

        /*
        possibleShipStartPosX = new List<float>();
        possibleShipStartPosX.Add(200);
        possibleShipStartPosX.Add(400);
        possibleShipStartPosX.Add(600);
        possibleShipStartPosX.Add(800);
        possibleShipStartPosX.Add(1000);
        */

        actualColors = new Dictionary<FreqColor, Color>();
        actualColors[FreqColor.White] = new Color(255, 255, 255);
        actualColors[FreqColor.Blue] = new Color(0, 0, 255);
        actualColors[FreqColor.Yellow] = new Color(0, 255, 0);
        actualColors[FreqColor.Red] = new Color(255, 0, 0);

        frequencyThresholdsByColor = new Dictionary<FreqColor, float>();
        frequencyThresholdsByColor[FreqColor.White] = 0f;
        frequencyThresholdsByColor[FreqColor.Blue] = 0.3f;
        frequencyThresholdsByColor[FreqColor.Yellow] = 1.6f;
        frequencyThresholdsByColor[FreqColor.Red] = 3.8f;
    }

    public FreqColor GetColor(float freq)
    {
        if (freq >= frequencyThresholdsByColor[FreqColor.Red])
        {
            return FreqColor.Red;
        }
        else if (freq >= frequencyThresholdsByColor[FreqColor.Yellow])
        {
            return FreqColor.Yellow;
        }
        else if (freq >= frequencyThresholdsByColor[FreqColor.Blue])
        {
            return FreqColor.Blue;
        }
        else
        {
            return FreqColor.White;
        }
    }

    public double WindowFn(float timeDelta) {
        return 1.4 * (1 - Math.Pow(Math.E, -raiseLambda * timeDelta))
            * Math.Pow(Math.E, -decayLambda * timeDelta);
    }
}
