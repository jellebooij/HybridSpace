using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour {

	public bool fail;

	public Sprite on;
	public Sprite off;

	SpriteRenderer rend;

	private void Start() {
		rend = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if(fail){
			rend.sprite = on;
		}
		else{
			rend.sprite = off;
		}
	}
}
