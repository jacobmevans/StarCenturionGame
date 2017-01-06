using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public float speed = 4f;
	public float attackDistance = 0.0001f;
	public int attackDamage = 1;
	public float timeBetweenAttacks;
	private Vector3 enemyStartingLocation;
	public Health health;
	public CharacterInputController cIC;


	// Use this for initialization
	void Start () {
		//RestingPosition();
		enemyStartingLocation = transform.position;

		//weapon = GetComponentInChildren<WeaponManager>();
	}
	
	// Update is called once per frame
	void Update () {
		//RestingPosition ();
		//FollowPlayerInRange ();
	}

	public void FollowPlayerInRange(){
		transform.LookAt (target.position);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);

		if (Vector3.Distance (transform.position, target.position) > attackDistance) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		} else {
			health.Explode();
			cIC.isDead = true;
		}
	}

	public void RestingPosition(){
		
		//transform.LookAt (Vector3.zero);
		if (transform.position != enemyStartingLocation) {
			ResetEnemy();
		}
	}

	public void ResetEnemy(){
		transform.LookAt (enemyStartingLocation);
		transform.Rotate(new Vector3(0, -90, 0), Space.Self);
		transform.Translate(new Vector3(speed * Time.deltaTime, 0 , 0));
	}
}
