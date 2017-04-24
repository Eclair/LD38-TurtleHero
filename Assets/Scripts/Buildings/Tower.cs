using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public enum TowerType {
		None,
		Archer,
		Mage,
		Cannon
	};

	public TowerType type;
	public TowerBlueprint towerUpgrade;
	public float attack;
	public GameObject howerIndicator;
	public float cooldown = 3f;

	private float sinceLastAttack = 0;

	void Start() {
		howerIndicator.SetActive(false);
	}

	void Update() {
		if (GlobalMapManager.instance.sailing) {
			sinceLastAttack += Time.deltaTime;
		}
	}

	public bool isReadyToFire() {
		return sinceLastAttack > cooldown;
	}

	public void fireAtEnemy(Enemy enemy) {
		enemy.getHit((int)attack);
		sinceLastAttack = 0;
	}

	public void setHighlighted(bool highlighted) {
		howerIndicator.SetActive(highlighted);
	}

	// BUILDING

	void OnMouseEnter() {
		if (UIHelper.instance.isMenuOpened || GlobalMapManager.instance.sailing) {
			return;
		}
		setHighlighted(true);
	}

	void OnMouseExit() {
		if (GlobalMapManager.instance.sailing) {
			return;
		}
		setHighlighted(false);
	}

	void OnMouseDown() {
		// DO NOT REACT WHEN OVERLAPED WITH UI or SAILING
		if (UIHelper.instance.isMenuOpened || GlobalMapManager.instance.sailing) {
			return;
		}
		// TODO: SELECT/BUILD/UPGRADE?
		TowerSpot spot = GetComponentInParent<TowerSpot>();
		if (spot != null) {
			setHighlighted(false);
			UpgradesManager.instance.onTowerSpotSelected(spot);
		} else {
			Debug.Log("Spot Not Found");
		}
	}
}
