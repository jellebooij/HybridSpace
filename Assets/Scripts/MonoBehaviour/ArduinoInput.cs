using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour {


	public int row1,row2;
	public bool switch1,switch2,switch3;
	//SerialPort sp = new SerialPort("COM4",9600);
	int[] returnValue = new int[9]; 

	public bool working;
	
	
	void Start () {
		//sp.Open();
		//sp.ReadTimeout = 50;
	}
	

	void Update () {

		

	//if(sp.IsOpen){
	//
	//	try{

	//		byte[] bytes = new byte[9];
	//	
	//		returnValue = ParseOutput(sp.ReadLine());
	//		


	//	}
	//	catch{

	//	}
	//}


		string str = "";

		for(int i = 0; i < 9; i++){
			str += returnValue[i].ToString() + " ";
		}

		Debug.Log(str);

		switch1 = false;
		switch2 = false;
		switch3 = false;

		if(returnValue[0] == 1){
			row1 = 3;
		}
		if(returnValue[3] == 1){
			row1 = 2;
		}
		if(returnValue[6] == 1){
			row1 = 1;
		}
		if(returnValue[1] == 1){
			row2 = 3;
		}
		if(returnValue[4] == 1){
			row2 = 2;
		}
		if(returnValue[7] == 1){
			row2 = 1;
		}
		if(returnValue[2] == 1){
			switch1 = true;
		}
		if(returnValue[5] == 1){
			switch2 = true;
		}
		if(returnValue[8] == 1){
			switch3 = true;
		}


	}

	int[] ParseOutput(string output){

		int[] returnValue = new int[9]; 

		char[] splitted = output.ToCharArray();
		
		for(int i = 0; i < 9; i++){
			returnValue[i] = (int)char.GetNumericValue(splitted[i]);
		}

		return returnValue;

	}



}
