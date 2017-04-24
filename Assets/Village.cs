using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour {

	public static Village instance;

	void Awake() {
		instance = this;
	}

	public float[,] tradeTable = new float[4, 2] {
		{0, 0},
		{0, 0},
		{0, 0},
		{0, 0}
	};

	// Use this for initialization
	void Start () {
		// Arrived to the village
		Turtle.instance.unselectWeapon();
		healTheTurtle();
		awardPlayerRandomCoins();
		generateTradePrices();
	}

	private void healTheTurtle() {
		int healthRestored = Random.Range(2, 4) * Turtle.instance.getTurtleLevel();
		Turtle.instance.heal(healthRestored);
		UIHelper.instance.showNormalMessage("Hull Repaired for " + healthRestored + " HP");
	}

	private void awardPlayerRandomCoins() {
		int coinsEarned = Random.Range(4, 9);
		ResourceManager.instance.addCoins(coinsEarned);
		UIHelper.instance.showAutotradeMenu(coinsEarned);
	}

	private void generateTradePrices() {
		// Generate Wood Price
		float woodSellPrice = (float)Random.Range(2, 5);
		float woodBuyPrice = woodSellPrice + (float)Random.Range(1, 3);

		// Generate Stone Price
		float stoneSellPrice = (float)Random.Range(4, 7);
		float stoneBuyPrice = stoneSellPrice + (float)Random.Range(2, 4);

		// Generate Ore Price
		float oreSellPrice = (float)Random.Range(5, 10);
		float oreBuyPrice = oreSellPrice + (float)Random.Range(4, 6);

		// Generate Recruters Price
		float recruterSellPrice = (float)Random.Range(8, 12);
		float recruterBuyPrice = recruterSellPrice + (float)Random.Range(4, 6);

		tradeTable[0, 0] = woodSellPrice;
		tradeTable[0, 1] = woodBuyPrice;
		tradeTable[1, 0] = stoneSellPrice;
		tradeTable[1, 1] = stoneBuyPrice;
		tradeTable[2, 0] = oreSellPrice;
		tradeTable[2, 1] = oreBuyPrice;
		tradeTable[3, 0] = recruterSellPrice;
		tradeTable[3, 1] = recruterBuyPrice;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
