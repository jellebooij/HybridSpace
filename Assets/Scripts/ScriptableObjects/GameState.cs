using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct GameState{

	public float duration;
	public bool actor1InLight;
	public bool actor2InLight;
	public bool actor3InLight;
	public bool actor4InLight;
	public DecorEnum decor;
	public Sounds music;


	public bool Compare(GameState other){
		if(other.actor1InLight == actor1InLight && other.actor2InLight == actor2InLight && other.actor3InLight == actor3InLight  && other.actor4InLight == actor4InLight && decor == other.decor && music == other.music){
			return true;
		}
		return false;
	}

}
