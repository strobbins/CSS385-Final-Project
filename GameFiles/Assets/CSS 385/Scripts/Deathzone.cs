using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	// SerializedField creates a data field to appear on Unity, while still
	// keeping the variable private, so it can't be accessed elsewhere
	[SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;

	// When player touches collider, teleport player to respawn point
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag("Player"))
			player.transform.position = respawnPoint.transform.position;
	}
}
