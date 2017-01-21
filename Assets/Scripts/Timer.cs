using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static Timer Instance;
    public int curtime;
    Text timerText;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
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
        // TODO do whatever when curtime==0
        Invoke("UpdateTimerLoop", 1);
    }
}
