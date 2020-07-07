using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;
using System.Linq.Expressions;

public class SetOnPath : MonoBehaviour
{

    //public PathCreator MyPath;
    public PathFollower Follower;
    public GameObject Clock;
    bool TravelledMid = false;
    bool TravelledNight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Follower.pathCreator = GameObject.Find(Path).GetComponent<PathCreator>();
        Follower.distanceTravelled = 0;

        if (Clock.GetComponent<DayNightCicle>().timeOfDay > 3 / 24)
        {
            if(!TravelledMid)
            {

                TravelledMid = true;
            }
        }


        if (Clock.GetComponent<DayNightCicle>().timeOfDay > 9 / 24)
        {
            if(!TravelledNight)
            {

                TravelledNight = true;
            }
        }*/
    }
}
