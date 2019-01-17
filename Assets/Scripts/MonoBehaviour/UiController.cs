using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiController : MonoBehaviour {

	public Text timeUi;
	public Text crowdMeter;

	public Text finalScore;

	public GameObject deathScreen;

	public Image actorsActivation;
	public Image decorActivation;
	public Image musicActivation;

	public Manager manager;

	private void Update() {
		UpdateUI(manager.timeline.GetCurrentState(), manager.actualState);	
	}


	void UpdateUI(GameState state, GameState current){

		timeUi.text = ((int)(manager.timer)).ToString();
		crowdMeter.text = ((int)manager.score).ToString();
		finalScore.text = "Score: " + ((int)manager.score).ToString();


		if(manager.deathState){
			deathScreen.SetActive(true);
			finalScore.gameObject.SetActive(true);

		}
		else{
			deathScreen.SetActive(false);
			finalScore.gameObject.SetActive(false);
		}

	}
}
