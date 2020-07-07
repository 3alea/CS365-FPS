using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    //variable to know if we should show a scope on the screen
    private bool isScoped = false;

    public GameObject scopeOverlay;

    public float FOV_Scoped;
    public float FOV_notScoped;
    public bool TutorialMode;
    public GameObject Back;
    public GameObject Text;

    private float timer;
    private float aiming_time;
    private float aiming_vel;
    private GameObject rifle;

    private void Start()
    {
        rifle = GameObject.Find("Rifle");
        aiming_time = 0.2f;
        aiming_vel = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        isScoped = false;
        scopeOverlay.SetActive(isScoped);
        Camera.main.fieldOfView = FOV_notScoped;

        if (Input.GetButton("Fire2"))
        {
            if (timer < aiming_time)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isScoped = true;
                scopeOverlay.SetActive(isScoped);
                Camera.main.fieldOfView = FOV_Scoped;
            }
        }
        else
        {
            timer = 0;
        }

        if (Input.GetMouseButtonUp(1) && TutorialMode) {
            TutorialMode = false;
            Back.active = true;
            Text.active = true;
        }
    }
}
