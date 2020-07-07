using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using PathCreation;
using System.Linq.Expressions;

public class npcscript : MonoBehaviour
{
    //Stats
    public int DayBuilding;
    public int NoonBuilding;
    public int AfternoonBuilding;
    public int DuskBuilding;
    public int NightBuilding;

    bool travelling_day       = false;   
    bool travelling_noon      = false;
    bool travelling_afternoon = false;
    bool travelling_dusk      = false;
    bool travelling_night     = false;

    public float Velocity;

    public GameObject SquareMeshObj;
    public GameObject CircleMeshObj;
    Mesh SquareMesh;
    Mesh CircleMesh;

    public GameObject[] Buildings;
    public Color[] Colors;


    public bool SquareBody;
    public bool SquareHead;

    public Color BodyColor;
    public Color HeadColor;

    public PathFollower Follower;

    ClockUI clock;
    float hours = 0;

    // Start is called before the first frame update
    void Start()
    {
        SquareMeshObj = GameObject.Find("Cube (1)");
        CircleMeshObj = GameObject.Find("Sphere (1)");
        
        SquareMesh = SquareMeshObj.GetComponent<MeshFilter>().mesh;
        CircleMesh = CircleMeshObj.GetComponent<MeshFilter>().mesh;

        Buildings = GameObject.FindGameObjectsWithTag("Building");

        if (Buildings.Length != 0)
        {
            DayBuilding       = Random.Range(0, Buildings.Length - 1);
            NoonBuilding      = Random.Range(0, Buildings.Length - 1);
            AfternoonBuilding = Random.Range(0, Buildings.Length - 1);
            DuskBuilding      = Random.Range(0, Buildings.Length - 1);
            NightBuilding     = Random.Range(0, Buildings.Length - 1);
        }
        else
        {
            DayBuilding       = 0;
            NoonBuilding      = 0;
            AfternoonBuilding = 0;
            DuskBuilding      = 0;
            NightBuilding     = 0;
        }


        int i = Random.Range(0, 2);

        SquareBody = i == 0 ? true : false;
        i = Random.Range(0, 2);
        SquareHead = i == 0 ? true : false;

        BodyColor = Colors[Random.Range(0, Colors.Length)];
        HeadColor = Colors[Random.Range(0, Colors.Length)];

        if (check())
        {
            Start();
            return;
        }

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (SquareHead)
        {
            foreach (MeshFilter m in GetComponentsInChildren<MeshFilter>())
            {
                m.mesh = SquareMesh;
            }
        }
        else
        {
            foreach (MeshFilter m in GetComponentsInChildren<MeshFilter>())
            {
                m.mesh = CircleMesh;
            }
        }


        if (SquareBody)
        {
            GetComponent<MeshFilter>().mesh = SquareMesh;
        }
        else
        {
            GetComponent<MeshFilter>().mesh = CircleMesh;
        }

        //Change the colors
        foreach (Renderer re in GetComponentsInChildren<Renderer>())
        {
            re.material.color = HeadColor;
        }

        Renderer r = GetComponent<Renderer>();
        r.material.color = BodyColor;

        clock = GameObject.Find("Clock").GetComponent<ClockUI>();

        string Path = "CenterTo";
        Path += Buildings[NightBuilding].name;

        var actual_path = GameObject.Find(Path);
        if( actual_path != null)
        { 
            Follower.pathCreator = actual_path.GetComponent<PathCreator>();
            Follower.distanceTravelled = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        hours = clock.hour;
        
        // Morning
        if (0 <= hours && hours < 9  && !travelling_day)
        {
            travelling_night = false;
            travelling_day = true;

            string Path = Buildings[NightBuilding].name;
            Path += "To";
            Path += Buildings[DayBuilding].name;

            var actual_path = GameObject.Find(Path);
            if( actual_path != null)
            { 
                Follower.pathCreator = actual_path.GetComponent<PathCreator>();
                Follower.distanceTravelled = 0;
            }
        }

        // Noon
        if (9 <= hours && hours < 13 && !travelling_noon)
        {
            string Path = Buildings[DayBuilding].name;
            Path += "To";
            Path += Buildings[NoonBuilding].name;
            
            var actual_path = GameObject.Find(Path);
            if( actual_path != null)
            { 
                Follower.pathCreator = actual_path.GetComponent<PathCreator>();
                Follower.distanceTravelled = 0;
            }

            travelling_day = false;
            travelling_noon = true;
        }
        
        // Afternoon
        if (13 <= hours && hours < 17 && !travelling_afternoon)
        {        
            string Path = Buildings[NoonBuilding].name;
            Path += "To";
            Path += Buildings[AfternoonBuilding].name;
            
            var actual_path = GameObject.Find(Path);
            if( actual_path != null)
            { 
                Follower.pathCreator = actual_path.GetComponent<PathCreator>();
                Follower.distanceTravelled = 0;
            }

            travelling_noon = false;
            travelling_afternoon = true;
        }
        // Dusk
        if(17 <= hours && hours < 20 && !travelling_dusk)
        {
            string Path = Buildings[AfternoonBuilding].name;
            Path += "To";
            Path += Buildings[DuskBuilding].name;
            
            var actual_path = GameObject.Find(Path);
            if( actual_path != null)
            { 
                Follower.pathCreator = actual_path.GetComponent<PathCreator>();
                Follower.distanceTravelled = 0;
            }

            travelling_afternoon = false;
            travelling_dusk = true;
        }
        // Night
        if(20 <= hours && hours < 24 && !travelling_night)
        {
            string Path = Buildings[DuskBuilding].name;
            Path += "To";
            Path += Buildings[NightBuilding].name;
            
            var actual_path = GameObject.Find(Path);
            if( actual_path != null)
            { 
                Follower.pathCreator = actual_path.GetComponent<PathCreator>();
                Follower.distanceTravelled = 0;
            }

            travelling_dusk = false;
            travelling_night = true;
        }
    }


    bool check()
    {
        var Objective = GameObject.FindGameObjectsWithTag("Objective")[0];
        var script = Objective.GetComponent<ObjectiveScript>();
        if (script.SquareBody == SquareBody &&
            script.SquareHead == SquareHead &&

            script.DayBuilding == DayBuilding &&
            script.NoonBuilding == NoonBuilding &&
            script.AfternoonBuilding == AfternoonBuilding &&
            script.DuskBuilding == DuskBuilding &&
            script.NightBuilding == NightBuilding &&

            script.BodyColor == BodyColor &&
            script.HeadColor == HeadColor)
        {
            return true;
        }
        return false;
    }
}
