using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	[SerializeField]
	Material activatedMat;

	[SerializeField]

	Material deactivatedMat;

	public bool actived;

	MeshRenderer rend;

	public Vector2 targetLocation;

	private void Start() {

		rend = GetComponent<MeshRenderer>();
		targetLocation = new Vector3(transform.position.x,transform.position.z);
		
	}
	private void Update() {
		if(actived){
			rend.material = activatedMat;
		}
		else{
			rend.material = deactivatedMat;
		}

		transform.position = Vector3.MoveTowards(transform.position,new Vector3(targetLocation.x,transform.position.y,targetLocation.y) , 2 * Time.deltaTime);

	}

}
