using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
		
	public ChangeLevel changeLevel;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Return)){
			changeLevel.ChangeScene ("IntroScreen");
		}
	}
}
