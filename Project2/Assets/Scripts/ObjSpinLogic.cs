using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpinLogic : MonoBehaviour
{
    public Vector3 spinSpeed;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.eulerAngles += spinSpeed * Time.deltaTime;
    }
}
