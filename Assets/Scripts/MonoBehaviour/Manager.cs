using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

	public TimeLine timeline;

	//[HideInInspector]
	public GameState actualState;

	[HideInInspector]
	public GameState currentState;

	public GameObject sLight;

	public Crowd crowd;

	public Decor decorobject;

	DecorEnum decor;

	public Actor a1;
	public Actor a2;
	public Actor a3;


	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	int audioIndex;

	int actorInLight;


	public float timer;
	float timerOffset;


	Vector3 targetLightPos;

	AudioSource src;


	public Transform[] positions; 



	private void Start() {	
		
		timeline.Reset();	
		src = GetComponent<AudioSource>();

		currentState = timeline.GetCurrentState();
		timer = currentState.duration;
		decor = DecorEnum.decor1;
		crowd.Happiness = 100;
		actorInLight = 2;
	

	}


	private void Update() {

		timer -= Time.deltaTime;
		GetActualState();
	

		if(Input.GetKeyDown(KeyCode.Keypad1)){
			decor = (DecorEnum)0;
		}

		if(Input.GetKeyDown(KeyCode.Keypad2)){
			decor = (DecorEnum)1;
		}

		if(Input.GetKeyDown(KeyCode.Keypad3)){
			decor = (DecorEnum)2;
		}



		decorobject.decor1.SetActive(false);
		decorobject.decor2.SetActive(false);
		decorobject.decor3.SetActive(false);



		if(decor == (DecorEnum)0){
			decorobject.decor1.SetActive(true);
		}
		if(decor == (DecorEnum)1){
			decorobject.decor2.SetActive(true);
		}
		if(decor == (DecorEnum)2){
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
			targetLightPos = positions[0].position;
			actorInLight = 1;
		}

		if(Input.GetKeyDown(KeyCode.Keypad8)){
			targetLightPos = positions[1].position;
			actorInLight = 2;
		}

		if(Input.GetKeyDown(KeyCode.Keypad9)){
			targetLightPos = positions[2].position;
			actorInLight = 3;
		}

		Quaternion tRot = Quaternion.LookRotation(targetLightPos - sLight.transform.position);

		sLight.transform.rotation = Quaternion.RotateTowards(sLight.transform.rotation,tRot,Time.deltaTime * 30f);

		bool isCorrect = timeline.GetCurrentState().CompareAll(actualState);

		if(timeline.UpdateTimeline()) 
		{
			if(!isCorrect)
				crowd.Happiness -= 33.33333f;


				currentState = timeline.GetCurrentState();
				timer = currentState.duration;
		}

		a1.targetLocation = new Vector2(positions[(int)currentState.actor1Position].position.x, positions[(int)currentState.actor1Position].position.z);
		a2.targetLocation = new Vector2(positions[(int)currentState.actor2Position].position.x, positions[(int)currentState.actor2Position].position.z);
		a3.targetLocation = new Vector2(positions[(int)currentState.actor3Position].position.x, positions[(int)currentState.actor3Position].position.z);

		if(crowd.Happiness <= 0){

			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
			timeline.Reset();

		}
	}



	public void GetActualState(){

		actualState.actor1InLight = false;
		actualState.actor2InLight = false;
		actualState.actor3InLight = false;

		if(actorInLight == 1)
			actualState.actor1InLight = true;

		if(actorInLight == 2)
			actualState.actor2InLight = true;
		
		if(actorInLight == 3)
			actualState.actor3InLight = true;

		actualState.decor = (DecorEnum)decor;
		actualState.music = (Sounds)audioIndex;

	}

}
