using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUpdate : MonoBehaviour {

	public TMP_Text text;

	private void Start() {
		PlayerStats.start();
		updateText();
	}

	public void updateText() {
		text.text = "Unique Ending: " + PlayerStats.uniqueIds.Count + "/27\nMarriages Reconnected: " + PlayerStats.reconnected + "\nMarriages Separated: " + PlayerStats.seperated;
	}
}
