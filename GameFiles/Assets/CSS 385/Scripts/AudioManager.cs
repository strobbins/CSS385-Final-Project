using UnityEngine.Audio;
using System; // Allows us to find a sound with Array.Find
using UnityEngine;

// This has a list of sounds that can be added or removed easily, with sound attributes
// The AudioManager will find the source of the sound with the referenced name
public class AudioManager : MonoBehaviour {

	public Sound[] sounds; // Array of sounds

	public static AudioManager instance; // DontDestroyOnLoad creates a duplicate in the new scene, this stops that
	// Use Awake() for right before initialization
	void Awake () {

		if (instance == null) // There are no other AudioManagers running in the scene
			instance = this;
		else { // There's already an AudioManager running in the scene
			Destroy(gameObject); // Deletes that AudioManager
			return; // Ensure no more code is called before destroying the object
		}
		DontDestroyOnLoad (gameObject); // Ensures the AudioManager won't reset the sounds with new scenes

		// All of these are being called from the sounds script
		foreach (Sound s in sounds) { // For each element in the array of sounds
			s.source = gameObject.AddComponent<AudioSource> (); // Add audio source component
			s.source.clip = s.clip; // Clip of audio source
			s.source.volume = s.volume; // Volume of audio source
			s.source.pitch = s.pitch; // Pitch of audio source
			s.source.loop = s.loop; // Option for looping audio
			s.source.spatialBlend = s.spatialBlend; // Option for 2D vs 3D sound
			s.source.rolloffMode = s.rolloffMode; // Option for logarithmic or linear sound 
			s.source.minDistance = s.minDistance; // Set the min distance for sound to be heard
			s.source.maxDistance = s.maxDistance; // Set max distance for sound
		}
	}

	public void Play (string name) { // Public so that it can be called from outside of the class
		Sound s = Array.Find (sounds, sound => sound.name == name); // Find sound in sound array when name matches, store in s
		if (s == null) {
			Debug.LogWarning ("Sound: " + name + "not found! Check your spelling dumbass!"); // Throw a warning
			return; // Avoid the program trying to play a sound that isn't there.
		}
		s.source.Play();
	}
}
