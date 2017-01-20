using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  List<float> samples;
  KeyCode listenTo;

	void Start () {
        samples = new List<float>();
  }

	void Update () {
      UpdateArray(Input.GetKeyDown(listenTo))
  }

  private void UpdateArray(isClick) {
      if (isClick) {
          samples.Add(Time.time);
      }
      samples.RemoveWhere(time => time < (Time.time - GameBalance.Instance.windowSeconds)
  }

  public float GetCurrentFrequency()
  {
      return samples.Count / GameBalance.Instance.windowSeconds;
  }

  // animate siren sprite
}
