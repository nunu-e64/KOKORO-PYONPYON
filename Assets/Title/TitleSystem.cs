using UnityEngine;
using System.Collections;

public class TitleSystem : MonoBehaviour {
	//GroundCubesCreate
	public int stageLength = 11;
	public GameObject[] groundCube = new GameObject[2];
	
	//WallCreate
	public GameObject[] wall = new GameObject[2];
	public float pushStep = 2.5f;	//seconds
	
	int wall_num=0;
	float timecount = 0;
	int counter = 0;

	public GUIStyle titleStyle; 	public GUIStyle messageStyle; 	public GUIStyle selectStyle; 	public GUIStyle startStyle;

	public bool PlayerChangeButton=true;
	public bool CameraChangeButton=true;

	public static int selectMode = 0;

	void OnGUI(){
		GUI.Label(new Rect (Screen.width/2-50, 10, 100, 100),"心がぴょんぴょんするゲーム", titleStyle);		//"心がぴょんぴょんするゲーム""せーのでぽっぴんジャンプ♪"

		string message = "ステージからおちないように、かべをよけつづけよう！\n1P(あか)･･･いどう：↑↓←→　ジャンプ：スペースか右Ctrl\n2P(あお)･･･いどう：ＷＳＡＤ　ジャンプ：左シフトか左Ctrl";
		GUI.Label(new Rect (15, Screen.height-130, 100, 100),message, messageStyle);

		string selectMessage;
		selectMessage = ((selectMode==0)?"ふつう→":"←むずかしい");
        selectStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label(new Rect (Screen.width/2-50, 60, 100, 100),selectMessage, selectStyle);

		if((int)(timecount/0.5f)%3!=0) GUI.Label(new Rect (Screen.width/2-50, 90, 100, 100),"エンターキーではじまるよ", startStyle);

		
		if (Input.GetKey(KeyCode.LeftArrow)) selectMode = 0;
		if (Input.GetKey(KeyCode.RightArrow)) selectMode = 1;

	}


	// Use this for initialization
	void Start () {
		GcSystem new_gc;
		GameObject go;
		
		for (int i=0; i<stageLength; i++) {
			for (int j=0; j<stageLength; j++) {
				go = (GameObject)(Instantiate(groundCube[(i+j)%2],  new Vector3((i-5)*2,0,(j-5)*2), new Quaternion()));
				new_gc = go.GetComponents<GcSystem>()[0];
			}
		}

		Destroy (GameObject.Find ("Cube"));

		if (!PlayerChangeButton) GameObject.Find ("PlayerButton").transform.position=new Vector3(0,-100,0);
		if (!CameraChangeButton) GameObject.Find ("CameraButton").transform.position=new Vector3(100,-100,100);
	}
	

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Return)){
			Application.LoadLevel("scene0");
		}

		if (Input.GetKeyDown(KeyCode.K)){
			GameObject.Find("PlayerButton").GetComponent<ChangePlayerSys>().ChangePlayer();
		}

	
		timecount += Time.deltaTime;//seconds
		if (timecount >= pushStep*(counter+1)){
			
			CreateWall(counter);
			if (counter==3){
				timecount=0;
				counter=0;
				wall_num = (wall_num+1)%wall.GetLength(0);
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
		new_wall.transform.Rotate(0,90*_dir,0);
		
		switch (_dir) {
		case (0):
			new_wall.transform.position = new Vector3(0, wall[wall_num].transform.localScale.y/2+0.5f, -startDistance); 
			break;
		case (1):
			new_wall.transform.position = new Vector3(-startDistance, wall[wall_num].transform.localScale.y/2+0.5f, 0); 
			break;
		case (2):
			new_wall.transform.position = new Vector3(0, wall[wall_num].transform.localScale.y/2+0.5f, startDistance); 
			break;
		case (3):
			new_wall.transform.position = new Vector3(startDistance, wall[wall_num].transform.localScale.y/2+0.5f, 0); 
			break;
		}
	}

}
