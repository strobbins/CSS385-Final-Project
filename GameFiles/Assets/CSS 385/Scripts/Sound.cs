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
	[Range(0f, 1f)] // For location sound
	public float spatialBlend; // Range of 2D vs 3D sound that is allowed for each array element

	public bool loop; // For looping audio
	public AudioRolloffMode rolloffMode; // Different modes of sound
	public float minDistance; 
	public float maxDistance;

	[HideInInspector] // Makes it invisible in inspector even though it's public
	public AudioSource source; // Stored audio source from AudioMananger class
}
