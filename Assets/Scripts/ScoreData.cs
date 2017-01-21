using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour {

    public int shipsSunk;
    public int timePlayed;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GetShips()
    {
        return shipsSunk;
    }

    public int GetTime()
    {
        int timeSurvived = GameBalance.Instance.Level_time - timePlayed - 1;
        return timeSurvived;
    }

    public void ResetData()
    {
        shipsSunk = 0;
        timePlayed = 0;
    }

	void Start () {
        shipsSunk = 0;
        timePlayed = 0;
    }
	
	public void ScoreDataUpdateTime(int time)
    {
        timePlayed = time;
    }

    public void ScoreDataUpdateShip(int ships)
    {
        shipsSunk = ships;
    }
}
