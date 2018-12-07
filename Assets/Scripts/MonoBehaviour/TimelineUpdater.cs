using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineUpdater : MonoBehaviour {

	public TimeLine line;
	private void Start() {
		line.Reset();
	}
	void Update () {
		line.UpdateTimeline();
	}
}
