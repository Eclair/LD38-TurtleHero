using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageTradeMenu : MonoBehaviour {

	public Text sellWood;
	public Text buyWood;

	public Text sellStone;
	public Text buyStone;

	public Text sellSteel;
	public Text buySteel;

	public Text sellRecruit;
	public Text buyRecruit;

	public void updatePricesUI() {
		float[,] priceTable = Village.instance.tradeTable;

		sellWood.text = "" + priceTable[0, 0];
		buyWood.text = "" + priceTable[0, 1];

		sellStone.text = "" + priceTable[1, 0];
		buyStone.text = "" + priceTable[1, 1];

		sellSteel.text = "" + priceTable[2, 0];
		buySteel.text = "" + priceTable[2, 1];

		sellRecruit.text = "" + priceTable[3, 0];
		buyRecruit.text = "" + priceTable[3, 1];
	}

	public void sellWoodClick() {
		ResourceManager.instance.sellWoodToVillage();
	}

	public void buyWoodClick() {
		ResourceManager.instance.buyWoodFromVillage();
	}

	public void sellStoneClick() {
		ResourceManager.instance.sellStoneToVillage();
	}

	public void buyStoneClick() {
		ResourceManager.instance.buyStoneFromVillage();
	}

	public void sellSteelClick() {
		ResourceManager.instance.sellSteelToVillage();
	}

	public void buySteelClick() {
		ResourceManager.instance.buySteelFromVillage();
	}

	public void sellRecruitClick() {
		ResourceManager.instance.sellRecruitToVillage();
	}

	public void buyRecruitClick() {
		ResourceManager.instance.buyRecruitFromVillage();
	}
}
