using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Tutorial: https://www.youtube.com/watch?v=babgYCTyw3Y

public class DayNightCycle : MonoBehaviour
{
    private float targetDayLength = 0.5f; //length of day in minutes

    [Header("Time")]
    [SerializeField]
    [Range(0f, 1f)]
    public float timeOfDay;

    [SerializeField]
    private int dayNumber = 0; //tracks the days passed

    private float timeScale = 100f;

    public bool pause = false;

    [Header("Sun Light")]
    [SerializeField]
    private Transform dailyRotation;
    [SerializeField]
    private Light sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity = 1f;
    [SerializeField]
    private float sunVariation = 1.5f;
    [SerializeField]
    private Gradient sunColor;

    [Header("Moon Light")]
    [SerializeField]
    private Light moon;
    [SerializeField]
    private float baseIntensity = 0.35f;
    [SerializeField]
    private Gradient moonColor;

    
    private void Awake()
    {
        float seconds_in_game = GameObject.Find("Clock").GetComponent<ClockUI>().REAL_SECONDS_PER_INGAME_DAY;
        targetDayLength = seconds_in_game / 60f; //length of day in minutes
    }

    private void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }

        AdjustSunRotation();
        UpdateSun();
        UpdateMoon();

    }

    private void UpdateTimeScale()
    {
        timeScale = 24 / (targetDayLength / 60);
    }

    private void UpdateTime()
    {
        timeOfDay += Time.deltaTime * timeScale / 86400; // seconds in a day
        if (timeOfDay > 1) //new day!!
        {
            dayNumber++;
            timeOfDay -= 1;
        }
    }

    //rotates the sun daily (and seasonally soon too);
    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 360f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

    private void UpdateSun()
    {
        SunIntensity();
        AdjustSunColor();
    }

    private void SunIntensity()
    {
        intensity = Vector3.Dot(sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }

    private void AdjustSunColor()
    {
        sun.color = sunColor.Evaluate(intensity);
    }

    private void UpdateMoon()
    {
        MoonIntensity();
        AdjustMoonColor();
    }

    private void MoonIntensity()
    {
        moon.intensity = (1 - intensity) * baseIntensity + 0.05f;
    }

    private void AdjustMoonColor()
    {
        moon.color = moonColor.Evaluate(1 - intensity);
    }
}
