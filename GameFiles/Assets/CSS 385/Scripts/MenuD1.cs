using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuD1 : MonoBehaviour {

	public void PlayGame() {
		FindObjectOfType<AudioManager>().Play("Menu Button Click"); // Plays the audio clip
		SceneManager.LoadScene ("Digital1");
	}
}
