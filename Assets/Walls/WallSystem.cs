using UnityEngine;
using System.Collections;

public class WallSystem : MonoBehaviour {

	public float speed = 0.1f;
	public float sukima = 0;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + sukima, transform.position.z);
	}
	

	// Update is called once per frame
	void Update () {
		if (transform.position.magnitude>100) {
			Destroy(this.gameObject);
		}
		this.transform.Translate (new Vector3 (0, 0, speed));
	}
}
