using UnityEngine;
using System.Collections;

public class ChangePlayerSys : MonoBehaviour {

	public int playerKind=0;
	int playerKindNum = 0;
	public GameObject[] playerObject01 = new GameObject[2]; //[playerIndex, kind]
	public GameObject[] playerObject02 = new GameObject[2]; //[playerIndex, kind]

	public bool title = false;

	// Use this for initialization
	void Start () {
		playerKindNum = Mathf.Min(playerObject01.GetLength (0),playerObject02.GetLength (0));
		playerKind = playerKind % playerKindNum;

			for (int i=0; i<playerKindNum; i++) {
				if(i==playerKind){
					playerObject01 [i].SetActive (true);
					playerObject02 [i].SetActive (true);
					playerObject01[i].transform.position =  new Vector3(-2,4,(title?-4:2));
					playerObject02[i].transform.position =  new Vector3(2,4,(title?-8:-2));

				}else{
					playerObject01 [i].SetActive (false);
					playerObject02 [i].SetActive (false);
				}
			}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangePlayer(){
		
		playerObject01[playerKind].SetActive(false);
		playerObject02[playerKind].SetActive(false);

		playerKind  = (++playerKind)%playerKindNum;

		playerObject01[playerKind].SetActive(true);
		playerObject02[playerKind].SetActive(true);

		playerObject01[playerKind].transform.position =  new Vector3(-2,4,2);
		playerObject02[playerKind].transform.position =  new Vector3(2,4,-2);

	}
}