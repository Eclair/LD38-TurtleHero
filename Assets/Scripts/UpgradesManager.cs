using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour {

	public static UpgradesManager instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}  else if (instance != this) {
			Destroy(gameObject);
		}
	}

	public TowerBlueprint archerTower;
	public TowerBlueprint mageTower;
	public TowerBlueprint cannonTower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/** Reacts on Tower or Empty spot selection and show build/upgrade menu **/
	public void onTowerSpotSelected(TowerSpot towerSpot) {
		if (towerSpot.tower != null && !towerSpot.isEmpty()) {
			Tower tower = towerSpot.tower.GetComponent<Tower>();
			if (tower.towerUpgrade.towerPrefab != null) {
				UIHelper.instance.showUpgradeMenuFor(towerSpot);
			} else {
				UIHelper.instance.showWarning("Tower Already at Max Level!");
			}
		} else {
			// Build NEW!
			UIHelper.instance.showBuildMenuFor(towerSpot);
		}
	}

	/** Try to build new tower at spot using blueprint **/
	public void tryToBuildNewTowerAtSpot(TowerSpot towerSpot, TowerBlueprint towerBlueprint) {
		if (ResourceManager.instance.hqLevel < towerBlueprint.hqLevelRequired) {
			UIHelper.instance.showError("HQ Upgrade Level " + towerBlueprint.hqLevelRequired + " is Required!");
			return;
		}
		if (!ResourceManager.instance.hasEnoughResourcesFor(towerBlueprint)) {
			UIHelper.instance.showError("Insufficient Funds to Build Tower!");
			return;
		}

		// BUILD!
		ResourceManager.instance.deductResorcesFor(towerBlueprint);
		towerSpot.swapTowerWith((GameObject)Instantiate(towerBlueprint.towerPrefab, towerSpot.transform));
		UIHelper.instance.showNormalMessage("Tower Built!");
	}

	/** Try to upgrade tower at spot **/
	public void tryToUpgradeTowerAtSpot(TowerSpot towerSpot) {
		Tower tower = towerSpot.tower.GetComponent<Tower>();

		// Check Requirements:
		if (ResourceManager.instance.hqLevel < tower.towerUpgrade.hqLevelRequired) {
			UIHelper.instance.showError("HQ Upgrade Level " + tower.towerUpgrade.hqLevelRequired + " is Required!");
			return;
		}
		if (!ResourceManager.instance.hasEnoughResourcesFor(tower.towerUpgrade)) {
			UIHelper.instance.showError("Insufficient Funds for Tower Upgrade!");
			return;
		}

		// UPGRADE!
		ResourceManager.instance.deductResorcesFor(tower.towerUpgrade);
		towerSpot.swapTowerWith((GameObject)Instantiate(tower.towerUpgrade.towerPrefab, towerSpot.transform));
		UIHelper.instance.showNormalMessage("Tower Upgraded!");
	}

	/** Reacts on HQ spot selection and show upgrade HQ menu **/
	public void onHQSpotSelected(HQSpot hqSpot) {
		HQ hq = hqSpot.hq.GetComponent<HQ>();
		if (hq.upgrade.hqPrefab != null) {
			UIHelper.instance.showUpgradeHQMenuFor(hqSpot);
		} else {
			UIHelper.instance.showWarning("HQ Already at Max Level!");
		}
	}

	/** Try to upgrade HQ (spot reference needed) **/
	public void tryToUpgradeHQ(HQSpot hqSpot) {
		HQ hq = hqSpot.hq.GetComponent<HQ>();

		if (!ResourceManager.instance.hasEnoughResourcesFor(hq.upgrade)) {
			UIHelper.instance.showError("Insufficient Funds for HQ Upgrade!");
			return;
		}

		// Upgrade!
		ResourceManager.instance.deductResorcesFor(hq.upgrade);
		GameObject newHQ = (GameObject)Instantiate(hq.upgrade.hqPrefab, hqSpot.transform);
		ResourceManager.instance.hqLevel = newHQ.GetComponent<HQ>().level;
		hqSpot.swapHQWithNew(newHQ);
		Turtle.instance.maxHealth += newHQ.GetComponent<HQ>().additionalHullHp;
		Turtle.instance.heal(Turtle.instance.maxHealth);
		UIHelper.instance.showNormalMessage("HQ Upgraded to Level " + ResourceManager.instance.hqLevel);
	}
}
