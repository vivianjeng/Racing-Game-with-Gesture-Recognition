using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour {
	
	public void ChangeScene(string sceneName){
		Application.LoadLevel (sceneName);
	}

}
