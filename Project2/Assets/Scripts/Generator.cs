using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject objective;
    public GameObject NPC;
    public int Number;
    public Vector2 XZ_RANGE;

    // Start is called before the first frame update
    void Start()
    {
        var obj = GameObject.FindGameObjectsWithTag("Objective");

        if(obj.Length == 0)
        {
            var n = Instantiate(objective);
            n.transform.position = new Vector3(0, 7.2f, 0); 
        }

        for (int i = 0; i < Number; i++)
        {
            var n = Instantiate(NPC);
            n.transform.position = new Vector3(0, 7.2f, 0.0f);
        }


    }
}
