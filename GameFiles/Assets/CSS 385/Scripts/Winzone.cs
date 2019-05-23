using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winzone : MonoBehaviour {

	[SerializeField] private Transform player;
	public GameObject UI;

	void Start() {
		UI.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			UI.gameObject.SetActive (true);
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll; // Freeze player movement
			StartCoroutine("WaitForSec");
		}
	}
	IEnumerator WaitForSec() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("MainMenu");
	}
}
