using UnityEngine;
using System.Collections;

public class GroundSystem : MonoBehaviour {
	public GameObject[] wall = new GameObject[10];
	int wall_num=0;
	float timecount = 0;
	int counter = 0;
	public float pushStep = 2.5f;

	GameObject new_wall;

	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		timecount += Time.deltaTime;//seconds
		if (timecount >= pushStep*(counter+1)){
			switch(counter) {
			case (0):
				++counter;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (0, 1, -30), new Quaternion(0,0,0,0)));
				new_wall.transform.Rotate(0,0,0);
				//go0.transform.position.y = go0.transform.localScale.y; 
				break;
			case (1):
				++counter;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (-30, 1,0), new Quaternion(0,0,0,0)));
				new_wall.transform.Rotate(0,90,0);
				//go1.transform.position.y = go1.transform.localScale.y;
				break;
			case (2):
				++counter;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (0, 1, 30), new Quaternion(0,0,0,0)));
				new_wall.transform.Rotate(0,90*2,0);
				//go2.transform.position.y = go2.transform.localScale.y;
				break;
			case (3):
				timecount=0;
				counter=0;
				wall_num = (wall_num+1)%2;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (30, 1, 0), new Quaternion(0,0,0,0)));					
				new_wall.transform.Rotate(0,90*3,0);
				//go3.transform.position.y = go3.transform.localScale.y;
				break;
			}
		}
	}
}
