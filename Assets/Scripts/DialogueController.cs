using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour {
	public TMP_Text characterName;

	public GameObject characterText;
	public TMP_Text text;

    public GameObject optionText;
	public TMP_Text[] options;

	public Round[] roundsList;

	[TextArea]
	public string[] startText;

	Round round;

	DialogueOption[] dialogueButtons = new DialogueOption[3];

	Queue<string> characterNextText = new Queue<string>();

	public SceneSwitcher ss;

    void Start() {
		round = roundsList[0];
		characterText.SetActive(false);
		updateOptions();

		// Start dialogue
		foreach (string str in startText) {
			characterNextText.Enqueue(str);
		}

		text.text = characterNextText.Dequeue();
		switchText();
	}

	void updateOptions() {
		List<DialogueOption> dialogue = round.dialogues;

		int buttonIndex = 0;
		for (int i = 0; i < dialogue.Count; i++) {
			if (dialogue[i].playerSelectText.Length > 150) {
				options[buttonIndex].text = dialogue[i].playerSelectText.Substring(0, 150);
			} else
				options[buttonIndex].text = dialogue[i].playerSelectText;

			dialogueButtons[buttonIndex] = dialogue[i];
			buttonIndex++;

			if (buttonIndex > 2)
				break;
		}
		
		for (int i = 2; i >= buttonIndex; i--) {
			dialogueButtons[i] = null;
			options[i].text = "";
		}
	}

	private void Update() {


		if (Input.GetMouseButtonDown(0)) {
			if (characterNextText.Count > 0) {
				string str = characterNextText.Dequeue(); ;
				text.text = str;

				if (str.IndexOf("SEPARATED") != -1) {
					//PlayerStats.updateStats(round.id, false);
					ss.A_LoadScene(3);
					return;
				}
				if (str.IndexOf("RECONNECTED") != -1) {
					//PlayerStats.updateStats(round.id, true);
					ss.A_LoadScene(2);
					return;
				}
			}
			else if (characterNextText.Count == 0 && characterText.activeSelf == true) {
				updateOptions();
				switchText();
			}
		}
	}

	void switchText() {
		if (characterText.activeSelf == true) {
			characterText.SetActive(false);
			optionText.SetActive(true);
		}
		else {
			optionText.SetActive(false);
			characterText.SetActive(true);
		}
	}

	public void buttonClick(int buttonIndex) {
		if (dialogueButtons[buttonIndex] == null) 
			return;

		string[] displayText;

		displayText = dialogueButtons[buttonIndex].dialogueText;

		round.unlocked = false;
		round = getRound(dialogueButtons[buttonIndex].unlocksNextId);

		foreach (string str in displayText) {
			characterNextText.Enqueue(str);
		}

		text.text = characterNextText.Dequeue();
		switchText();
	}

	public Round getRound(string id) {
		foreach (Round round in roundsList) {
			Debug.Log("Check: " + round.id + "\tId: " + id);
			if (round.id == id) {
				return round;
			}
		}

		return null;
	}
}
