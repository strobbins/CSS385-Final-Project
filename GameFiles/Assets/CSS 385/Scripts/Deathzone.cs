using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	// SerializedField creates a data field to appear on Unity, while still
	// keeping the variable private, so it can't be accessed elsewhere
	[SerializeField] private Transform player;
	[SerializeField] private Transform respawnPoint;
	public string enemyTag = "Enemy";

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			player.transform.position = respawnPoint.transform.position; // Teleport player to respawn point
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll; // Freeze player movement
			Physics2D.gravity = new Vector2 (0f, -9.81f); // Reset gravity
			player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; // Reset velocity
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None; // Unfreeze movement
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation; // Refreeze rotation
		}
	}
}
