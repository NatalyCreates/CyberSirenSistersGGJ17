using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreqBar : MonoBehaviour {

    public GameBalance.PlayerType player;
    public GameObject playerObj;
    Text text;
    Image image;

	void Start () {
        playerObj = GameManager.Instance.playerLeft;
        text = GetComponentsInChildren<Text>()[0];
        image = GetComponentsInChildren<Image>()[0];
	}

	void Update () {
		// get the current frequency of this player and display that % of the bar

        // change color to the color that corresponds to this frequency
        float freq = playerObj.GetComponent<Player>().GetCurrentFrequency();
        image.fillAmount = freq / 10;
        text.text = "Current Freq: " + freq.ToString();
        Debug.Log("Current Freq: " + freq.ToString());
	}
}
