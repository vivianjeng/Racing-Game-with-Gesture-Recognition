using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Motorcycle
{
	[RequireComponent(typeof (MotorcycleController))]
	public class CountDown : MonoBehaviour {

		private MotorcycleController m_Motorcycle; // the car controller we want to use
		public Text CountDownText;
		private float StartTime = 3.5f;
		public wheelController car;

		// Use this for initialization
		void Start () {
			CountDownText.text = "";
			m_Motorcycle.Move(0, 0, 0, 0);
		}
	
		// Update is called once per frame
		void Update () {
			StartTime -= Time.deltaTime;
			CountDownText.text = StartTime.ToString ("f0");

			if (StartTime <= 0) {
				CountDownText.text = "GO";
				car.speed = 10;
			}
			if (StartTime <= -0.9f) {
				CountDownText.text = "";
			}

		}
	}
}
