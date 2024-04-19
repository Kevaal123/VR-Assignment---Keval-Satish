using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] songs; // Array to hold the audio clips (songs)
    public AudioSource audioSource; // Reference to the AudioSource component

    public int currentIndex = -1; // Index of the current song
    private float volume = 1.0f; // Initial volume level

    void Start()
    {
        // Start playing music on the AudioSource component
        PlayRandomSong();
    }

    void PlayRandomSong() // Method to play a random song
    {
        if (songs != null && songs.Length > 0) // Check if there are songs assigned
        {
            int randomIndex = Random.Range(0, songs.Length); // Get a random index
            PlaySong(randomIndex); // Play the song at the random index
        }
        else
        {
            Debug.LogWarning("No songs assigned to AudioManager.");
        }
    }

    void Update()
    {
        // Check if the current song has finished playing
        if (currentIndex >= 0 && currentIndex < songs.Length)
        {
            if (!audioSource.isPlaying)
            {
                PlayNextSong(); // Play the next song
            }
        }
    }

    void PlaySong(int index) // Method to play a song at a specific index
    {
        if (index >= 0 && index < songs.Length) // Check if the index is valid
        {
            // Update the current index
            currentIndex = index;

            // Play the new song on the AudioSource component
            audioSource.clip = songs[currentIndex];
            audioSource.Play();
            audioSource.volume = volume; // Set the volume
        }
        else
        {
            Debug.LogWarning("Invalid song index.");
        }
    }

    // Method to play the next song
    public void PlayNextSong()
    {
        int nextIndex = (currentIndex + 1) % songs.Length;
        PlaySong(nextIndex);
    }

    // Method to set the volume level
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume); // Ensure volume is between 0 and 1
        audioSource.volume = volume; // Set the volume on the AudioSource component
    }

    // Method to get the current volume level
    public float GetVolume()
    {
        return volume;
    }
}
