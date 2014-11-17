using UnityEngine;
using System.Collections;

public class GcSystem : MonoBehaviour, GameObject {

	int i=0;
	int j=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetIndex(int _i, int _j){
		i = _i;
		j = _j;
		Debug.Log ("GcSytem"+i+":"+j);
	}
}
