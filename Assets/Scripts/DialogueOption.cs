using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption {
	public bool unlocked;

	[TextArea]
	public string playerSelectText;

	public Character.moods rightMood;
	public Character.moods badMood;

	[TextArea]
	public string[] rightMoodResponse;

	[TextArea]
	public string[] neutralMoodResponse;

	[TextArea]
	public string[] badMoodResponse;

	//public Character.moods mood;
	//public DialogueOption nextUnlock;

	//public void checkMood(Character.moods currentMood) {
	//	if(currentMood == mood) {
	//		//nextUnlock = true;
	//	}
	//}
}