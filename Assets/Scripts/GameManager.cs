using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject playerLeft;
    public GameObject playerRight;

    public AudioSource baseLayer;
    public AudioSource baseLayerWaves;
    public AudioSource layer1;
    public AudioSource layer2;
    public AudioSource layer3a;
    public AudioSource layer3b;
    public AudioSource layer4;
    public AudioSource layer5;
    public AudioSource layer6;
    public AudioSource layer7;

    public GameObject shipPrefab;

    private Random rand = new Random();
    void Awake () {
        Instance = this;
    }

    void Start()
    {
        CreateShipLoop();
    }

	void Update () {
        // call gen waves at a certain rate (every 0.5 sec?)
        GenerateWaves();

        // create ships
        //CreateShip();
    }

    void CreateShipLoop()
    {
        CreateShip();
        Invoke("CreateShipLoop", Random.Range(GameBalance.Instance.shipRateMin, GameBalance.Instance.shipRateMax));
    }

    void CreateShip()
    {
        int rndPos = Random.Range(0, GameBalance.Instance.possibleShipStartPosX.Count);
        Vector3 shipPos = new Vector3(GameBalance.Instance.possibleShipStartPosX[rndPos], 0, 0);
        GameObject newShip = Instantiate(shipPrefab, shipPos, Quaternion.identity) as GameObject;
        // init a prefab ship with random ShipType
        // also random position from list
        
        newShip.GetComponent<BoatBehavior>().leftSideColor = (GameBalance.FreqColor)Random.Range(1, 3);
        //newShip.GetComponent<BoatBehavior>().rightSideColor = (GameBalance.FreqColor)Random.Range(1, 3);
        newShip.GetComponent<BoatBehavior>().rightSideColor = newShip.GetComponent<BoatBehavior>().leftSideColor;
        Debug.Log("Created ship - left color: " + newShip.GetComponent<BoatBehavior>().leftSideColor.ToString() + ", right color: " + newShip.GetComponent<BoatBehavior>().rightSideColor);
        newShip.GetComponent<SpriteRenderer>().color = GameBalance.Instance.actualColors[newShip.GetComponent<BoatBehavior>().leftSideColor];
    }

    void GenerateWaves()
    {
        // get the freq of each player

        float leftFreq = playerLeft.GetComponent<Player>().GetCurrentFrequency();
        float rightFreq = playerRight.GetComponent<Player>().GetCurrentFrequency();

        GameBalance.FreqColor leftColor = GameBalance.Instance.GetColor(leftFreq);
        
        // create a wave object with the color of that freq in the right/left corner

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

    public void LoseGame()
    {
        Debug.Log("LOSER");
    }
}
