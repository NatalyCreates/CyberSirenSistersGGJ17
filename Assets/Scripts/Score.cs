using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static Score Instance;
	internal int score;
	Text scoreText;

	// Use this for initialization
	void Awake () {
		Instance = this;
		scoreText = GetComponent<Text>();
	}

	void Update() {
		scoreText.text = score.ToString();
	}

	public void UpdateScore() {
		score += 1;
	}
}
