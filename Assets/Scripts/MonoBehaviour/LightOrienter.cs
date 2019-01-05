using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrienter : MonoBehaviour {

	[SerializeField]
	Actor[] actors;

	[SerializeField]

	float spotRadius;

	void Start () {
		
	}
	
	void Update () {
		transform.rotation = Quaternion.LookRotation(Camera.main.ScreenPointToRay(Input.mousePosition).direction);

		for(int i = 0; i < actors.Length; i++){

			float d = 1 - Vector3.Dot(( actors[i].transform.position - transform.position).normalized, transform.forward);
			
		}

	}
}
