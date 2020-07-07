using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getcolordata : MonoBehaviour
{
    public bool body;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.FindGameObjectsWithTag("Objective");

        if(obj.Length > 0)
        {
            if (body)
            {
                Color col = obj[0].GetComponent<ObjectiveScript>().BodyColor;
                col.a = 1;
                gameObject.GetComponent<UnityEngine.UI.Image>().color = col;
            }
            else
            {
                Color col = obj[0].GetComponent<ObjectiveScript>().HeadColor;
                col.a = 1;
                gameObject.GetComponent<UnityEngine.UI.Image>().color = col;
            }
        }
       
        
    }
}
