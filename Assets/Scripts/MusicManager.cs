using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    void Start()
    {

        AudioSource[] sources = gameObject.GetComponentsInChildren<AudioSource>();
        Debug.Log(sources.Length.ToString());
        foreach (AudioSource s in sources)
        {
            Debug.Log(s.name);
            s.volume = 1f;
            s.Play();
        }

        sources[0].volume = 1f;
        sources[1].volume = 1f;


        //gameObject.GetComponent<AudioSource>();
        //AudioSource baseLayerClip = gameObject.AddComponent(AudioSource);

        //ManageMusic();
    }
    void ManageMusic(float leftFreq, float rightFreq)
    {

        // music

        GameBalance.FreqColor color1 = GameBalance.Instance.GetColor(leftFreq);
        GameBalance.FreqColor color2 = GameBalance.Instance.GetColor(rightFreq);

        GameBalance.FreqColor[] coloredPair = GetOrderedColorPair(color1, color2);

        if (coloredPair[0] == GameBalance.FreqColor.White)
        {
            //baseMusic.volume = 1f;
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

}
