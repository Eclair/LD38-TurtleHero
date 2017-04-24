using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPTracking : MonoBehaviour {

	public EnemySlot enemySlot;

	public GameObject enemyInfoWindow;
	public Text enemyName;
	public Text enemyHP;
	public Slider enemyHPBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		enemyInfoWindow.SetActive(enemySlot.enemy != null);

		if (enemySlot.enemy != null) {
			Enemy enemy = enemySlot.enemy.GetComponent<Enemy>();
			enemyName.text = enemy.displayName;
			enemyHP.text = enemy.health + " / " + enemy.maxHealth;
			enemyHPBar.value = (float)enemy.health / (float)enemy.maxHealth;
		}
	}
}
