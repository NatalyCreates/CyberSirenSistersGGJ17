using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameObject playerLeft;
    public GameObject playerRight;

    public GameObject shipPrefab;

    public GameObject[] shipPrefabsByColor;

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
        //int rndPos = Random.Range(0, GameBalance.Instance.possibleShipStartPosX.Count);
        //Vector3 shipPos = new Vector3(GameBalance.Instance.possibleShipStartPosX[rndPos], 200, 0);
        Vector3 shipPos = new Vector3(Random.Range(GameBalance.Instance.shipMinXPos, GameBalance.Instance.shipMaxXPos), 500, 0);

        /*
        GameBalance.ShipType shipType = (GameBalance.ShipType)Random.Range(
            0, System.Enum.GetValues(typeof(GameBalance.ShipType)).Length);

        Debug.Log("shipType=" + shipType);
        */
        //GameObject newShip = Instantiate(shipPrefabsByColor[(int)shipType], shipPos, Quaternion.identity) as GameObject;


        // init a prefab ship with random ShipType
        // also random position from list

        int leftSideColor = Random.Range(1, 4);
        int rightSideColor = Random.Range(1, 4);
        Debug.Log("colors: " + leftSideColor + " " + rightSideColor);
        int shipTypeNum = 3 * (leftSideColor-1) + rightSideColor-1;
        GameObject newShip = Instantiate(shipPrefabsByColor[shipTypeNum], shipPos, Quaternion.identity) as GameObject;
        newShip.GetComponent<BoatBehavior>().leftSideColor = (GameBalance.FreqColor)leftSideColor;
        newShip.GetComponent<BoatBehavior>().rightSideColor = (GameBalance.FreqColor)rightSideColor;

        Debug.Log("Created ship - left color: " + newShip.GetComponent<BoatBehavior>().leftSideColor.ToString() + ", right color: " + newShip.GetComponent<BoatBehavior>().rightSideColor);



        //newShip.GetComponent<SpriteRenderer>().color = GameBalance.Instance.actualColors[newShip.GetComponent<BoatBehavior>().leftSideColor];

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
