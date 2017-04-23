using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutotradeMenu : MonoBehaviour {

	public Text goldCoinsText;

	public void updateWithCoinsEarned(int coinsEarned) {
		goldCoinsText.text = "" + coinsEarned;
	}
}
