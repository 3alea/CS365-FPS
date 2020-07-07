using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBuildShow : MonoBehaviour
{
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var obj = GameObject.FindGameObjectsWithTag("Objective");

        if (obj.Length > 0)
        {
            var scr = obj[0].GetComponent<ObjectiveScript>();
            if (time == 0)
            {
                Texture2D col = (Texture2D)scr.Buildings[scr.DayBuilding].GetComponent<MeshRenderer>().material.mainTexture;

                Sprite sp = Sprite.Create(col, new Rect( new Vector2(0,0),new Vector2(col.width,col.height)), gameObject.GetComponent<UnityEngine.UI.Image>().sprite.pivot);

                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sp;
            }
            else if(time == 1)
            {
                Texture2D col = (Texture2D)scr.Buildings[scr.NoonBuilding].GetComponent<MeshRenderer>().material.mainTexture;

                Sprite sp = Sprite.Create(col, new Rect(new Vector2(0, 0), new Vector2(col.width, col.height)), gameObject.GetComponent<UnityEngine.UI.Image>().sprite.pivot);

                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sp;
            }
            else if(time == 2)
            {
                Texture2D col = (Texture2D)scr.Buildings[scr.NightBuilding].GetComponent<MeshRenderer>().material.mainTexture;

                Sprite sp = Sprite.Create(col, new Rect(new Vector2(0, 0), new Vector2(col.width, col.height)), gameObject.GetComponent<UnityEngine.UI.Image>().sprite.pivot);

                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sp;
            }
        }


    }
}
