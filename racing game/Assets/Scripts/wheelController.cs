using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class wheelController : MonoBehaviour {

	public float rotationSpeed ;
	public float speed=10;
	public GameObject car;
	public GameObject mask;
	public Text situation;
	public carController2 enemy2;
	public bool beingAttacked = false;
	float moveRotation, moveForward;
	int factor=1;
	float timeRemaining = 3;
	bool getItem=false;
	int ran;
	Rigidbody wheelBody;

	// Use this for initialization
	void Start () {
		situation.text = "";
		wheelBody = car.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		moveRotation = Input.GetAxisRaw ("Horizontal");
		moveForward = Input.GetAxis ("Vertical");
	}

	void FixedUpdate ()
	{
		// update physics in FixedUpdate()

		UpdateDirection ();
		UpdateVelocity ();
		if (getItem == true) {
			if (ran == 1) {
				situation.text = "Rotation";
				Rotate ();
			} else if (ran == 2) {
				transform.Translate (Vector3.up * Time.deltaTime * 10);
				situation.text = "Jumping";

			} else if (ran == 3) {
				factor = 2;
				situation.text = "Speed Up";
			} else if (ran == 4) {
				mask.SetActive (true);
				situation.text = "Masking";
			} else if (ran == 5) {
				enemy2.beingAttacked = true;
				enemy2.transform.Translate (0,Time.deltaTime,0);
				enemy2.GetComponent<Rigidbody> ().useGravity = false;
				enemy2.speed = 0;
				situation.text = "Attack!!";
			} else if (ran == 6) {
				factor = 0;
				situation.text = "Stop!!";
			}
			timeRemaining -= Time.deltaTime;
		}
		if (timeRemaining <= 0) {
			enemy2.beingAttacked = false;
			getItem = false;
			factor = 1;
			enemy2.speed = 10;
			mask.SetActive (false);
			enemy2.GetComponent<Rigidbody> ().useGravity = true;
			situation.text = "";
			timeRemaining = 3;
		}
	}

	void UpdateDirection ()
	{
		// rotate
		transform.Rotate (0,rotationSpeed * moveRotation * Time.fixedDeltaTime,0, Space.World);
	}

	void UpdateVelocity ()
	{
		if (beingAttacked == false) {
			// compute forward direction
			var forward = transform.right;
			forward.y = 0;
			forward.Normalize ();

			// compute forward velocity
			var v = moveForward * speed * forward * (-1) * factor;
			v.y = wheelBody.velocity.y;

			wheelBody.velocity = v;
		}
		//transform.Translate(moveForward * Vector3.forward * hasSpeed.speed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			timeRemaining = 3;
			other.gameObject.SetActive (false);
			ran = Random.Range (1, 7);
			getItem = true;
		}
	}

	void Rotate(){
		transform.Rotate (new Vector3 (0, 300, 0) * Time.deltaTime);
	}
}
