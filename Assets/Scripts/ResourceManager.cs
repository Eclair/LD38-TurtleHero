using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

	public static ResourceManager instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}  else if (instance != this) {
			Destroy(gameObject);
		}
	}

	/** Main Resources Types **/
	public int coins;
	public int population;
	public int wood;
	public int stone;
	public int ore;
	public int hqLevel;

	[Header("UI Elements")]
	public Text coinText;
	public Text populationText;
	public Text woodText;
	public Text stoneText;
	public Text oreText;

	/** Adds Coins **/
	public void addCoins(int coins) {
		this.coins += coins;
	}

	/** Checks if user has enough resources to purchase tower **/
	public bool hasEnoughResourcesFor(TowerBlueprint towerBlueprint) {
		return (
			coins >= towerBlueprint.coinsCost &&
			population >= towerBlueprint.populationCost &&
			wood >= towerBlueprint.woodCost &&
			stone >= towerBlueprint.stoneCost &&
			ore >= towerBlueprint.oreCost
		);
	}

	/** Checks if user has enough resources to purchase HQ upgrade **/
	public bool hasEnoughResourcesFor(HQUpgrade hqUpgrade) {
		return (
			coins >= hqUpgrade.coinsCost &&
			population >= hqUpgrade.populationCost &&
			wood >= hqUpgrade.woodCost &&
			stone >= hqUpgrade.stoneCost &&
			ore >= hqUpgrade.oreCost
		);
	}

	/** Deducts Resources Needed to build Tower **/
	public void deductResorcesFor(TowerBlueprint towerBlueprint) {
		coins -= towerBlueprint.coinsCost;
		population -= towerBlueprint.populationCost;
		wood -= towerBlueprint.woodCost;
		stone -= towerBlueprint.stoneCost;
		ore -= towerBlueprint.oreCost;
	}

	/** Deducts Resources Needed to upgrade HQ **/
	public void deductResorcesFor(HQUpgrade hqUpgrade) {
		coins -= hqUpgrade.coinsCost;
		population -= hqUpgrade.populationCost;
		wood -= hqUpgrade.woodCost;
		stone -= hqUpgrade.stoneCost;
		ore -= hqUpgrade.oreCost;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		coinText.text = "" + coins;
		populationText.text = "" + population;
		woodText.text = "" + wood;
		stoneText.text = "" + stone;
		oreText.text = "" + ore;
	}

	#region Trade Functions

	public void buyWoodFromVillage() {
		float price = Village.instance.tradeTable[0, 1];
		if (coins < price) {
			UIHelper.instance.showError("Insufficient Funds");
			return;
		}

		coins -= (int)price;
		wood += 1;
		UIHelper.instance.showNormalMessage("1 Wood Purchased");
	}

	public void sellWoodToVillage() {
		if (wood <= 0) {
			UIHelper.instance.showError("Not Enough Lumber");
			return;
		}

		wood -= 1;
		coins += (int)Village.instance.tradeTable[0, 0];
		UIHelper.instance.showNormalMessage("1 Wood Sold");
	}

	public void buyStoneFromVillage() {
		float price = Village.instance.tradeTable[1, 1];
		if (coins < price) {
			UIHelper.instance.showError("Insufficient Funds");
			return;
		}

		coins -= (int)price;
		stone += 1;
		UIHelper.instance.showNormalMessage("1 Stone Purchased");
	}

	public void sellStoneToVillage() {
		if (stone <= 0) {
			UIHelper.instance.showError("Not Enough Stones");
			return;
		}

		stone -= 1;
		coins += (int)Village.instance.tradeTable[1, 0];
		UIHelper.instance.showNormalMessage("1 Stone Sold");
	}

	public void buySteelFromVillage() {
		float price = Village.instance.tradeTable[2, 1];
		if (coins < price) {
			UIHelper.instance.showError("Insufficient Funds");
			return;
		}

		coins -= (int)price;
		ore += 1;
		UIHelper.instance.showNormalMessage("1 Steel Purchased");
	}

	public void sellSteelToVillage() {
		if (ore <= 0) {
			UIHelper.instance.showError("Not Enough Steel");
			return;
		}

		ore -= 1;
		coins += (int)Village.instance.tradeTable[2, 0];
		UIHelper.instance.showNormalMessage("1 Steel Sold");
	}

	public void buyRecruitFromVillage() {
		float price = Village.instance.tradeTable[3, 1];
		if (coins < price) {
			UIHelper.instance.showError("Insufficient Funds");
			return;
		}

		coins -= (int)price;
		population += 1;
		UIHelper.instance.showNormalMessage("1 Recruit Hired");
	}

	public void sellRecruitToVillage() {
		if (population <= 0) {
			UIHelper.instance.showError("Not Enough Recruits");
			return;
		}

		population -= 1;
		coins += (int)Village.instance.tradeTable[3, 0];
		UIHelper.instance.showNormalMessage("1 Recruit Fired");
	}

	#endregion
}
