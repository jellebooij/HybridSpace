using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class Manager : MonoBehaviour {

	public TimeLine timeline;

	//[HideInInspector]
	public GameState actualState;

	[HideInInspector]
	public GameState currentState;

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

	int latestSound;


	public GameObject light1;
	public GameObject light2;

	public GameObject light3;

	AudioSource src;
	public AudioSource src2;
	public AudioSource src3;

	bool beenon1,beenon2,beenon3;


	public ArduinoInput inp;


	public Transform[] positions; 
	public int score;



	//SerialPort sp = new SerialPort("COM3", 9600);

	private void Start() {	
		
		timeline.Reset();	
		src = GetComponent<AudioSource>();

		currentState = timeline.GetCurrentState();
		timer = currentState.duration;
		decor = DecorEnum.decor1;
		crowd.Happiness = 100;
		actorInLight = 2;
		audioIndex = 0;

		//sp.Open();
		//sp.ReadTimeout = 1;

	}


	private void Update() {

		timer -= Time.deltaTime;
		GetActualState();
		currentState = timeline.GetCurrentState();
	

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

		if(!inp.working){
			if(Input.GetKeyDown(KeyCode.Keypad4) || inp.switch1){
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
		}	
		
		if(Input.GetKeyDown(KeyCode.Keypad7)){
			actorInLight = 1;
		}

		if(Input.GetKeyDown(KeyCode.Keypad8)){
			actorInLight = 2;
		}
	

		if(Input.GetKeyDown(KeyCode.Keypad9)){
			actorInLight = 3;
		}

		light1.SetActive(false);
		light2.SetActive(false);
		light3.SetActive(false);

		if(actorInLight == 1){
			light1.SetActive(true);
		}
		if(actorInLight == 2){
			light2.SetActive(true);
		}
		if(actorInLight == 3){
			light3.SetActive(true);
		}
	


		bool isCorrect = timeline.GetCurrentState().CompareAll(actualState);

		if(timeline.UpdateTimeline()) 
		{
			if(!isCorrect)
				crowd.Happiness -= 33.33333f;


				
				timer = currentState.duration;
		}

		a1.targetLocation = new Vector2(positions[(int)currentState.actor1Position].position.x, positions[(int)currentState.actor1Position].position.y);
		a2.targetLocation = new Vector2(positions[(int)currentState.actor2Position].position.x, positions[(int)currentState.actor2Position].position.y);
		a3.targetLocation = new Vector2(positions[(int)currentState.actor3Position].position.x, positions[(int)currentState.actor3Position].position.y);

		if(crowd.Happiness <= 0){

			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
			timeline.Reset();

		}

		if(inp.working){
			decor = (DecorEnum)(inp.row1 - 1);
			actorInLight = inp.row2;

			if(inp.switch3 && !beenon1){

					src.PlayOneShot(clip1);
					beenon1 = true;

			}

			if(inp.switch2 && !beenon2){

					src2.PlayOneShot(clip2);
					beenon2 = true;

			}

			if(inp.switch1 && !beenon3){
				
					src3.PlayOneShot(clip3);
					beenon3 = true;

			}



			if(!inp.switch3){
				src.Stop();
				audioIndex = 0;
				beenon1 = false;


			}
			if(!inp.switch2){
				src2.Stop();
				audioIndex = 0;
				beenon2 = false;

			}
			if(!inp.switch1){
				src3.Stop();
				audioIndex = 0;
				beenon3 = false;
			}
			
		}


		if(currentState.CompareAll(actualState)){
			timeline.nextState();
			score += (int)timer;
			currentState = timeline.GetCurrentState();
			timer = currentState.duration;
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
