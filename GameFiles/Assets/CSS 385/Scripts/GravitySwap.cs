using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour {

	// When player touches collider, flip gravity to horizontal orientation
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag("Player"))
			Physics2D.gravity = new Vector2(9.81f, 0f);
	}

	// When player touches collider, flip gravity to vertical orientation
	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.CompareTag("Player"))
			Physics2D.gravity = new Vector2(0f, -9.81f);
	}
}
