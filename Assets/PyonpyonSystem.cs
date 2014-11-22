using UnityEngine;
using System.Collections;

public class PyonpyonSystem : MeSystem {

	void Updata(){
		ForUpdate ();

		if (!jump) {
			rigidbody.AddForce (transform.up * jumpForce, ForceMode.Impulse);
			jump = true;
		}
	}

}
