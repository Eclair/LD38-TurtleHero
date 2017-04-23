using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTowerMenu : MonoBehaviour {

	public TowerSpot selectedTowerSpot;

	[Header("UI")]
	public Image towerImage;
	public Text newAttackText;
	public Text hqLevelText;

	public GameObject coinIcon;
	public Text coinText;

	public GameObject popIcon;
	public Text popText;

	public GameObject woodIcon;
	public Text woodText;

	public GameObject stoneIcon;
	public Text stoneText;

	public GameObject steelIcon;
	public Text steelText;

	public void updateWithTowerSpot(TowerSpot towerSpot) {
		selectedTowerSpot = towerSpot;
		// TODO: Update UI
		TowerBlueprint blueprint = towerSpot.tower.GetComponent<Tower>().towerUpgrade;
		Tower tower = blueprint.towerPrefab.GetComponent<Tower>();
		towerImage.sprite = tower.GetComponentInChildren<SpriteRenderer>().sprite;
		newAttackText.text = "New Attack: " + tower.attack;
		hqLevelText.text = "HQ Level " + blueprint.hqLevelRequired;

		coinIcon.SetActive(blueprint.coinsCost > 0);
		coinText.text = blueprint.coinsCost > 0 ? "" + blueprint.coinsCost : "";

		popIcon.SetActive(blueprint.populationCost > 0);
		popText.text = blueprint.populationCost > 0 ? "" + blueprint.populationCost : "";

		woodIcon.SetActive(blueprint.woodCost > 0);
		woodText.text = blueprint.woodCost > 0 ? "" + blueprint.woodCost : "";

		stoneIcon.SetActive(blueprint.stoneCost > 0);
		stoneText.text = blueprint.stoneCost > 0 ? "" + blueprint.stoneCost : "";

		steelIcon.SetActive(blueprint.oreCost > 0);
		steelText.text = blueprint.oreCost > 0 ? "" + blueprint.oreCost : "";
	}

	public void upgradeTower() {
		UIHelper.instance.closeUpgradeMenu();
		UpgradesManager.instance.tryToUpgradeTowerAtSpot(selectedTowerSpot);
	}
}
