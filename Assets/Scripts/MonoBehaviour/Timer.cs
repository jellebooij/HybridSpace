using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text t;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t.text = ((int)(Time.time)).ToString();
	}
}
