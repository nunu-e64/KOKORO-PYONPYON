using UnityEngine;
using System.Collections;

public class ChangeCameraSys : MonoBehaviour {

	public Camera[] camera = new Camera[2];
	public static int CameraKind = 0;
	
	// Use this for initialization
	void Start () {
		SetCamera (ChangeCameraSys.CameraKind);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeCamera(){
		if (camera [0].enabled) {
			CameraKind = 1;
				camera [1].enabled = true;
				camera [0].enabled = false;
		} else {
			CameraKind = 0;
				camera [0].enabled = true;
				camera [1].enabled = false;
		}
	}

	void SetCamera(int _kind){
		
		if (_kind == 1) {
			CameraKind = 1;
			camera [1].enabled = true;
			camera [0].enabled = false;
		} else {
			CameraKind = 0;
			camera [0].enabled = true;
			camera [1].enabled = false;
		}

	}
}