using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public int shot_dmg = 1;
	public bool isEnemyShot = false;
	public Transform bullet1Prefab;

	// Use this for initialization
	void Start () {
		//Destroy the shot if it goes on for so long, as to not waste memory.
		Destroy (gameObject, 5);
	}
}
