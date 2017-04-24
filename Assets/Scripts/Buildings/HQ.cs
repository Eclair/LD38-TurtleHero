using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : MonoBehaviour {

	public int level;
	public GameObject howerIndicator;
	public HQUpgrade upgrade;
	public int attack;
	public int additionalHullHp;
	public float cooldown = 3f;

	private float sinceLastAttack;

	void Update() {
		if (GlobalMapManager.instance.sailing) {
			sinceLastAttack += Time.deltaTime;
		}
	}

	public bool isReadyToFire() {
		return sinceLastAttack > cooldown;
	}

	public void fireAtEnemy(Enemy enemy) {
		enemy.getHit(attack);
		sinceLastAttack = 0;
	}

	public void setHighlighted(bool highlighted) {
		howerIndicator.SetActive(highlighted);
	}

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
		if (UIHelper.instance.isMenuOpened || !UIHelper.instance.isBuildingMode) {
			return;
		}
		HQSpot spot = GetComponentInParent<HQSpot>();
		if (spot != null) {
			setHighlighted(false);
			UpgradesManager.instance.onHQSpotSelected(spot);
		} else {
			Debug.Log("HQSpot Not Found");
		}
	}
}
