﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreqBar : MonoBehaviour {

    public GameBalance.PlayerType player;
    public GameObject playerObj;
    Image image;

	void Start () {
        if (player == GameBalance.PlayerType.Left) {
            playerObj = GameManager.Instance.playerLeft;
        } else {
            playerObj = GameManager.Instance.playerRight;
        }
        image = GetComponentsInChildren<Image>()[0];
	}

	void Update () {
		// get the current frequency of this player and display that % of the bar

        // change color to the color that corresponds to this frequency
        float freq = playerObj.GetComponent<Player>().GetCurrentFrequency();
        image.fillAmount = freq / 10f;
        image.color = GameBalance.Instance.actualColors[GameBalance.Instance.GetColor(freq)];
	}
}
