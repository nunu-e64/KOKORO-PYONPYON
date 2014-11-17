using UnityEngine;
using System.Collections;

public class GroundSystem : MonoBehaviour {
	public GameObject[] wall = new GameObject[10];
	public GameObject[] groundCube = new GameObject[2];
	public float pushStep = 2.5f;	//seconds
	public float fallStep = 3.0f;	//seconds

	int wall_num=0;
	float timecount = 0;
	int counter = 0;

	GameObject new_wall;

	// Use this for initialization
	void Start () {
		GcSystem new_gc;
		GameObject go;

		for (int i=0; i<11; i++) {
			for (int j=0; j<11; j++) {
				go = (GameObject)(Instantiate(groundCube[(i+j)%2],  new Vector3((i-5)*2,0,(j-5)*2), new Quaternion()));
				//new_gc.SetIndex(i,j);
			}
		}
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
