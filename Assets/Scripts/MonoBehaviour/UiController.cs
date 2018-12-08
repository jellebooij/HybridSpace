using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour {

	public Text timeUi;
	public Text crowdMeter;

	public Image actorsActivation;
	public Image decorActivation;
	public Image musicActivation;

	public Manager manager;

	private void Update() {
		UpdateUI(manager.timeline.GetCurrentState(), manager.actualState);	
	}


	void UpdateUI(GameState state, GameState current){

		timeUi.text = manager.timer.ToString();
		crowdMeter.text = ((int)manager.crowd.Happiness).ToString();


		if(current.CompareActors(state))
			actorsActivation.color = Color.green;
		else
			actorsActivation.color = Color.red;


		if(current.CompareDecor(state))
			decorActivation.color = Color.green;
		else
			decorActivation.color = Color.red;


		if(current.CompareMusic(state))
			musicActivation.color = Color.green;
		else
			musicActivation.color = Color.red;

	}
}
