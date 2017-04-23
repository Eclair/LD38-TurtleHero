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

	void Start() {
		howerIndicator.SetActive(false);
	}

	void OnMouseEnter() {
		if (UIHelper.instance.isMenuOpened || !UIHelper.instance.isBuildingMode) {
			return;
		}
		howerIndicator.SetActive(true);
	}

	void OnMouseExit() {
		howerIndicator.SetActive(false);
	}

	void OnMouseDown() {
		// DO NOT REACT WHEN OVERLAPED WITH UI or SAILING
		if (UIHelper.instance.isMenuOpened || !UIHelper.instance.isBuildingMode) {
			return;
		}
		// TODO: SELECT/BUILD/UPGRADE?
		TowerSpot spot = GetComponentInParent<TowerSpot>();
		if (spot != null) {
			howerIndicator.SetActive(false);
			UpgradesManager.instance.onTowerSpotSelected(spot);
		} else {
			Debug.Log("Spot Not Found");
		}
	}
}
