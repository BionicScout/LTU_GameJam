using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RoundList {
	public static List<Round> rounds = new List<Round>();

	public static Round getRound(string id) {
		foreach (Round round in rounds) {
			Debug.Log("Check: " + round.id + "\tId: " + id);
			if (round.id == id) {
				Debug.Log("Check: " + round.dialogues);
				return round;
			}
		}

		return null;
	}
}
