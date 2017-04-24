using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

	public static Turtle instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}  else if (instance != this) {
			Destroy(gameObject);
		}
	}

	public GameObject hqSpot;
	public GameObject towerSpot1;
	public GameObject towerSpot2;
	public GameObject towerSpot3;
	public GameObject towerSpot4;

	public int health = 40;
	public int maxHealth = 40;

	public void heal(int health) {
		this.health += health;
		if (this.health > maxHealth) {
			this.health = maxHealth;
		}
	}

	public void attack(int health) {
		this.health -= health;
	}

	// Needed as difficulty modifier
	public int getTurtleLevel() {
		int turtleLevel = 0;
		turtleLevel += 1 + (ResourceManager.instance.hqLevel - 1) * 2; // base: 1, +2 for each level up
		turtleLevel += getTowerSpotDifficultyModifier(towerSpot1);
		turtleLevel += getTowerSpotDifficultyModifier(towerSpot2);
		turtleLevel += getTowerSpotDifficultyModifier(towerSpot3);
		turtleLevel += getTowerSpotDifficultyModifier(towerSpot4);
		return turtleLevel;
	}

	private int getTowerSpotDifficultyModifier(GameObject towerSpot) {
		if (!towerSpot.GetComponent<TowerSpot>().isEmpty()) {
			return (int)(towerSpot.GetComponentInChildren<Tower>().attack / 2); // ~(attack/2)
		}
		return 0;
	}

	public void unselectWeapon() {
		if (isWeaponSelected()) {
			if (isTower(selectedWeapon)) {
				selectedWeapon.GetComponent<Tower>().setHighlighted(false);
			} else {
				selectedWeapon.GetComponent<HQ>().setHighlighted(false);
			}
		}
	}

	// Battle!!
	private GameObject selectedWeapon;

	public void selectNextWeapon() {
		HQ hq = hqSpot.GetComponentInChildren<HQ>();
		if (hq.isReadyToFire()) {
			hq.setHighlighted(true);
			selectedWeapon = hq.gameObject;
			return;
		}
		if (!towerSpot1.GetComponent<TowerSpot>().isEmpty()) {
			Tower tower = towerSpot1.GetComponentInChildren<Tower>();
			if (tower.isReadyToFire()) {
				tower.setHighlighted(true);
				selectedWeapon = tower.gameObject;
				return;
			}
		}
		if (!towerSpot2.GetComponent<TowerSpot>().isEmpty()) {
			Tower tower = towerSpot2.GetComponentInChildren<Tower>();
			if (tower.isReadyToFire()) {
				tower.setHighlighted(true);
				selectedWeapon = tower.gameObject;
				return;
			}
		}
		if (!towerSpot3.GetComponent<TowerSpot>().isEmpty()) {
			Tower tower = towerSpot3.GetComponentInChildren<Tower>();
			if (tower.isReadyToFire()) {
				tower.setHighlighted(true);
				selectedWeapon = tower.gameObject;
				return;
			}
		}
		if (!towerSpot4.GetComponent<TowerSpot>().isEmpty()) {
			Tower tower = towerSpot4.GetComponentInChildren<Tower>();
			if (tower.isReadyToFire()) {
				tower.setHighlighted(true);
				selectedWeapon = tower.gameObject;
				return;
			}
		}
	}

	public bool isWeaponSelected() {
		return selectedWeapon != null;
	}

	public void fireWeaponAt(Enemy enemy) {
		if (isTower(selectedWeapon)) {
			// FIRE FROM TOWER
			selectedWeapon.GetComponent<Tower>().fireAtEnemy(enemy);
			selectedWeapon.GetComponent<Tower>().setHighlighted(false);
		} else {
			// FIRE FROM HQ
			selectedWeapon.GetComponent<HQ>().fireAtEnemy(enemy);
			selectedWeapon.GetComponent<HQ>().setHighlighted(false);
		}
		selectedWeapon = null;
	}

	private bool isTower(GameObject selectedWeapon) {
		return selectedWeapon.GetComponent<Tower>() != null;
	}

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
