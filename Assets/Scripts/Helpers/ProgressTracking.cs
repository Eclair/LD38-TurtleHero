using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracking : MonoBehaviour {

	public Slider progressSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalMapManager.instance != null) {
			progressSlider.value = GlobalMapManager.instance.remainTravelTime / GlobalMapManager.instance.totalDistance;
		}
	}
}
