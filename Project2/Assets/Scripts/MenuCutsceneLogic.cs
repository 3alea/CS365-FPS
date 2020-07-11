using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCutsceneLogic : MonoBehaviour
{
    public List<float> timers;

    public List<Transform> sunObjs;
    public Vector3 sunMoveSpeed;

    public Transform soldier;
    public Vector3 soldierMoveSpeed;

    public Transform monster;
    public Vector3 monsterRotationSpeed;
    public Vector3 monsterMovementSpeed;

    public Image explosion;

    public Transform mainMenu;
    public Vector3 mainMenuSpeed;

    private float timeManager;
    private int currentPart;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = 0.0f;
        currentPart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeManager += Time.deltaTime;

        if (currentPart < timers.Count && timeManager >= timers[currentPart])
        {
            currentPart++;
            timeManager = 0.0f;
        }

        switch(currentPart)
        {
            case 0:
                for (int i = 0; i < sunObjs.Count; i++)
                    sunObjs[i].position += sunMoveSpeed * Time.deltaTime;
                break;
            case 1:
                soldier.position += soldierMoveSpeed * Time.deltaTime;
                for (int i = 0; i < sunObjs.Count; i++)
                    sunObjs[i].position += sunMoveSpeed * Time.deltaTime;
                break;
            case 2:
                float normalizedTime = timeManager / timers[currentPart];
                float alphaResult = 1 - normalizedTime * normalizedTime;

                monster.position += monsterMovementSpeed * Time.deltaTime;
                monster.eulerAngles += monsterRotationSpeed * Time.deltaTime;
                explosion.enabled = true;
                explosion.color = new Color(explosion.color.r, explosion.color.g, explosion.color.b, alphaResult);
                break;
            case 3:
                mainMenu.position += mainMenuSpeed * Time.deltaTime;
                break;
        }
    }
}
