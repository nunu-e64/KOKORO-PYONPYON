using UnityEngine;
using System.Collections;

public class WallSystem : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
		timecount = 0;
	}
	
	float timecount;

	// Update is called once per frame
	void Update () {
		if (transform.position.sqrMagnitude>1600) {
			Destroy(this.gameObject);
		}
		this.transform.Translate (new Vector3 (0, 0, speed));
	}
}
