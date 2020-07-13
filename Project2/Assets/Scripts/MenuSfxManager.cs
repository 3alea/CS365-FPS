using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSfxManager : MonoBehaviour
{
    public AudioClip gunShot;
    static AudioSource audioSrc;

    // Time between each shot
    float time = 0.2f;
    float timer = 0.0f;
    bool playerHasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHasShot == false)
        {
            // Player wants to shoot
            if (Input.GetMouseButton(0))
            {
                playerHasShot = true;
                timer = 0.0f;

                // Play sound
                audioSrc.PlayOneShot(gunShot);
            }
            return;
        }

        // Update the timer
        timer += Time.deltaTime;

        // Check if enough time has passed since
        // the player shot
        if (timer >= time)
        {
            playerHasShot = false;
            timer = 0.0f;
        }
    }
}
