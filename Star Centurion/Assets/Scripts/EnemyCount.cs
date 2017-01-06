using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour {
	public int enemyCount = 99;
	public Text enemyText;

	public void setEnemyText(){
		enemyText.text = "Enemies: " + enemyCount;
	}
}
