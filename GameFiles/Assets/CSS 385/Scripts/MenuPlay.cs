﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadScene ("DemoScene");
	}
}
