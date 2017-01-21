using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    AudioSource[] sources;

    void Start()
    {

        sources = gameObject.GetComponentsInChildren<AudioSource>();
        Debug.Log(sources.Length.ToString());
        foreach (AudioSource s in sources)
        {
            Debug.Log(s.name);
            s.volume = 0f;
            s.Play();
        }

        sources[0].volume = 1f;


        //gameObject.GetComponent<AudioSource>();
        //AudioSource baseLayerClip = gameObject.AddComponent(AudioSource);

        //ManageMusic();
    }

    void Update()
    {
        ManageMusic();
    }
    void ManageMusic()
    {
        GameBalance.FreqColor color1 = GameManager.Instance.playerLeft.GetComponent<Player>().GetCurrentWave();
        GameBalance.FreqColor color2 = GameManager.Instance.playerRight.GetComponent<Player>().GetCurrentWave();

        GameBalance.FreqColor[] coloredPair = GetOrderedColorPair(color1, color2);

        if (coloredPair[0] == GameBalance.FreqColor.White)
        {
            sources[0].volume = 1f;
            sources[1].volume = 0f;
            sources[2].volume = 0f;
            sources[3].volume = 0f;
            sources[4].volume = 0f;
            sources[5].volume = 0f;
            sources[6].volume = 0f;
        }
        else if (coloredPair[0] == GameBalance.FreqColor.Blue)
        {
            sources[0].volume = 1f;
            sources[1].volume = 1f;
            sources[2].volume = 0f;
            sources[3].volume = 0f;
            sources[4].volume = 0f;
            sources[5].volume = 0f;
            sources[6].volume = 0f;
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Yellow) && (coloredPair[1] <= GameBalance.FreqColor.Blue))
        {
            sources[0].volume = 1f;
            sources[1].volume = 1f;
            sources[2].volume = 1f;
            sources[3].volume = 0f;
            sources[4].volume = 0f;
            sources[5].volume = 0f;
            sources[6].volume = 0f;
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Yellow) && (coloredPair[1] == GameBalance.FreqColor.Yellow))
        {
            sources[0].volume = 1f;
            sources[1].volume = 1f;
            sources[2].volume = 1f;
            sources[3].volume = 1f;
            sources[4].volume = 0f;
            sources[5].volume = 0f;
            sources[6].volume = 0f;
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] <= GameBalance.FreqColor.Blue))
        {
            sources[0].volume = 1f;
            sources[1].volume = 1f;
            sources[2].volume = 0f;
            sources[3].volume = 0f;
            sources[4].volume = 1f;
            sources[5].volume = 0f;
            sources[6].volume = 0f;
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] <= GameBalance.FreqColor.Yellow))
        {
            sources[0].volume = 1f;
            sources[1].volume = 0f;
            sources[2].volume = 0f;
            sources[3].volume = 0f;
            sources[4].volume = 0f;
            sources[5].volume = 1f;
            sources[6].volume = 0f;
        }
        else if ((coloredPair[0] == GameBalance.FreqColor.Red) && (coloredPair[1] == GameBalance.FreqColor.Red))
        {
            sources[0].volume = 1f;
            sources[1].volume = 0f;
            sources[2].volume = 0f;
            sources[3].volume = 0f;
            sources[4].volume = 0f;
            sources[5].volume = 0f;
            sources[6].volume = 1f;
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
