using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour {

    [SerializeField]
    public float REAL_SECONDS_PER_INGAME_DAY = 60f;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private Text Daytime_text;
    private Text timeText;
    private float day;

    //[SerializeField]
    public float hour;
    //[SerializeField]
    public float minute;

    private void Awake() {
        clockHourHandTransform = transform.Find("hourHand");
        clockMinuteHandTransform = transform.Find("minuteHand");
        timeText = transform.Find("timeText").GetComponent<Text>();
        Daytime_text = transform.Find("Daytime_text").GetComponent<Text>();
    }

    private void Update() {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f * 2;
        clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 24f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * 12);

        hour = Mathf.Floor(dayNormalized * hoursPerDay);
        set_daytime();
        string hoursString = hour.ToString("00");

        float minutesPerHour = 60f;
        minute = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour);
        string minutesString = minute.ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }
    void set_daytime()
    {
        if (0 <= hour && hour < 9)
            Daytime_text.text = "Morning";
        if (9 <= hour && hour < 13 )
            Daytime_text.text = "Noon";
        if (13 <= hour && hour < 17)
            Daytime_text.text = "Afternoon";
        if(17 <= hour && hour < 20)
            Daytime_text.text = "Dusk";
        if(20 <= hour && hour < 24)
            Daytime_text.text = "Night";
    }
}
