using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject playerLeft;
    public GameObject playerRight;

    void Awake () {
        Instance = this;
    }

	void Update () {
		// call gen waves at a certain rate (every 0.5 sec?)
        

	}

    void GenerateWaves()
    {
        // get the freq of each player

        float leftFreq = playerLeft.GetComponent<Player>().GetCurrentFrequency();
        float rightFreq = playerRight.GetComponent<Player>().GetCurrentFrequency();

        //GameBalance.Instance.GetColor(leftFreq);
        
        // create a wave object with the color of that freq in the right/left corner

    }

    void ManageMusic(float leftFreq, float rightFreq)
    {
        //GameBalance.Instance.frequencyRangesByColor[];
        GameBalance.FreqColor color1 = GameBalance.Instance.GetColor(leftFreq);
        GameBalance.FreqColor color2 = GameBalance.Instance.GetColor(rightFreq);


        GameBalance.FreqColor[] coloredPair = GetOrderedColorPair(color1, color2);

        if (coloredPair[0] == GameBalance.FreqColor.White)
        {
            // base sound
        }
        else if (coloredPair[0] == GameBalance.FreqColor.Blue)
        {
            // base sound + first layer
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Yellow) && (coloredPair[1] <= GameBalance.FreqColor.Blue))
        {
            // next layer
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Yellow) && (coloredPair[1] == GameBalance.FreqColor.Yellow))
        {
            // next layer
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] <= GameBalance.FreqColor.Blue))
        {
            // next layer
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] <= GameBalance.FreqColor.Yellow))
        {
            // next layer
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] == GameBalance.FreqColor.Red))
        {
            // next layer
        }
    }

    GameBalance.FreqColor[] GetOrderedColorPair(GameBalance.FreqColor color1, GameBalance.FreqColor color2)
    {
        GameBalance.FreqColor[] orderedPair = new GameBalance.FreqColor[2];
        if (color1 == color2)
        {
            orderedPair[0] = color1;
            orderedPair[1] = color2;
        }
        else if (color1 > color2)
        {
            orderedPair[0] = color1;
            orderedPair[1] = color2;
        }
        else
        {
            orderedPair[0] = color2;
            orderedPair[1] = color1;
        }
        return orderedPair;
    }

    public void LoseGame()
    {
        Debug.Log("LOSER");
    }
}
