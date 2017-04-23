using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour {

	public static UIHelper instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}  else if (instance != this) {
			Destroy(gameObject);
		}
	}

	public bool isMenuOpened;

	public Text Message;
	public Color errorColor;
	public Color warningColor;
	public Color normalColor;

	public Text debugStateText;

	public GameObject buildMenuObject;
	public GameObject upgradeMenuObject;
	public GameObject upgradeHQObject;

	// Use this for initialization
	void Start () {
		Message.color = Color.clear;
		isMenuOpened = false;
		buildMenuObject.SetActive(false);
		upgradeMenuObject.SetActive(false);
		upgradeHQObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isBuildingMode = true;

	public void setBuildingMode() {
		isBuildingMode = true;
		debugStateText.text = "Trading";
	}

	public void setSailingMode() {
		isBuildingMode = false;
		debugStateText.text = "Sailing";
	}

	private float textFadeDuration = 2f;

	/** Shows Normal Message **/
	public void showNormalMessage(string message) {
		Message.text = message;
		Message.color = normalColor;
		Message.canvasRenderer.SetAlpha(1f);
		Message.CrossFadeAlpha(0f, textFadeDuration, false);
	}

	/** Shows Error Message **/
	public void showError(string message) {
		Message.text = message;
		Message.color = errorColor;
		Message.canvasRenderer.SetAlpha(1f);
		Message.CrossFadeAlpha(0f, textFadeDuration, false);
	}

	/** Shows Warning Message **/
	public void showWarning(string message) {
		Message.text = message;
		Message.color = warningColor;
		Message.canvasRenderer.SetAlpha(1f);
		Message.CrossFadeAlpha(0f, textFadeDuration, false);
	}

	/** Shows Build New Tower Menu for Selected Tower Spot **/
	public void showBuildMenuFor(TowerSpot towerSpot) {
		buildMenuObject.SetActive(true);
		buildMenuObject.GetComponent<BuildMenu>().selectedTowerSpot = towerSpot;
		isMenuOpened = true;
	}

	/** Closes Build Menu **/
	public void closeBuildMenu() {
		buildMenuObject.SetActive(false);
		isMenuOpened = false;
	}

	/** Shows Tower Upgrade Menu for Selected Tower Spot **/
	public void showUpgradeMenuFor(TowerSpot towerSpot) {
		upgradeMenuObject.GetComponent<UpgradeTowerMenu>().updateWithTowerSpot(towerSpot);
		upgradeMenuObject.SetActive(true);
		isMenuOpened = true;
	}

	/** Closes Tower Upgrade Menu **/
	public void closeUpgradeMenu() {
		upgradeMenuObject.SetActive(false);
		isMenuOpened = false;
	}

	/** Shows HQ Upgrade Menu (Selected Tower Spot reference needed) **/
	public void showUpgradeHQMenuFor(HQSpot hqSpot) {
		upgradeHQObject.GetComponent<UpgradeHQMenu>().updateWithHQSpot(hqSpot);
		upgradeHQObject.SetActive(true);
		isMenuOpened = true;
	}

	/** Closes HQ Upgrade Menu **/
	public void closeUpgradeHQMenu() {
		upgradeHQObject.SetActive(false);
		isMenuOpened = false;
	}
}
