using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehavior : MonoBehaviour {

    public GameBalance.FreqColor rightSideColor;
    public GameBalance.FreqColor leftSideColor;

    bool leftSideHit = false;
    bool rightSideHit = false;
    bool scoreUpdated = false;
    float speed;

    private Vector3 rotateOnSink;

    void Start () {
        // Randomize rotation on boat hit
        rotateOnSink.x = Random.Range(-0.1f, 0.1f);
        rotateOnSink.y = Random.Range(-0.2f, 0.2f);
        rotateOnSink.z = Random.Range(-2, 2);
        speed = Random.Range(GameBalance.Instance.shipMinSpeed, GameBalance.Instance.shipMaxSpeed);
    }

    void Update () {
        // move
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1*speed);

        // hit points? later

        // has collider

        if (rightSideHit && leftSideHit)
        {
            // ship is hit!
            // sink
            // animate
            // kill ship

            AnimateSinking();
            if (!scoreUpdated)
            {
                Score.Instance.UpdateScore();
                scoreUpdated = true;
                MusicManager.Instance.PlaySunkShipEffect();
                Handheld.Vibrate();
            }
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 5); // TODO destroy time param
        }
	}

    void AnimateSinking()
    {
        // Rotate
        this.GetComponent<Transform>().Rotate(rotateOnSink);
        // Fade out
        Color c = this.GetComponent<SpriteRenderer>().material.color;
        c.a = c.a - 0.02f;  // Fade rate
        this.GetComponent<SpriteRenderer>().material.color = c;
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
