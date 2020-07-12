using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public RectTransform cursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //cursor.transform.position = cursorPos;
        cursor.position = Input.mousePosition;
        Debug.Log("Mouse Pos: " + Input.mousePosition);
    }
}
