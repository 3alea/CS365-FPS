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
    float currentFOV;
 
    private void Start()
    {
        rifle = GameObject.Find("Rifle");
        aiming_time = 0.2f;
        aiming_vel = 0.1f;
        currentFOV = FOV_notScoped;
    }

    // Update is called once per frame
    void Update()
    {

        if (isScoped == true && Camera.main.fieldOfView / currentFOV < 1.5f)
        {
            scopeOverlay.SetActive(true);
        }
        else
        {
            scopeOverlay.SetActive(false);
        }
        
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,currentFOV,0.15f);

        if (Input.GetButton("Fire2"))
        {
            if (timer < aiming_time)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isScoped = true;
                currentFOV = FOV_Scoped;
            }
        }
        else
        {
            timer = 0;
            isScoped = false;
            currentFOV = FOV_notScoped;
        }

        if (Input.GetMouseButtonUp(1) && TutorialMode) {
            TutorialMode = false;
            Back.active = true;
            Text.active = true;
        }
    }
}
