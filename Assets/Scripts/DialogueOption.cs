using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption {
	public string id;
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

	public string unlocksNextId;
	public Character.moods unlockMood = Character.moods.NULL;
}