using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	public void ChangeScene(string newScene){ 
		StartCoroutine (waitForFade ());
		SceneManager.LoadScene(newScene);
	}

	IEnumerator waitForFade(){
		float fadeTime = GameObject.Find ("_GM").GetComponent<FadetoNewLevel> ().beginFade (-1);
		yield return new WaitForSeconds (fadeTime);
	}

	public void quitGame(){
		Application.Quit ();
	}
}
