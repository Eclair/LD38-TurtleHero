using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQSpot : MonoBehaviour {

	public GameObject hq;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void swapHQWithNew(GameObject newHQ) {
		if (hq != null) {
			Destroy(hq);
		}
		hq = newHQ;
	}

}
