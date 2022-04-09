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

	public Character c;

	DialogueOption[] dialogueButtons = new DialogueOption[3];

	Queue<string> characterNextText = new Queue<string>();

    void Start() {
		characterText.SetActive(false);
		characterName.text = c.name;
		updateOptions();
    }

	void updateOptions() {
		List<DialogueOption> dialogue = c.dialogue;

		int buttonIndex = 0;
		for (int i = 0; i < dialogue.Count; i++) {
			if (!dialogue[i].unlocked)
				continue;

			if (dialogue[i].playerSelectText.Length > 150) {
				options[buttonIndex].text = dialogue[i].playerSelectText.Substring(0, 150);
			} else
				options[buttonIndex].text = dialogue[i].playerSelectText;

			dialogueButtons[buttonIndex] = dialogue[i];
			buttonIndex++;

			if (buttonIndex > 2)
				break;
		}
		Debug.Log(buttonIndex);
		for (int i = 2; i >= buttonIndex; i--) {
			dialogueButtons[i] = null;
			options[i].text = "";
		}
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.T)) {
			switchText();
		}

		if (Input.GetKeyDown(KeyCode.U)) {
			updateOptions();
		}

		if (Input.GetMouseButtonDown(0)) {
			if (characterNextText.Count > 0) {
				string str = characterNextText.Dequeue(); ;
				text.text = str;
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

	public void buttonClick(int index) {
		if (dialogueButtons[index] == null) 
			return;

		dialogueButtons[index].unlocked = false;

		foreach (string str in dialogueButtons[index].characterSpeakText) {
			characterNextText.Enqueue(str);
		}

		text.text = characterNextText.Dequeue();
		switchText();
	}

}
