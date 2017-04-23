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
}
