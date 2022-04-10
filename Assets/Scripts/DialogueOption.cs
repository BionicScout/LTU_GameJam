using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption {
	[TextArea]
	public string playerSelectText;

	[TextArea]
	public string[] dialogueText;

	public string unlocksNextId;
}