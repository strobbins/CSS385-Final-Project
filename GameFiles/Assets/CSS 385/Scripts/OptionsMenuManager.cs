using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour {

	public MenuReturn mr;
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKeyDown (KeyCode.Escape)) // If escape is pressed, can open and close menu
				mr.gameObject.SetActive (!mr.gameObject.activeSelf);
	}
}
