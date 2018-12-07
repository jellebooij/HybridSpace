using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimeLine : ScriptableObject {

	// Use this for initialization
	public GameState[] states;

	float t;

	int currentIndex;

	public void Reset(){
		t = 0;
		currentIndex = 0;
	}

	public void UpdateTimeline() {

		t += Time.deltaTime;

		if(currentIndex + 1 < states.Length){
			if(states[currentIndex].duration <= t){
				currentIndex++;
				t = 0;
			}
		}
		
	}
	public GameState GetCurrentState(){
	
		return states[currentIndex];
	}
	

}
