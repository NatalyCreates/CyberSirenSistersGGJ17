using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject playerLeft;
    public GameObject playerRight;

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
        Vector3 shipPos = new Vector3(GameBalance.Instance.possibleShipStartPosX[rndPos], 200, 0);
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

    public void LoseGame()
    {
        Debug.Log("LOSER");
    }
}
