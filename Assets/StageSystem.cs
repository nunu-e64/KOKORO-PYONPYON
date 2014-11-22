using UnityEngine;
using System.Collections;

public class StageSystem : MonoBehaviour {
	public int stageLength = 11;
	int gcSize = 2;
	int stageSize;
	public bool PlayerChangeButton=true;
	public bool CameraChangeButton=true;

	//GroundCubesCreate
		public GameObject[] groundCube = new GameObject[2];
		public float fallStep = 3.0f;	//seconds

	//WallCreate
		public GameObject[] wall = new GameObject[2];
		public float pushStep = 2.5f;	//seconds

		int wall_num=0;
		float timecount = 0;
		

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
		Destroy (GameObject.Find ("Cube"));
		stageSize = stageLength * gcSize;

		GcSystem new_gc;
		GameObject go;

		for (int i=0; i<stageLength; i++) {
			for (int j=0; j<stageLength; j++) {
				go = (GameObject)(Instantiate(groundCube[(i+j)%2],  new Vector3((i-5)*2,0,(j-5)*2), new Quaternion()));
				new_gc = go.GetComponents<GcSystem>()[0];
				new_gc.SetDeadTime(deadTime[i,j]*fallStep);
			}
		}

		if (!PlayerChangeButton) GameObject.Find ("PlayerButton").transform.position=new Vector3(0,-100,0);
		if (!CameraChangeButton) GameObject.Find ("CameraButton").transform.position=new Vector3(100,-100,100);

	}

	int counter = 0;
	

	Rect debugRect = new Rect(0,0,100,100);
	void OnGUI() {
		GUI.Label (debugRect, "Hello World!");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.K)){
			GameObject.Find("PlayerButton").GetComponent<ChangePlayerSys>().ChangePlayer();
		}


		timecount += Time.deltaTime;//seconds
		if (timecount >= pushStep*(counter+1)){

			wall_num = Random.Range(0,wall.GetLength(0));
			CreateWall(counter);
			if (counter==3){
				timecount=0;
				counter=0;
				//wall_num = (wall_num+1)%wall.GetLength(0);
			}else{
				++counter;
			}
		}

	}

	void CreateWall(int _dir){
		GameObject new_wall;
		int startDistance = 50;

		_dir = _dir % 4;
		new_wall = (GameObject)(Instantiate (wall[wall_num], new Vector3 (), new Quaternion()));
		int rndPos = (int)(Random.Range(-new_wall.transform.localScale.x/gcSize, stageLength) + (new_wall.transform.localScale.x/gcSize)/2.0f - stageLength/2.0f)*gcSize;
		new_wall.transform.Rotate(0,90*_dir,0);
	
		switch (_dir) {
		case (0):
			new_wall.transform.position = new Vector3(rndPos, wall[wall_num].transform.localScale.y/2+0.5f, -startDistance); 
			break;
		case (1):
			new_wall.transform.position = new Vector3(-startDistance, wall[wall_num].transform.localScale.y/2+0.5f, rndPos); 
			break;
		case (2):
			new_wall.transform.position = new Vector3(rndPos, wall[wall_num].transform.localScale.y/2+0.5f, startDistance); 
			break;
		case (3):
			new_wall.transform.position = new Vector3(startDistance, wall[wall_num].transform.localScale.y/2+0.5f, rndPos); 
			break;
		}
	}

	public void GameOver(){
		//Application.LoadLevel("scene2");
	}
}
