using UnityEngine;
using System.Collections;

public class SecondPlayerSystem : MeSystem {

	void Start(){
		keyUp = KeyCode.W;
		keyDown = KeyCode.S;
		keyLeft = KeyCode.A;
		keyRight = KeyCode.D;
		keyJump = KeyCode.LeftShift;
		keyJump2 = KeyCode.LeftControl;

		Begin ();
	}

}
