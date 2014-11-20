using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class MeSystem : MonoBehaviour {

	public GameObject ball; 

	private bool jump=false;
	private float maxSpeed = 5;

	private float moveForce = 100;
	private float moveForce_air = 20;

	private float jumpForce = 50;
	private float extraG = 6;

	public KeyCode keyUp = KeyCode.UpArrow;
	public KeyCode keyDown = KeyCode.DownArrow;
	public KeyCode keyRight = KeyCode.RightArrow;
	public KeyCode keyLeft = KeyCode.LeftArrow;
	public KeyCode keyJump = KeyCode.Space;


	//Text goText;

	/*void Awake(){
		goText = GameObject.Find ("1/Text").GetComponent <Text> ();
		goText.gameObject.SetActive (false);
		goText.text ="73";
	}*/

	// Use this for initialization
	void Start () {

	}
	protected void Begin(){
		Start ();
	}

	// Update is called once per frame
	protected void Update () {

		if (Input.GetKey (keyUp)) {
			rigidbody.AddForce(new Vector3(0,0,(jump)?moveForce_air:moveForce));
		}
		if (Input.GetKey (keyDown)) {	
			rigidbody.AddForce(new Vector3(0,0,-((jump)?moveForce_air:moveForce)));
		}
		if (Input.GetKey (keyRight)) {
			rigidbody.AddForce(new Vector3((jump)?moveForce_air:moveForce,0,0));
		}
		if (Input.GetKey (keyLeft)) {	
			rigidbody.AddForce(new Vector3(-((jump)?moveForce_air:moveForce),0,0));
		}

		//速度制限
		Vector3 tmpVec = new Vector3 (rigidbody.velocity.x, 0, rigidbody.velocity.z);
		if (tmpVec.magnitude > maxSpeed) {
			tmpVec = tmpVec.normalized * maxSpeed;
			rigidbody.velocity = new Vector3(tmpVec.x, rigidbody.velocity.y, tmpVec.z);
		}

		if (Input.GetKey (keyJump)) {
			if (!jump) {
				rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
				jump=true;
			}
		}

		if (jump){
			rigidbody.AddForce(transform.up*-extraG, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter(Collision _collision){

		if (jump && (_collision.gameObject.name=="GroundCube(Clone)" || _collision.gameObject.name=="GroundCube2(Clone)")){
			jump=false;
			Debug.Log("chakuchi");
			//Application.Quit();
		}

	}
}
