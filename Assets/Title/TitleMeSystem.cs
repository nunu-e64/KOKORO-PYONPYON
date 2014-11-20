using UnityEngine;
using System.Collections;

public class TitleMeSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	bool flag = false;
	float timeCount = 0;
	float jumpForce = 70;
	float extraG = 6;

	void OnGUI(){
		GUI.color = Color.black;
		GUI.Label (new Rect (0, 0, 200, 200), timeCount.ToString());
	}

	// Update is called once per frame
	void Update () {

		timeCount += Time.deltaTime;
		if (!flag && timeCount > 7.2f) {
			timeCount = timeCount - 7.2f;
			flag = true;
		}
		if (flag && timeCount > 4.0f) {
			timeCount = timeCount - 4.0f;
			rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
		}

		rigidbody.AddForce(transform.up*-extraG, ForceMode.Acceleration);

	}
}
