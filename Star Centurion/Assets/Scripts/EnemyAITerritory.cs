using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITerritory : MonoBehaviour {

	public BoxCollider2D enemyZone;
	bool playerInRange;
	public GameObject enemy;
	GameObject player;
	EnemyAI enemyAI;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		enemyAI = enemy.GetComponent<EnemyAI>();
		playerInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerInRange == true) {
			enemyAI.FollowPlayerInRange();
		} else if(playerInRange == false) {
			enemyAI.RestingPosition();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		
		if (col.gameObject == player) {
			playerInRange = true;
		}

	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject == player) {
			playerInRange = false;
		}
	}
}
