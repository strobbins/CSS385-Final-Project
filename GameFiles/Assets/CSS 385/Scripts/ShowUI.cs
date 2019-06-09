using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour {

	[SerializeField] private GameObject uiObject;

	// Use this for initialization
	void Start () {
		uiObject.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			uiObject.SetActive (true);
			StartCoroutine ("WaitForSec");
		}
	}
	IEnumerator WaitForSec() {
		yield return new WaitForSeconds (12);
		Destroy (uiObject);
		Destroy (gameObject);
	}
}
