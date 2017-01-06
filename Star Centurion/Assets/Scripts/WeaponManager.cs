using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public Transform shotTransform;
	public Transform weaponTransform;
	public float fire_rate = 0.25f;
	bool backward = false;


	private float shooting_cd;


	// Use this for initialization
	void Start () {
		shooting_cd = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting_cd > 0) {
			shooting_cd -= Time.deltaTime;
		}

		if (Input.anyKey) {
			if (Input.GetKey (KeyCode.A)) {
				backward = true;
			} else if (Input.GetKey (KeyCode.D)) {
				backward = false;
			}
		}
	}

	public void Attack(bool isEnemy){
		if (CanAttack) {
			shooting_cd = fire_rate;

			var shootingTransform = Instantiate (shotTransform) as Transform;
			shootingTransform.position = transform.position;

			Shooting shot = shootingTransform.gameObject.GetComponent<Shooting> ();

			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
				
			MoveObject move = shootingTransform.gameObject.GetComponent<MoveObject> ();

			if (backward) {
				move.direction = -this.transform.right;
				Debug.Log ("Shooting inside attack....");
			} else {
				move.direction = this.transform.right;
				Debug.Log ("Shooting backward inside attack....");
			}		    
		}
	}

	public void enemyAttack(){
		if (CanAttack) {
			shooting_cd = fire_rate;

			var shootingTransform = Instantiate (shotTransform) as Transform;
			shootingTransform.position = transform.position;

			MoveObject move = shootingTransform.gameObject.GetComponent<MoveObject> ();

			move.direction = this.transform.forward;
		}


	}

	public bool CanAttack{
		get{ return shooting_cd <= 0f; }
	}
}
