using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestinationMenu : MonoBehaviour {

	[Header("Buttons and Markers")]
	public GameObject dest1marker;
	public GameObject dest1button;
	public Text dest1text;

	public GameObject dest2marker;
	public GameObject dest2button;
	public Text dest2text;

	public GameObject dest3marker;
	public GameObject dest3button;
	public Text dest3text;

	public GameObject dest4marker;
	public GameObject dest4button;
	public Text dest4text;

	public GameObject dest5marker;
	public GameObject dest5button;
	public Text dest5text;

	public GameObject dest6marker;
	public GameObject dest6button;
	public Text dest6text;

	public GameObject confirmDialog;
	public Text destinationText;
	public Text etaText;

	private int selectedDestination;

	public void updateUI() {
		int currentPlace = GlobalMapManager.instance.currentPlace;

		dest1marker.SetActive(currentPlace == 0);
		dest1button.SetActive(currentPlace != 0);

		dest2marker.SetActive(currentPlace == 1);
		dest2button.SetActive(currentPlace != 1);

		dest3marker.SetActive(currentPlace == 2);
		dest3button.SetActive(currentPlace != 2);

		dest4marker.SetActive(currentPlace == 3);
		dest4button.SetActive(currentPlace != 3);

		dest5marker.SetActive(currentPlace == 4);
		dest5button.SetActive(currentPlace != 4);

		dest6marker.SetActive(currentPlace == 5);
		dest6button.SetActive(currentPlace != 5);

		confirmDialog.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		string[] places = GlobalMapManager.instance.places;
		dest1text.text = places[0];
		dest2text.text = places[1];
		dest3text.text = places[2];
		dest4text.text = places[3];
		dest5text.text = places[4];
		dest6text.text = places[5];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void dest1selected() {
		showConfirmDialog(0);
	}

	public void dest2selected() {
		showConfirmDialog(1);
	}

	public void dest3selected() {
		showConfirmDialog(2);
	}

	public void dest4selected() {
		showConfirmDialog(3);
	}

	public void dest5selected() {
		showConfirmDialog(4);
	}

	public void dest6selected() {
		showConfirmDialog(5);
	}

	private void showConfirmDialog(int destination) {
		selectedDestination = destination;
		destinationText.text = "Destination: " + GlobalMapManager.instance.places[selectedDestination];
		etaText.text = "ETA: " + GlobalMapManager.instance.travelTime[GlobalMapManager.instance.currentPlace, selectedDestination] + " days";
		confirmDialog.SetActive(true);
	}

	public void confirmDialogYes() {
		confirmDialog.SetActive(false);
		UIHelper.instance.closeDestinationMenu();
		GlobalMapManager.instance.startSailingTo(selectedDestination);
	}

	public void confirmDialogNo() {
		confirmDialog.SetActive(false);
	}
}
