using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMapManager : MonoBehaviour {

	public static GlobalMapManager instance;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		}  else if (instance != this) {
			Destroy(gameObject);
		}
	}

	public int currentPlace = 0;
	public string[] places = new string[]{
		"Cartap",
		"Bosno",
		"Yelington",
		"Travinia",
		"Popsono",
		"Ratek"
	}; // TODO: Generate Random Names

	// Time needed to sail between towns (seconds)
	public float[,] travelTime = new float[6, 6] {
		{ 0, 40, 30, 40, 50, 60},
		{40,  0, 30, 70, 65, 25},
		{30, 30,  0, 40, 20, 25},
		{40, 70, 40,  0, 30, 75},
		{50, 65, 20, 30,  0, 40},
		{60, 25, 25, 75, 40,  0}
	};

	public float remainTravelTime;
	public int fromPlace;
	public int toPlace;

	public bool sailing;

	public void startSailingTo(int place) {
		fromPlace = currentPlace;
		toPlace = place;
		remainTravelTime = travelTime[fromPlace, toPlace];

		UIHelper.instance.setSailingMode();
		sailing = true;
		SceneManager.LoadScene("Traveling");

		// TODO: SET DESTINATION
		// TODO: START SAILING
		// TODO: DISABLE BUILDING MODE
		// TODO: FIGHT!
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sailing) {
			if (remainTravelTime > 0) {
				remainTravelTime -= Time.deltaTime;
				Debug.Log("remainingTime: " + remainTravelTime);
				// TODO: Update UI
			} else {
				// WE ARRIVED!!!!!
				Debug.Log("we arrived!!");
				currentPlace = toPlace;
				sailing = false;
				UIHelper.instance.setBuildingMode();
				SceneManager.LoadScene("InVillage");
			}
		}
	}
}
