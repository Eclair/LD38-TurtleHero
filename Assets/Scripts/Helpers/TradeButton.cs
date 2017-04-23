using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeButton : MonoBehaviour {

	public GameObject highlight;

	// Use this for initialization
	void Start () {
		highlight.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter() {
		if (UIHelper.instance.isMenuOpened) {
			return;
		}
		highlight.SetActive(true);
	}

	void OnMouseExit() {
		highlight.SetActive(false);
	}

	void OnMouseDown() {
		if (UIHelper.instance.isMenuOpened) {
			return;
		}
		UIHelper.instance.showVillageTradeMenu();
		highlight.SetActive(false);
	}
}
