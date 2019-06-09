using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // Allows the class to appear in the inspector for AudioManager
public class Sound {

	public string name; // Name each array element
	public AudioClip clip; // Reference to audio clip

	[Range(0f, 1f)] // Range of volume that is allowed for each array element
	public float volume; // Volume control
	[Range(.1f, 3f)] // Range of pitch that is allowed for each array element
	public float pitch; // Pitch control	

	public bool loop; // For looping audio

	[HideInInspector] // Makes it invisible in inspector even though it's public
	public AudioSource source; // Stored audio source from AudioMananger class
}
