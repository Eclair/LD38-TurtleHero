using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour {

	public GameObject tower;

	public void swapTowerWith(GameObject newTower) {
		if (tower != null) {
			Destroy(tower);
		}
		tower = newTower;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
