using UnityEngine;
using System.Collections;

public class PyonpyonSystem : MeSystem {

	void Start(){

	}

	void Update () {
		ForUpdate ();

		if (!jump && rigidbody.velocity.y<=0) {
			rigidbody.AddForce (transform.up * jumpForce, ForceMode.Impulse);
			jump = true;
		}

	}

}
