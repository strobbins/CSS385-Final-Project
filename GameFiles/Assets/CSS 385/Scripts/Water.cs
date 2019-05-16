using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	[SerializeField] private GameObject player;
	private Rigidbody2D rb;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) // If player is touching object
			other.GetComponent<Rigidbody2D>().drag = 12;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) // If player stops touching object
			player.transform.parent = null; // Stop moving player with object
	}
}
