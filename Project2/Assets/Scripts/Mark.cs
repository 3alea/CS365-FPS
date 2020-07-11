using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mark : MonoBehaviour
{
    public CameraShake cam_shake;

    public GameObject bulletGenerator;
    public GameObject bullet;
    public GameObject camera;

    private AudioSource audio_source;
    public AudioClip shotSound;
    public Material unselected;
    public Material selected;

    Renderer rend;
    Renderer rend2;

    // Save the material that it has
    public Color old_color;
    public Color old_color2;

    public bool TutorialMode;
    public GameObject Back;
    public GameObject Text;

    public float bullet_speed;
    bool shoted;
    float shot_delay;
    float end_delay;
    float end_timer;
    float shot_timer;
    Vector3 target_pos;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        shoted = false;
        end_delay = 0.5f;
        shot_delay = 0.3f;
        end_timer = 0.0f;
        shot_timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray aimLine = new Ray(camera.transform.position + camera.transform.forward* 10, camera.transform.forward);

        //Done this way duplicating code so raycast is not computed unless you 
        //click or you press F
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(aimLine, out hit, 1000))
            {
                if (hit.collider.tag == "NPC" || hit.collider.tag == "Objective")
                {
                    GameObject obj       = hit.transform.gameObject;

                    GameObject child_obj = obj.transform.GetChild(0).gameObject;



                    if(!child_obj)

                        child_obj = obj.transform.parent.gameObject;



                    rend = obj.GetComponent<Renderer>();

                    rend2 = child_obj.GetComponent<Renderer>();





                    // Save the color of that NPC

                    old_color = rend.material.GetColor("_Color");

                    old_color2 = rend2.material.GetColor("_Color");





                    if (rend && rend2)
                    {
                        if (rend.material.shader == selected.shader)

                        {

                            rend.material = unselected;

                            rend.material.SetColor("_Color", old_color);



                            rend2.material = unselected;

                            rend2.material.SetColor("_Color", old_color2);

                        }
                        else

                        {

                            rend.material = selected;

                            rend.material.SetColor("_Color", old_color);



                            rend2.material = selected;

                            rend2.material.SetColor("_Color", old_color2);

                        }
                    }
                }
                else if (hit.collider.tag == "NPC_head" || hit.collider.tag == "Objective")

                {
                    GameObject obj = hit.transform.gameObject;

                    GameObject child_obj = obj.transform.parent.gameObject;



                    rend = obj.GetComponent<Renderer>();

                    rend2 = child_obj.GetComponent<Renderer>();





                    // Save the color of that NPC

                    old_color = rend.material.GetColor("_Color");

                    old_color2 = rend2.material.GetColor("_Color");





                    if (rend && rend2)
                    {
                        if (rend.material.shader == selected.shader)

                        {

                            rend.material = unselected;

                            rend.material.SetColor("_Color", old_color);



                            rend2.material = unselected;

                            rend2.material.SetColor("_Color", old_color2);

                        }
                        else

                        {

                            rend.material = selected;

                            rend.material.SetColor("_Color", old_color);



                            rend2.material = selected;

                            rend2.material.SetColor("_Color", old_color2);

                        }
                    }

                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && shot_delay < shot_timer) 
        {
            //StartCoroutine(cam_shake.Shake(.15f, .4f));
            audio_source.PlayOneShot(shotSound, 1F);

            shoted = true;
            shot_timer = 0.0f;
            target_pos = camera.transform.forward * 10000;

            if (Physics.Raycast(aimLine, out hit, 10000))
                target_pos = hit.point;

            GameObject instbullet = Instantiate(bullet, bulletGenerator.transform.position, Quaternion.identity) as GameObject;
            Rigidbody rigid = instbullet.GetComponent<Rigidbody>();
            Vector3 dir = new Vector3(target_pos.x - instbullet.transform.position.x, target_pos.y - instbullet.transform.position.y, target_pos.z - instbullet.transform.position.z);
            dir.Normalize();
            rigid.AddForce(dir * bullet_speed);
            Debug.Log(target_pos);
        }

        //Debug.Log(camera.transform.forward);
        

        if (Input.GetKeyUp(KeyCode.F) && TutorialMode){

            TutorialMode = false;

            Back.active = true;

            Text.active = true;

        }

        if(shoted)
        {
            end_timer += Time.deltaTime;

            if (end_timer < end_delay)
                return;
        }
        shot_timer += Time.deltaTime;
    }
}
