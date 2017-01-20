using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour {

    public GameBalance.FreqColor rightSideColor;
    public GameBalance.FreqColor leftSideColor;

    bool leftSideHit = false;
    bool rightSideHit = false;

    void Start () {

	}

	void Update () {
        // move
        float speed = Random.Range(GameBalance.Instance.shipMinSpeed, GameBalance.Instance.shipMaxSpeed);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1*speed);

        // hit points? later

        // has collider

        if (rightSideHit && leftSideHit)
        {
            // ship is hit!
            // sink
            // animate
            // kill ship
            //gameObject.SetActive(false);
            AnimateSinking();
            Score.Instance.UpdateScore();
            Destroy(gameObject);
        }
	}

    void AnimateSinking()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("OnTriggerEnter2D Boat");
        if (other.tag == "waveRight")
        {
            if (other.GetComponent<WaveBehavior>().waveColor == rightSideColor)
            {
                rightSideHit = true;
                Debug.Log("rightSideColor = waveColor = " + rightSideColor);
            }
            else
            {
                rightSideHit = false;
            }
        }
        if (other.tag == "waveLeft")
        {
            if (other.GetComponent<WaveBehavior>().waveColor == leftSideColor)
            {
                leftSideHit = true;
                Debug.Log("leftSideColor = waveColor = " + leftSideColor);
            }
            else
            {
                leftSideHit = false;
            }
        }
        if (other.tag == "beach")
        {
            GameManager.Instance.LoseGame();
        }
    }
}
