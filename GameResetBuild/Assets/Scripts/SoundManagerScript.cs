using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip initialSound, flipperSound, bumperSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // sounds for specifc items
        initialSound = Resources.Load<AudioClip>("Initial");
        flipperSound = Resources.Load<AudioClip>("Flippers");
        bumperSound = Resources.Load<AudioClip>("Bumper");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip) //checks clip string parameter
        {
            case "Initial":
                audioSource.PlayOneShot(initialSound);
                break;
            case "Flippers":
                audioSource.PlayOneShot(flipperSound);
                break;
            case "Bumper":
                audioSource.PlayOneShot(bumperSound);
                break;
        }
    }

}