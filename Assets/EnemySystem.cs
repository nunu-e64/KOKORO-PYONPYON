using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour {
	
	public GameObject ball; 
	float timecount = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 0) {
			timecount += Time.deltaTime;//seconds
			if (timecount >= 0.2f) {
					timecount -= 0.2f;
					GameObject go = (GameObject)(Instantiate (ball, transform.position, transform.rotation));
					go.transform.Rotate (new Vector3 (90, 0, 0));
					go.transform.Translate (new Vector3 (0, 3, 0));
			}
		}
	}
}
