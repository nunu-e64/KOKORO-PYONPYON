using UnityEngine;
using System.Collections;

public class ChangeCameraSys : MonoBehaviour {

	public Camera[] camera = new Camera[2];
	
	// Use this for initialization
	void Start () {
		if (camera [0].enabled != camera [1].enabled) {
			camera [0].enabled = true;
			camera [1].enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeCamera(){
		Debug.Log ("onClick");

		if (camera [0].enabled) {
				camera [1].enabled = true;
				camera [0].enabled = false;
		} else {
				camera [0].enabled = true;
				camera [1].enabled = false;
		}
	}
}