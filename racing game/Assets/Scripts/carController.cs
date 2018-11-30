using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour {
	public float rotationSpeed ;
	public float speed;
	public GameObject car;
	float moveRotation, moveForward;
	Rigidbody wheelBody;

	// Use this for initialization
	void Start () {
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
	}

	void UpdateDirection ()
	{
		// rotate
		transform.Rotate (Vector3.up, rotationSpeed * moveRotation * Time.fixedDeltaTime, Space.World);
	}

	void UpdateVelocity ()
	{
		// compute forward direction
		var forward = transform.right;
		forward.y = 0;
		forward.Normalize ();

		// compute forward velocity
		var v = moveForward * speed * forward * (-1);


		wheelBody.velocity = v;
		//transform.Translate(moveForward * Vector3.forward * hasSpeed.speed * Time.fixedDeltaTime);
	}
}
