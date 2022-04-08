using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOption : MonoBehaviour {
	public bool unlocked;
	public string text;
	public Character.moods mood;
	public DialogueOption nextUnlock;

	public void checkMood(Character.moods currentMood) {
		if(currentMood == mood) {
			//nextUnlock = true;
		}
	}
}