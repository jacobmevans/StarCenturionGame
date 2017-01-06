using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health_points = 2;
	public bool isEnemy = true;
	public Animator explosion;
	public AudioSource explosionSound;
	public EnemyCount ec;

	void Start(){
		ec = GameObject.Find("_GM").GetComponent<EnemyCount>();
	}

	IEnumerator OnTriggerEnter2D (Collider2D col) {
		
		Shooting shot = col.gameObject.GetComponent<Shooting> ();

		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				health_points -= shot.shot_dmg;
				Destroy (shot.gameObject);

				if (health_points <= 0) {
					Explode ();
					yield return new WaitForSeconds (1);

				}
			}
		}
	}

	public void Explode(){

		explosionSound.Play();
		ec.enemyCount--;
		ec.setEnemyText ();
		explosion.SetBool ("Death", true);
		Destroy (gameObject, 1);
	}
}
