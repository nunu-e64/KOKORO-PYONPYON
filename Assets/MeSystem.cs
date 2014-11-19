using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class MeSystem : MonoBehaviour {

	public float myRotate = 1;
	public GameObject ball; 
	private bool jump=false;
	public float accell = 0.1f;
	public float maxSpeed = 10;
	Text goText;

	void Awake(){
		goText = GameObject.Find ("1/Text").GetComponent <Text> ();
		goText.gameObject.SetActive (false);
		goText.text ="73";
	}


	// Use this for initialization
	void Start () {
		goText.text ="72";
	}


	// Update is called once per frame
	void Update () {
		goText.gameObject.SetActive (true);

		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.Translate(new Vector3(0,0,0.1f));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {	
			this.transform.Translate(new Vector3(0,0,-0.1f));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Translate(new Vector3(0.1f,0,0));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {	
			this.transform.Translate(new Vector3(-0.1f,0,0));
		}
/*		if (Input.GetKey (KeyCode.UpArrow)) {
			this.transform.rigidbody.velocity+=new Vector3(0,0,accell);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {	
			this.transform.rigidbody.velocity+=new Vector3(0,0,-accell);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.rigidbody.velocity+=new Vector3(accell,0,0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {	
			this.transform.rigidbody.velocity+=new Vector3(-accell,0,0);
		}
*/
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!jump) {
				transform.rigidbody.velocity=new Vector3(0,10,0);
				jump=true;
			}
		}
		if (transform.rigidbody.velocity.sqrMagnitude > maxSpeed) {
//			transform.rigidbody.velocity = transform.forward*maxSpeed;
		}
/*		if ((transform.rigidbody.velocity*(new Vector3(1,0,1))).sqrMagnitude > maxSpeed) {
			float ySpeed = transform.rigidbody.velocity.y;
			transform.rigidbody.velocity = transform.forward*(new Vector3(1,0,1)).normalized*maxSpeed;
			transform.rigidbody.velocity.y = ySpeed;
		}		*/

	}

	void OnCollisionEnter(Collision _collision){

		if (_collision.gameObject.name == "Ground") {
			jump=false;
			//Application.Quit();
		}

	}
}
