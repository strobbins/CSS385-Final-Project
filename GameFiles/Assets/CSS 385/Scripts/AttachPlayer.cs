using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour {

	[SerializeField] private GameObject player;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) // If player is touching object
			player.transform.parent = transform; // Move player with object
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) // If player stops touching object
			player.transform.parent = null; // Stop moving player with object
	}
}
