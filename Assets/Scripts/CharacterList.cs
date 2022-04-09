using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterList {
	public static List<Character> characters = new List<Character>();

	public static DialogueOption getDialogue(string id) {
		foreach (Character character in characters) {
			foreach(DialogueOption dialogue in character.dialogue) {
				if (dialogue.id == id) {
					return dialogue;
				}
			}
		}

		return null;
	}
}
