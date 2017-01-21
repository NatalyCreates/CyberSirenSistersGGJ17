using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehavior : MonoBehaviour {

    public GameBalance.FreqColor waveColor;
    float destroyTime = 15.0f;
    public float xSpeed, ySpeed;
    public enum Side { Left, Right };

    public Side side;

    void Start () {
        Color color = Color.white;
        if(waveColor == GameBalance.FreqColor.White)
        {
            color = Color.white;
        }
        switch (waveColor)
        {
            case GameBalance.FreqColor.White:
                //color = Color.white;
                color = new Color(255, 255, 255, 0);
                break;
            case GameBalance.FreqColor.Red:
                color = Color.red;
                break;
            case GameBalance.FreqColor.Blue:
                color = Color.blue;
                break;
            case GameBalance.FreqColor.Yellow:
                color = Color.yellow;
                break;
        }
        this.GetComponent<SpriteRenderer>().color = color;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
	}

	void Update () {
        Destroy(gameObject, destroyTime);
    }
}
