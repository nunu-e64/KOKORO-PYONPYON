using UnityEngine;
using System.Collections;

public class PyonpyonSystem : MeSystem {

	void Start(){
		Begin ();
	}

	void Update () {
		ForUpdate ();

		if (TitleSystem.selectMode==1 && !jump && rigidbody.velocity.y<=0) {
			rigidbody.AddForce (transform.up * jumpForce, ForceMode.Impulse);
			jump = true;
		}

	}

}
