using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletLogic : MonoBehaviour
{
    float timer;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        delay = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {

        print(collision.gameObject.name);
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "NPC_head")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Loose");
        }
        else if (collision.gameObject.tag == "Objective")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Win");
        }
    }
}
