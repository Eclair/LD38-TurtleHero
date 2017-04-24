using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour {

	public static BattleControl instance;

	void Awake() {
		instance = this;
	}

	public EnemySlot[] list;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Turtle.instance == null) {
			return;
		}

		// only if there are some enemies
		if (!isThereAreEnemies()) {
			return;
		}

		// Select new weapon if nothis is selected
		if (!Turtle.instance.isWeaponSelected()) {
			Turtle.instance.selectNextWeapon();
		}
	}

	public void tryToAttackEnemy(Enemy enemy) {
		if (Turtle.instance == null) {
			return;
		}

		if (Turtle.instance.isWeaponSelected()) {
			Turtle.instance.fireWeaponAt(enemy);
		}
	}

	// Check if there are any enemies
	private bool isThereAreEnemies() {
		for (int i = 0; i < list.Length; i++) {
			if (list[i].enemy != null) {
				return true;
			}
		}
		return false;
	}
}
