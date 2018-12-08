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


	public bool CompareAll(GameState other){
		if(CompareActors(other) && CompareDecor(other) && CompareMusic(other)){
			return true;
		}
		return false;
	}

	public bool CompareActors(GameState other){
		if(other.actor1InLight == actor1InLight && other.actor2InLight == actor2InLight && other.actor3InLight == actor3InLight){
			return true;
		}
		return false;
	}

	public bool CompareDecor(GameState other){
		if(decor == other.decor){
			return true;
		}
		return false;
	}

	public bool CompareMusic(GameState other){
		if(music == other.music){
			return true;
		}
		return false;
	}


}
