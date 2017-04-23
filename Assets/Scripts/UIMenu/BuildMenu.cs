using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {

	public TowerSpot selectedTowerSpot;

	public void buildArcherTower() {
		UIHelper.instance.closeBuildMenu();
		UpgradesManager.instance.tryToBuildNewTowerAtSpot(selectedTowerSpot, UpgradesManager.instance.archerTower);
	}

	public void buildMageTower() {
		UIHelper.instance.closeBuildMenu();
		UpgradesManager.instance.tryToBuildNewTowerAtSpot(selectedTowerSpot, UpgradesManager.instance.mageTower);
	}

	public void buildCannonTower() {
		UIHelper.instance.closeBuildMenu();
		UpgradesManager.instance.tryToBuildNewTowerAtSpot(selectedTowerSpot, UpgradesManager.instance.cannonTower);
	}
}
