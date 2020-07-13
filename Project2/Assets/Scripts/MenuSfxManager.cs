using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSfxManager : MonoBehaviour
{
    public AudioClip gunShot;
    public AudioClip reload;
    static AudioSource audioSrc;

    // Time between each shot
    float time = 0.2f;
    float timer = 0.0f;
    bool playerHasShot = false;
    bool needToReload = false;
    float timeToReload = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.2f;
        timer = 0.0f;
        playerHasShot = false;
        needToReload = false;
        timeToReload = 0.5f;
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
                needToReload = false;
                timer = 0.0f;

                // Play sound
                audioSrc.PlayOneShot(gunShot);
            }
            
            // Player is not shooting
            else if (needToReload)
            {
                timer += Time.deltaTime;
                if (timer >= timeToReload)
                {
                    audioSrc.PlayOneShot(reload);
                    needToReload = false;
                    timer = 0.0f;
                }
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
            needToReload = true;
        }
    }
}
