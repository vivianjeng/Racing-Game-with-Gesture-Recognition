using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public Text timerText;
	public Text finishText;
	public Text WinText;
	public Text restart;
	private float StartTime;
	private string finishMinute;
	private string finishSecond;

	// Use this for initialization
	void Start(){
		WinText.text = "";
		timerText.text = "";
		finishText.text = "";
		restart.text = "";
		StartTime = Time.time;
	}
		
	void OnTriggerEnter (Collider other) {
		WinText.text = "Finish!";
		finishText.text = finishMinute + ":" + finishSecond;
		restart.text = "Press R to Restart.";
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - StartTime;
		string minutes = ((int)(t-3.5f) / 60).ToString ();
		string seconds = ((t-3.5f) % 60).ToString ("f2");
		if(t > 3.5f)
			timerText.text = minutes + ":" + seconds;
		finishMinute = minutes;
		finishSecond = seconds;

		if (Input.GetKey (KeyCode.R)) {
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene ("racing road");
		}
	}
}
