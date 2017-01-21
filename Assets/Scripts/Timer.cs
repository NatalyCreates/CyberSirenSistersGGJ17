using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public static Timer Instance;
    internal int curtime;
    Text timerText;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
		curtime = GameBalance.Instance.Level_time;
        timerText = GetComponent<Text>();
        UpdateTimerLoop();
    }

    void Update()
    {
        timerText.text = (curtime / 60).ToString("00") + ":" + (curtime % 60).ToString("00");
    }

    void UpdateTimerLoop()
    {
        curtime--;
		if (curtime == 0) {

            GameObject.FindGameObjectWithTag("data").GetComponent<ScoreData>().ScoreDataUpdateShip(GameObject.FindGameObjectWithTag("score").GetComponent<Score>().score);
            GameObject.FindGameObjectWithTag("data").GetComponent<ScoreData>().ScoreDataUpdateTime(GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>().curtime);

            SceneManager.LoadScene("Won");
		}
        Invoke("UpdateTimerLoop", 1);
    }
}
