using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace Motorcycle
{
    [RequireComponent(typeof (MotorcycleController))]
    public class MotorcycleUserControl : MonoBehaviour
    {
        private MotorcycleController m_Motorcycle; // the car controller we want to use
		public Text situation;
		public GameObject mask;
		public GameObject rightHand;
		public GameObject leftHand;
		float timeRemaining = 3;
		bool getItem=false;
		int ran;
		bool ud = true,lr = true;
		public float h = 0f, v = 0f;

		void Start () {
			situation.text = "";
		}

        private void Awake()
        {
            // get the car controller
            m_Motorcycle = GetComponent<MotorcycleController>();
        }

		public void RSpeedUp()
		{
			//m_Motorcycle.m_Topspeed=100f;
			ud = true;
		}

		public void RSpeedStop()
		{
			//m_Motorcycle.m_Topspeed=0f;
			ud = false;
		}

		public void LSpeedUp()
		{
			//m_Motorcycle.m_Topspeed=100f;
			lr = true;
			print("aaa");
		}

		public void LSpeedStop()
		{
			//m_Motorcycle.m_Topspeed=0f;
			lr = false;
			print ("bbb");
		}

        private void FixedUpdate()
        {
			// pass the input to the car!
			float h_limit = 0.3f;
			float v_limit = 0.5f;
			float h_up = 0.03f;
			float v_up = 0.03f;
			if (ud) {
				if (v >= v_limit) {
					v = v_limit;
				} else
					v += v_up;
			} else {
				if (v <= -v_limit) {
					v = -v_limit;
				} else
					v -= v_up;
			}
			if (lr) {
				if (h >= h_limit) {
					h = h_limit;
				} else
					h += h_up;
			} else {
				if (h <= -h_limit) {
					h = -h_limit;
				} else
					h -= h_up; 
			}

			if (!rightHand.activeSelf) {
				v = 0f;
			}

			if (!leftHand.activeSelf) {
				h = 0f;
			}
				
			//h = CrossPlatformInputManager.GetAxis("Horizontal");
			//v = CrossPlatformInputManager.GetAxis("Vertical");
			#if !MOBILE_INPUT
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Motorcycle.Move(h, v, v, handbrake);
			#else
			m_Motorcycle.Move(h, v, v, 0f);
			#endif

			// get situations
			if (getItem == true) {
				if (ran == 1) {
					situation.text = "Rotation";
					m_Motorcycle.Move(h*300, v, v, handbrake);
				} else if (ran == 2) {
					transform.Translate (Vector3.up * Time.deltaTime * 5);
					situation.text = "Jumping";
				} else if (ran == 3) {
					m_Motorcycle.m_Topspeed= 200;
					situation.text = "Speed Up";
				} else if (ran == 4) {
					mask.SetActive (true);
					situation.text = "Masking";
				} else if (ran == 5) {
					//m_Motorcycle.Move(h, 0, 0, handbrake);
					m_Motorcycle.m_Topspeed= 0;
					situation.text = "Stop!!";
				}
				timeRemaining -= Time.deltaTime;
			}
			if (timeRemaining <= 0) {
				getItem = false;
				m_Motorcycle.Move(h, v, v, handbrake);
				m_Motorcycle.m_Topspeed= 100;
				mask.SetActive (false);
				situation.text = "";
				timeRemaining = 3;
			}
        }

		void OnTriggerEnter(Collider other){
			if (other.gameObject.CompareTag ("Pick Up")) {
				timeRemaining = 3;
				other.gameObject.SetActive (false);
				ran = UnityEngine.Random.Range (1, 6);
				getItem = true;
			}
		}
    }
}
