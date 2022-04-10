using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class PlayerStats {
	public static List<string> uniqueIds = new List<string>();
	public static int reconnected = 0, seperated = 0;


	public static void updateStats(string id, bool isReconnected) {
		if (isReconnected)
			reconnected++;
		else
			seperated++;

		foreach (string compId in uniqueIds) {
			if (compId == id) {
				return;
			}
		}

		uniqueIds.Add(id);
	}
}
