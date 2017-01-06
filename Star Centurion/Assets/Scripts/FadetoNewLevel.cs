using UnityEngine;
using System.Collections;

public class FadetoNewLevel : MonoBehaviour {

	public Texture2D fadeTexture;
	public float fadeSpeed = 1.0f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;


	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), fadeTexture);
	}

	public float beginFade(int direction){
		fadeDir = direction;
		return(fadeSpeed);
	}

	void OnLevelFinishedLoading(){
		alpha = 1;
		beginFade (-1);
	}
}
