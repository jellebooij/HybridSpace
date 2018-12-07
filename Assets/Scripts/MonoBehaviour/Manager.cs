using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public Text textCrowd;
	public TimeLine timeline;
	GameState actualState;

	public GameObject sLight;

	public Crowd crowd;

	public Decor decorobject;

	public float happinessChange;

	DecorEnum decor;

	public Actor a1;
	public Actor a2;
	public Actor a3;


	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	int audioIndex;


	Vector3 targetLightPos;

	AudioSource src;



	private void Start() {
		crowd.Happiness = 50;
		src = GetComponent<AudioSource>();
		decor = DecorEnum.decor1;	
	}


	private void Update() {
		GetActualState();

		if(timeline.GetCurrentState().Compare(actualState)){
			crowd.Happiness += happinessChange * Time.deltaTime;
		}
		else{
			crowd.Happiness -= happinessChange * Time.deltaTime;
		}

		if(Input.GetKeyDown(KeyCode.Keypad1)){
			decor = (DecorEnum)1;
		}

		if(Input.GetKeyDown(KeyCode.Keypad2)){
			decor = (DecorEnum)2;
		}

		if(Input.GetKeyDown(KeyCode.Keypad3)){
			decor = (DecorEnum)3;
		}





		decorobject.decor1.SetActive(false);
		decorobject.decor2.SetActive(false);
		decorobject.decor3.SetActive(false);
		decorobject.decor4.SetActive(false);



		if(decor == (DecorEnum)1){
			decorobject.decor1.SetActive(true);
		}
		if(decor == (DecorEnum)2){
			decorobject.decor2.SetActive(true);
		}
		if(decor == (DecorEnum)3){
			decorobject.decor3.SetActive(true);
		}


		if(Input.GetKeyDown(KeyCode.Keypad4)){
			if(audioIndex == 1){
				src.Stop();
				audioIndex = 0;
			}
			else{
				src.Stop();
				src.PlayOneShot(clip1);
				audioIndex = 1;
			}
		}

		if(Input.GetKeyDown(KeyCode.Keypad5)){
			if(audioIndex == 2){
				src.Stop();
				audioIndex = 0;
			}
			else{
			src.Stop();
			src.PlayOneShot(clip2);
			audioIndex = 2;

			}
		}

		if(Input.GetKeyDown(KeyCode.Keypad6)){
			if(audioIndex == 3){

				src.Stop();
				audioIndex = 0;
			}

			else{
			src.Stop();
			src.PlayOneShot(clip3);
			audioIndex = 3;

			}






		}		
		
		
		
		if(Input.GetKeyDown(KeyCode.Keypad7)){
			targetLightPos = a1.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.Keypad8)){
			targetLightPos = a2.transform.position;
		}

		if(Input.GetKeyDown(KeyCode.Keypad9)){
			targetLightPos = a3.transform.position;
		}

		Quaternion tRot = Quaternion.LookRotation(targetLightPos - sLight.transform.position);

		sLight.transform.rotation = Quaternion.RotateTowards(sLight.transform.rotation,tRot,Time.deltaTime * 30f);
		
		

		
		textCrowd.text = ((int)crowd.Happiness).ToString();
	}



	void GetActualState(){

		actualState.actor1InLight = a1.actived;
		actualState.actor2InLight = a2.actived;
		actualState.actor3InLight = a3.actived;
		actualState.decor = decor;

	}

}
