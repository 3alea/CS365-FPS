using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBodyData : MonoBehaviour
{
    public bool body;
    public Sprite squareimage;
    public Sprite circleImage;
    public GameObject Win;
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
            bool Square;
            if (body)
            {
                Square = obj[0].GetComponent<ObjectiveScript>().SquareBody;
            }
            else
            {
                Square = obj[0].GetComponent<ObjectiveScript>().SquareHead;
            }

            if (Square)
            {
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = squareimage;
            }
            else
            {
                gameObject.GetComponent<UnityEngine.UI.Image>().sprite = circleImage;
            }
        }



    

}
}
