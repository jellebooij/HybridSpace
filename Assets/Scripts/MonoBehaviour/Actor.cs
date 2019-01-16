using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	public Vector2 targetLocation;


	private void Start() {

		targetLocation = new Vector3(transform.position.x,transform.position.z);
		
	}
	private void Update() {


		transform.position = Vector2.MoveTowards(transform.position,new Vector2(targetLocation.x, targetLocation.y) , 3 * Time.deltaTime);

	}

}
