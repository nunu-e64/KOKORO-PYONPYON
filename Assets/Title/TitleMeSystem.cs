using UnityEngine;
using System.Collections;

public class TitleMeSystem : MeSystem {

	// Use this for initialization
	void Start () {
		reborn = true;
	}


	bool flag = true;
	float timeCount = 0;
	//float jumpForce = 70;
	//float extraG = 6;
	
	// Update is called once per frame
	void Update () {
		ForUpdate ();

		timeCount += Time.deltaTime;
		if (Input.anyKey){
			flag = false;
			timeCount = 0;
		}

		if (!flag && timeCount > 4.0f) {
			flag = true;
		}

		if (flag && !jump && rigidbody.velocity.y<=0) {
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			jump = true;
		}

	}
}
