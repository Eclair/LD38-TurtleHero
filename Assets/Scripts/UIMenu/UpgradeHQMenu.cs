using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeHQMenu : MonoBehaviour {

	public HQSpot selectedHQSpot;

	[Header("UI")]
	public Image hqImage;

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

	public void updateWithHQSpot(HQSpot spot) {
		selectedHQSpot = spot;

		HQUpgrade upgrade = spot.hq.GetComponent<HQ>().upgrade;
		HQ newHQ = upgrade.hqPrefab.GetComponent<HQ>();
		hqImage.sprite = newHQ.GetComponentInChildren<SpriteRenderer>().sprite;

		coinIcon.SetActive(upgrade.coinsCost > 0);
		coinText.text = upgrade.coinsCost > 0 ? "" + upgrade.coinsCost : "";

		popIcon.SetActive(upgrade.populationCost > 0);
		popText.text = upgrade.populationCost > 0 ? "" + upgrade.populationCost : "";

		woodIcon.SetActive(upgrade.woodCost > 0);
		woodText.text = upgrade.woodCost > 0 ? "" + upgrade.woodCost : "";

		stoneIcon.SetActive(upgrade.stoneCost > 0);
		stoneText.text = upgrade.stoneCost > 0 ? "" + upgrade.stoneCost : "";

		steelIcon.SetActive(upgrade.oreCost > 0);
		steelText.text = upgrade.oreCost > 0 ? "" + upgrade.oreCost : "";
	}

	public void upgradeHQ() {
		UIHelper.instance.closeUpgradeHQMenu();
		UpgradesManager.instance.tryToUpgradeHQ(selectedHQSpot);
	}
}
