using System.Collections;
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

    public float createWaveEveryXSec;

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

    public Dictionary<FreqColor, FreqRange> frequencyRangesByColor;

    void Awake () {
        Instance = this;

        possibleShipStartPosX = new List<float>();
        possibleShipStartPosX.Add(200);
        possibleShipStartPosX.Add(400);
        possibleShipStartPosX.Add(600);
        possibleShipStartPosX.Add(800);
        possibleShipStartPosX.Add(1000);

        actualColors = new Dictionary<FreqColor, Color>();
        actualColors[FreqColor.White] = new Color(255, 255, 255);
        actualColors[FreqColor.Blue] = new Color(0, 0, 255);
        actualColors[FreqColor.Yellow] = new Color(0, 255, 0);
        actualColors[FreqColor.Red] = new Color(255, 0, 0);

        frequencyRangesByColor = new Dictionary<FreqColor, FreqRange>();
        frequencyRangesByColor[FreqColor.White] = new FreqRange(0f, 0.5f);
        frequencyRangesByColor[FreqColor.Red] = new FreqRange(0.5f, 1f);
        frequencyRangesByColor[FreqColor.Yellow] = new FreqRange(1f, 2f);
        frequencyRangesByColor[FreqColor.Blue] = new FreqRange(2f, 4f);
    }

    public FreqColor GetColor(float freq)
    {
        // actually return the right thing
        return FreqColor.Red;
    }
}
