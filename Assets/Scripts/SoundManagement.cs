using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagement : MonoBehaviour
{
    public GameObject BackgroundPanel; // Reference to the GameObject you want to disable
    public AudioSource audioSource; // Reference to the AudioSource you want to stop

    public AudioClip PowerUpEffect;
    public AudioClip BreakEffect;

    // This function is called when the button is pressed
    public void OnButtonPress()
    {
        if (BackgroundPanel != null)
        {
            BackgroundPanel.SetActive(false); // Disable the GameObject
        }

        if (audioSource != null)
        {
            audioSource.Stop(); // Stop the AudioSource
        }
    }

    public void PowerUpPlay()
    {
        audioSource.clip = PowerUpEffect;
    }
    public void BreakSoundPlay()
    {
        audioSource.clip = BreakEffect;
    }
}
