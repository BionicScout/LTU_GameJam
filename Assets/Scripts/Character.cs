using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	//float pleanstness, energy;
	public enum moods { HAPPY, SAD, ANGRY, CALM, NULL };
	public string name;
	public moods currentMood = moods.NULL; 

	public List<DialogueOption> dialogue;

	private void Start() {
		CharacterList.characters.Add(this);
	}
}
