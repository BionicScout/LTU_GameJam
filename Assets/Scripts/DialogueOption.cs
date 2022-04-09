using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption {
	public bool unlocked;

	[TextArea]
	public string playerSelectText;

	[TextArea]
	public string[] characterSpeakText;

	//public Character.moods mood;
	//public DialogueOption nextUnlock;

	//public void checkMood(Character.moods currentMood) {
	//	if(currentMood == mood) {
	//		//nextUnlock = true;
	//	}
	//}
}