using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlot : MonoBehaviour {

	public GameObject enemy;

	void Update() {
		if (enemy != null) {
			if (enemy.GetComponent<Enemy>().health <= 0) {
				Destroy(enemy);
			}
		}
	}
}
