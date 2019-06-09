using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "CrushingWall") {
			FindObjectOfType<AudioManager>().Play("Slam"); // Plays the audio clip
		}
	}
}
