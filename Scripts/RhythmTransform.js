#pragma strict

class RhythmTransform {
  var samples: float[];

  function Update(isClick: boolean) {
    var time = Time.time;
    updateArray(time, isClick);
    return this.calculateFrequency()
  }

  /**
  * Clicks per Second = clicks / windowSeconds
  */
  function calculateFrequency() {
    var clicks = this.samples.length;
    return clicks / this.windowSeconds;
  }

  function updateArray(time, isClick) {
    if (isClick) {
      samples.Push(time));
    }
    while (this.samples.length > 0 && this.shouldDropSample(this.samples[0])) {
      this.samples.Shift();
    }
  }

  function shouldDropSample(sample, time) {
    return sample < (time - this.windowSeconds)
  }

  function RhythmTransform(windowSeconds: float) {
    this.windowSeconds = windowSeconds;
    this.samples = new Array();
  }
}
