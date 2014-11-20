using UnityEngine;
using System.Collections;

public class TitleMeSystem : MeSystem {

	// Use this for initialization
	void Start () {
		GUIText text = GameObject.Find ("MyText").GetComponent<GUIText>();
		text.transform.position = new Vector3 (0, 0, 0);
		text.text = "↑Forward";
	}


	bool flag = false;
	float timeCount = 0;
	//float jumpForce = 70;
	//float extraG = 6;

	void OnGUI(){
		GUI.color = Color.black;
		GUI.Label (new Rect (0, 0, 200, 200), timeCount.ToString());
	}

	// Update is called once per frame
	void Update () {
		ForUpdate ();

		timeCount += Time.deltaTime;
		if (Input.anyKey){
			flag = false;
			timeCount = 0;
		}
		if (!flag && timeCount > 8.0f) {
			timeCount = timeCount - 8.0f;
			flag = true;
		}
		if (flag && timeCount > 4.0f && !jump) {
			timeCount = timeCount - 4.0f;
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			jump = true;
		}

		if (transform.position.y < -40) {
			transform.position = new Vector3 (0, 30, 0);
			rigidbody.velocity = new Vector3(0,rigidbody.velocity.y,0);
		}

	}
}
