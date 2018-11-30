using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSlower : MonoBehaviour {

		public float speedFactor = 0.5f;
		public wheelController car;
	public carController2 car2;

		void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Car1"))
			car.speed = 5;
		if (other.gameObject.CompareTag ("Car2"))
			car2.speed = 5;
	}

	void OnCollisionExit(Collision other) {
		if(other.gameObject.CompareTag("Car1"))
			car.speed = 10;
		if(other.gameObject.CompareTag("Car2"))
		car2.speed = 10;
	}
}
