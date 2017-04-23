using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : MonoBehaviour {

	public int level;
	public GameObject howerIndicator;
	public HQUpgrade upgrade;

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
		if (UIHelper.instance.isMenuOpened || !UIHelper.instance.isBuildingMode) {
			return;
		}
		HQSpot spot = GetComponentInParent<HQSpot>();
		if (spot != null) {
			UpgradesManager.instance.onHQSpotSelected(spot);
		} else {
			Debug.Log("HQSpot Not Found");
		}
	}
}
