using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorFx : MonoBehaviour {

	public TimeLine t;
	public ParticleSystem Actor1fx;
	public ParticleSystem Actor2fx;
	public ParticleSystem Actor3fx;
	public ParticleSystem Actor4fx;

	private void Update() {
		

		if(t.GetCurrentState().actor1InLight){
			Actor1fx.emissionRate = 50;
		}
		else{
			Actor1fx.emissionRate = 0;
		}


		if(t.GetCurrentState().actor2InLight){
			Actor2fx.emissionRate = 50;
		}
		else{
			Actor2fx.emissionRate = 0;
		}

		if(t.GetCurrentState().actor3InLight){
			Actor3fx.emissionRate = 50;
		}
		else{
			Actor3fx.emissionRate = 0;
		}

	}
}
