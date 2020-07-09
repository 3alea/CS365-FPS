using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjetive : MonoBehaviour{

    public GameObject Day;
    public GameObject Noon;
    public GameObject Night;
    float hour = 0;
    float speed = 15;     

    // Start is called before the first frame update
    void Start(){
        hour = GameObject.Find("Clock").GetComponent<ClockUI>().hour;
    }

    // Update is called once per frame
    void Update(){
        hour = GameObject.Find("Clock").GetComponent<ClockUI>().hour;
        float step = speed * Time.deltaTime; // calculate distance to move

        if (hour < 9){
            Vector3 pos = new Vector3(1.5f, 0.0f, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, Day.transform.position - pos, step);
        }

        if (hour > 9 && hour < 16){ //noon
            Vector3 pos = new Vector3(1.5f, 0.0f, 0.0f);
            transform.position = Vector3.MoveTowards(transform.position, Noon.transform.position + pos, step);
        }


        if (hour > 16){ //night
            Vector3 pos = new Vector3(0.0f, 0.0f, 1.5f);
            transform.position = Vector3.MoveTowards(transform.position, Night.transform.position - pos, step);
        }

    }
}
