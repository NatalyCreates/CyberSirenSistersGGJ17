using System.Collections;
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
        float freq = playerObj.GetComponent<Player>().GetCurrentFrequency();
        image.fillAmount = freq / 5f;
        //image.color = GameBalance.Instance.actualColors[GameBalance.Instance.GetColor(freq)];
	}
}
