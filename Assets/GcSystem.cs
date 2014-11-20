﻿using UnityEngine;
using System.Collections;

public class GcSystem : MonoBehaviour{

	float deadTime = -1;
	bool falling = false;
	float timecount=0;


	// Use this for initialization
	void Start () {
	
	}
	

	// Update is called once per frame	//fixUpdate...最強
	void Update () {
		timecount+=Time.deltaTime;
		if (!falling && timecount >= deadTime && deadTime!=-1) {
			timecount = 0;
			falling = true;
			rigidbody.isKinematic = false;
			rigidbody.AddForce(new Vector3(0,0.1f,0));
		}

		if (falling && timecount>5) {
			Destroy(this.gameObject);
		}
	}

	public void SetDeadTime(float _time){
		deadTime = _time;
	}
}
