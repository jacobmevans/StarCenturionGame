using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterInputController : MonoBehaviour {

	public float fallingThreshold = -50;
	public int numLives = 3;
	public bool isDead = false;
	public ChangeLevel changeLevel;
	public Text livesText;

	// Update is called once per frame
	void Update () {
		bool shoot = Input.GetButtonDown ("Fire1");

		if (shoot) {
			Debug.Log ("Shooting damnit...");
			WeaponManager weapon = GetComponentInChildren<WeaponManager> ();

			if (weapon != null) {
				Debug.Log (" 100%............Shooting damnit...");
				weapon.Attack (false);
			}
		}

		if (this.transform.position.y < fallingThreshold) {
			respawn ();
		}

		if (isDead) {
			numLives--;
			respawn ();
		}

		if (numLives == 0) {
			changeLevel.ChangeScene ("GameOverScreen");
		}
	}

	public void respawn(){
		this.transform.position = new Vector3 (0, 7.5f, 0);
		livesText.text = "Lives: " + numLives;
		isDead = false;
	}
}
