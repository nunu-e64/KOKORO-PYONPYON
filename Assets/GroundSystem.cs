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

	int[,] deadTime = {{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11},
		{40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 12},
		{39, 72, 73, 74, 75, 76, 77, 78, 79, 50, 13},
		{38, 71, 96, 97, 98, 99, 100, 101, 80, 51, 14},
		{37, 70, 95, 112, 113, 114, 115, 102, 81, 52, 15},
		{36, 69, 94, 111, 129, 121, 116, 103, 82, 53, 16},
		{35, 68, 93, 110, 119, 118, 117, 104, 83, 54, 17},
		{34, 67, 92, 109, 108, 107, 106, 105, 84, 55, 18},
		{33, 66, 91, 90, 89, 88, 87, 86, 85, 56, 19},
		{32, 65, 64, 63, 62, 61, 60, 59, 58, 57, 20},
		{31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21}};
	
	// Use this for initialization
	void Start () {
		GcSystem new_gc;
		GameObject go;

		for (int i=0; i<11; i++) {
			for (int j=0; j<11; j++) {
				go = (GameObject)(Instantiate(groundCube[(i+j)%2],  new Vector3((i-5)*2,0,(j-5)*2), new Quaternion()));
				new_gc = go.GetComponents<GcSystem>()[0];
				new_gc.SetDeadTime(deadTime[i,j]*fallStep);
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
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (0, wall[wall_num].transform.localScale.y/2+0.5f, -30), new Quaternion()));
				new_wall.transform.Rotate(0,0,0);
				//new_wall.transform.position.y = new_wall.transform.localScale.y/2 + 0.5f; 
				break;
			case (1):
				++counter;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (-30, wall[wall_num].transform.localScale.y/2+0.5f,0), new Quaternion()));
				new_wall.transform.Rotate(0,90,0);
				//go1.transform.position.y = go1.transform.localScale.y;
				break;
			case (2):
				++counter;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (0, wall[wall_num].transform.localScale.y/2+0.5f, 30), new Quaternion()));
				new_wall.transform.Rotate(0,90*2,0);
				//go2.transform.position.y = go2.transform.localScale.y;
				break;
			case (3):
				timecount=0;
				counter=0;
				wall_num = (wall_num+1)%2;
				new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (30, wall[wall_num].transform.localScale.y/2+0.5f, 0), new Quaternion()));					
				new_wall.transform.Rotate(0,90*3,0);
				//go3.transform.position.y = go3.transform.localScale.y;
				break;
			}
		}
	}
}
