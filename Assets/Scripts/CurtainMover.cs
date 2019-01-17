using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMover : MonoBehaviour {

	public bool left;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( left){
			transform.Translate(-5 * Time.deltaTime,0,0);
		}
		else{
			transform.Translate(5 * Time.deltaTime,0,0);
		}
	}
}
