using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public EnemySlot enemySlot1;
	public EnemySlot enemySlot2;

	public GameObject dolphinPrefab;

	[Range(0.1f, 1.0f)]
	public float encounterChance = 0.5f;

	public float spawnCooldown;

	private float timeSinceLastSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (timeSinceLastSpawn > spawnCooldown) {
			if (hasEmptySlots()) {
				// TRY TO SPAWN
				if (Random.Range(0f, 1f) <= encounterChance) {
					EnemySlot slot = getEmptyEnemySlot();
					slot.enemy = createDolphinForSlot(slot);
				}
			}
			timeSinceLastSpawn = 0;
		} else {
			timeSinceLastSpawn += Time.deltaTime;
		}
	}

	private bool hasEmptySlots() {
		return enemySlot1.enemy == null || enemySlot2.enemy == null;
	}

	private EnemySlot getEmptyEnemySlot() {
		if (enemySlot1.enemy == null) {
			return enemySlot1;
		}
		return enemySlot2;
	}

	private GameObject createDolphinForSlot(EnemySlot slot) {
		int difficultyModifier = 0;
		if (Turtle.instance != null) {
			difficultyModifier = Turtle.instance.getTurtleLevel();
		}
		GameObject dolphin = (GameObject)Instantiate(dolphinPrefab, slot.transform);
		Enemy enemy = dolphin.GetComponent<Enemy>();
		enemy.attack = Random.Range(3, 4) + (int)((float)difficultyModifier / 4);
		enemy.attackCooldown = Random.Range(6, 7);
		enemy.maxHealth = Random.Range(6, 9) + difficultyModifier * 8;
		enemy.health = enemy.maxHealth;
		return dolphin;
	}
}
