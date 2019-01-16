using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TimeLine : ScriptableObject {

	public GameState[] states;
	float t;
	int currentIndex;

	public void Reset(){
		t = 0;
		currentIndex = 0;
	}

	public bool UpdateTimeline() {

		t += Time.deltaTime;

		if(currentIndex + 1 < states.Length){
			if(states[currentIndex].duration <= t){
				currentIndex++;
				t = 0;
				return true;
			}
		}
		return false;
	}

	public bool nextState(){
		currentIndex++;
		t = 0;
		return true;
	}
	public GameState GetCurrentState(){
	
		return states[currentIndex];
	}
	

}
