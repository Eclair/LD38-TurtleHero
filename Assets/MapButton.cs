using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour {

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
		// TODO: GO TO MAP
		UIHelper.instance.setSailingMode();
		SceneManager.LoadScene("Traveling");
	}
}
