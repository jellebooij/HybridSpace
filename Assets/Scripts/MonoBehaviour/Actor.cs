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

	private void Start() {
		rend = GetComponent<MeshRenderer>();
	}
	private void Update() {
		if(actived){
			rend.material = activatedMat;
		}
		else{
			rend.material = deactivatedMat;
		}
	}

}
