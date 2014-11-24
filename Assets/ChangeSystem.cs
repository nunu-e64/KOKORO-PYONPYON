using UnityEngine;
using System.Collections;

public class ChangeSystem : MonoBehaviour {


	void Awake(){
		DontDestroyOnLoad(this.gameObject);

	}

	// Use this for initialization
	void Start () {
		//CameraKind = ChangeSystem.CameraKind;
		//playerKind = ChangeSystem.playerKind;
		//bgm = ChangeSystem.bgm;

		SetBgm ();
		SetCamera (CameraKind);
		SetPlayerInit ();
	}
	
	// Update is called once per frame
	void Update () {
		CameraKind = ChangeSystem.CameraKind;
		playerKind = ChangeSystem.playerKind;
		bgm = ChangeSystem.bgm;

		if (title && Input.GetKeyDown(KeyCode.K)){
			ChangePlayer();
		}
		
		if (title && Input.GetKeyDown(KeyCode.C)){
			ChangeCamera();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			bgm = !bgm;
			SetBgm();
		}
	}

	public static bool bgm = false;

	public void SetBgm(){
		if (bgm) {
				GameObject.Find ("BGM").GetComponent<AudioSource> ().volume = 1;
		} else {
				GameObject.Find ("BGM").GetComponent<AudioSource> ().volume = 0;
		}
	}

//
	
	public static int CameraKind = 0;
	public Camera[] camera = new Camera[2];

	public void ChangeCamera(){
		CameraKind = (++CameraKind) % camera.GetLength (0);
		SetCamera (CameraKind);
	}
	
	void SetCamera(int _kind){
		CameraKind = _kind;
		for (int i=0; i<camera.GetLength(0); i++) {
			if (i!=CameraKind){
				camera [i].enabled = false;
			}else{
				camera [i].enabled = true;
			}
		}
	}


/// 
	public static int playerKind=0;
	int playerKindNum = 0;
	public GameObject[] playerObject01 = new GameObject[2]; //[playerIndex, kind]
	public GameObject[] playerObject02 = new GameObject[2]; //[playerIndex, kind]
	
	public bool title = false;

	public void SetPlayerInit(){
		playerKindNum = Mathf.Min(playerObject01.GetLength (0),playerObject02.GetLength (0));
		playerKind = playerKind % playerKindNum;
		
		for (int i=0; i<playerKindNum; i++) {
			if(i==playerKind){
				playerObject01 [i].SetActive (true);
				playerObject02 [i].SetActive (true);
				playerObject01[i].transform.position =  new Vector3(2,4,(title?-8:-2));
				playerObject02[i].transform.position =  new Vector3(-2,4,(title?-4:2));
				
			}else{
				playerObject01 [i].SetActive (false);
				playerObject02 [i].SetActive (false);
			}
		}

	}

	public void ChangePlayer(){
		
		playerObject01[playerKind].SetActive(false);
		playerObject02[playerKind].SetActive(false);
		
		playerKind  = (++playerKind)%playerKindNum;
		
		playerObject01[playerKind].SetActive(true);
		playerObject02[playerKind].SetActive(true);
		
		
		playerObject01[playerKind].transform.position =  new Vector3(2,4,-2);
		playerObject02[playerKind].transform.position =  new Vector3(-2,4,2);
		
	}

}
