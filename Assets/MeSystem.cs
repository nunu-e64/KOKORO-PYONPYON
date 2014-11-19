using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class MeSystem : MonoBehaviour {

	public float myRotate = 1;
	public GameObject ball; 
	private bool jump=false;
	public float accell = 0.1f;
	public float maxSpeed = 10;
	public float moveForce = 10;
	//Text goText;

	/*void Awake(){
		goText = GameObject.Find ("1/Text").GetComponent <Text> ();
		goText.gameObject.SetActive (false);
		goText.text ="73";
	}*/

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			rigidbody.AddForce(new Vector3(0,0,moveForce));
			//this.transform.Translate(new Vector3(0,0,0.1f));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {	
			rigidbody.AddForce(new Vector3(0,0,-moveForce));
			//this.transform.Translate(new Vector3(0,0,-0.1f));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rigidbody.AddForce(new Vector3(moveForce,0,0));
			//this.transform.Translate(new Vector3(0.1f,0,0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {	
			rigidbody.AddForce(new Vector3(-moveForce,0,0));
			//this.transform.Translate(new Vector3(-0.1f,0,0));
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!jump) {
				rigidbody.AddForce(transform.up * 10, ForceMode.Impulse);
				//transform.rigidbody.velocity=new Vector3(0,10,0);
				jump=true;
			}
		}
/*なぜかジャンプできなくなる
		float tmpY = rigidbody.velocity.y;
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
		if (rigidbody.velocity.magnitude > maxSpeed) {
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, tmpY, rigidbody.velocity.z);
*/
	}

	void OnCollisionEnter(Collision _collision){

		if (jump && (_collision.gameObject.name=="GroundCube(Clone)" || _collision.gameObject.name=="GroundCube2(Clone)")){
			jump=false;
			Debug.Log("chakuchi");
			//Application.Quit();
		}

	}
}
