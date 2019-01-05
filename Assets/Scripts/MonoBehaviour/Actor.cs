using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	[SerializeField]
	Material activatedMat;

	[SerializeField]

	Material deactivatedMat;
	MeshRenderer rend;

	public Vector2 targetLocation;

	public float rotateSpeed = 100.0f;

	private void Start() {

		rend = GetComponent<MeshRenderer>();
		targetLocation = new Vector3(transform.position.x,transform.position.z);
		
	}
	private void Update() {


		transform.position = Vector3.MoveTowards(transform.position,new Vector3(targetLocation.x,transform.position.y,targetLocation.y) , 3 * Time.deltaTime);

		Quaternion targetRotation;

		if(transform.position != new Vector3(targetLocation.x,transform.position.y,targetLocation.y))
			targetRotation = Quaternion.LookRotation(new Vector3(targetLocation.x,transform.position.y,targetLocation.y));
		else
			targetRotation = Quaternion.Euler(0, 180, 0);


		transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, rotateSpeed * Time.deltaTime);

	}

}
